using ClienteProyectoDeMensajeria.ClasesReutilizables;
using Microsoft.Win32;
using RestSharp;
using RestSharp.Serialization.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Web.Helpers;
using System.Windows;
using System.Windows.Controls;
using Newtonsoft.Json;

namespace ClienteProyectoDeMensajeria
{
    /// <summary>
    /// Lógica de interacción para MenuPrincipalUsuario.xaml
    /// </summary>
    public partial class MenuPrincipalUsuario : UserControl
    {
        SoundPlayer ReproductoWav;
        public EventHandler eventoEstados;
        public EventHandler eventoPerfil;
        public EventHandler eventoAgregarAmigo;
        public EventHandler eventoChatGrupal;
        public EventHandler eventCerrarSesion;
        public EventHandler eventVerImagenesDelChat;
        String url;

        //Valores para el chat
        public string nombreChat_Actual;
        public ObservableCollection<Mensaje> mensajes = new ObservableCollection<Mensaje>();
        public ObservableCollection<String> misChats = new ObservableCollection<String>();
        public MenuPrincipalUsuario()
        {
            InitializeComponent();
        }

        private void buttonEstados_Click(object sender, RoutedEventArgs e)
        {
            eventoEstados?.Invoke(this, e);
        }

        private void buttonPerfil_Click(object sender, RoutedEventArgs e)
        {
            eventoPerfil?.Invoke(this, e);
        }

        private void buttonAgregarAmigo_Click(object sender, RoutedEventArgs e)
        {
           
            eventoAgregarAmigo?.Invoke(this, e);

        }

        private void buttonChatGrupal_Click(object sender, RoutedEventArgs e)
        {
            eventoChatGrupal?.Invoke(this, e);
        }

        private void buttonCerrarSesion_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.usuarioLogeado = null;
            eventCerrarSesion?.Invoke(this, e);
        }

        private void VerImgChat_Click(object sender, RoutedEventArgs e)
        {
            eventVerImagenesDelChat?.Invoke(this, e);
        }

        private void LabelMiNombreDeUsuario_Loaded(object sender, RoutedEventArgs e)
        {
            LabelMiNombreDeUsuario.Content = MainWindow.usuarioLogeado.nombreUsuario;
        }


        private void detenerAudio(object sender, RoutedEventArgs e)
        {
            SaveFileDialog CajaDeDiaologoGuardar = new SaveFileDialog();
            CajaDeDiaologoGuardar.AddExtension = true;
            CajaDeDiaologoGuardar.FileName = "Audio.wav";
            CajaDeDiaologoGuardar.Filter = "Sonido (*.wav)|*.wav";
            CajaDeDiaologoGuardar.ShowDialog();
            if (!string.IsNullOrEmpty(CajaDeDiaologoGuardar.FileName))
            {
                url = CajaDeDiaologoGuardar.FileName;

                Grabar("save recsound " + CajaDeDiaologoGuardar.FileName, "", 0, 0);
                Grabar("close recsound", "", 0, 0);
                MessageBox.Show("Archivo Guardado en:" + CajaDeDiaologoGuardar.FileName);

            }
        }


        [DllImport("winmm.dll", EntryPoint = "mciSendStringA", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        private static extern int Grabar(string Comando, string StringRetono, int Longitud, int hwndCallback);
        private void grabarAudio(object sender, RoutedEventArgs e)
        {
            Grabar("open new Type waveaudio Alias recsound", "", 0, 0);
            Grabar("record recsound", "", 0, 0);

        }

        private void reproducir(object sender, RoutedEventArgs e)
        {
            ReproductoWav.SoundLocation = url;
            ReproductoWav.Play();
        }

        private void eliminar(object sender, RoutedEventArgs e)
        {

        }

        private void listChats_Loaded(object sender, RoutedEventArgs e)
        {            
                string url = "http://localhost:5000/chat/obtenerChatsDeUsuario?nombreUsuario=" + MainWindow.usuarioLogeado.nombreUsuario;

                RestClient client = new RestClient(url);
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                try
                {
                    IRestResponse response = client.Execute(request);
                    var chatsDeserializados = JsonConvert.DeserializeObject<List<Chat>>(response.Content);
                    
                    if (misChats.Count > 0) misChats.Clear();
                    
                    foreach (var chat in chatsDeserializados)
                    {
                        misChats.Add(chat.Chat_nombreChat);
                    }
                listChats.ItemsSource = misChats;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }            
        }

        private void listChats_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LabelNombreAmigo.Content = listChats.SelectedItem;
            nombreChat_Actual = listChats.SelectedItem.ToString();
            textboxMensaje.Text = "";

            string url = "http://localhost:5000/chat/obtenerMensajesChat?Chat_nombreChat="+ listChats.SelectedItem;

            RestClient client = new RestClient(url);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            try
            {
                IRestResponse response = client.Execute(request);
                var mensajesDeserializados = JsonConvert.DeserializeObject<List<Mensaje>>(response.Content);
                
                if (mensajes.Count >0) mensajes.Clear();
                
                foreach( var msj in mensajesDeserializados)
                {
                    mensajes.Add(msj);
                }
                listViewMensajes.ItemsSource = mensajes;
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void buttonEnviarMensaje_Click(object sender, RoutedEventArgs e)
        {;
            var fecha = DateTime.Now.ToString("yyyy-MM-dd");
            string url = "http://localhost:5000/chat/enviarMensaje?fecha=" +fecha  +
            "&favorito=" + 0 + "&mensaje=" + textboxMensaje.Text + "&tipoMensaje=" + "texto" + "&idMensajeImagen=" + 0 +
                "&mensajeAudio=" + 0 + "&UsuarioChat_nombreUsuario=" + MainWindow.usuarioLogeado.nombreUsuario + "&Chat_nombreChat=" +
                nombreChat_Actual;
            MessageBox.Show(url);
            RestClient client = new RestClient(url);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            try
            {
                IRestResponse response = client.Execute(request);
                if (response.ResponseStatus != ResponseStatus.Completed)
                    MessageBox.Show(response.ResponseStatus + " '" + response.StatusCode.ToString() +
                               "' Sucedió algo mal, intente más tarde");
                else if(response.Content.Equals("1"))
                {
                    Mensaje mensaje = new Mensaje
                    {
                        date = fecha,
                        favorito = 0,
                        mensaje = textboxMensaje.Text,
                        tipoMensaje = "texto",
                        idMensajeImagen = 0,
                        mensajeAudio = 0,
                        UsuarioChat_nombreUsuario = MainWindow.usuarioLogeado.nombreUsuario,
                        Chat_nombreChat = nombreChat_Actual
                    };
                    mensajes.Add(mensaje);
                }
                else
                    MessageBox.Show("no se pudo enviar tu mensaje");
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
