﻿using ClienteProyectoDeMensajeria.ClasesReutilizables;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MessageBox = System.Windows.MessageBox;

namespace ClienteProyectoDeMensajeria
{
    /// <summary>
    /// Lógica de interacción para RegistroCuenta.xaml
    /// </summary>
    public partial class RegistroCuenta : System.Windows.Controls.UserControl
    {
        private int genero;
        private string imagenPerfil_Base64;
        public EventHandler eventoCancelarRegistro;
        public EventHandler eventoRegistro;
        int idFotoPerfil = 0;
        public RegistroCuenta()
        {
            InitializeComponent();
        }

        private void buttonCanelar_Click(object sender, RoutedEventArgs e)
        {
            eventoCancelarRegistro?.Invoke(this, e);
        }

        private void buttonRegistrar_Click(object sender, RoutedEventArgs e)
        {

            if (CamposLlenosRegistro())
            {
                if (Validacion.EsCorreoElectronicoValido(textBoxCorreo.Text))
                {
                    registrarMiImagenPerfil();
                    ///registrarMiImagenPerfil();
                    string nombreUsuario = textBoxUsuario.Text;
                    string correo = textBoxCorreo.Text;
                    string contrasenia = textBoxContrasena.Password;
                    string telefono = textBoxTelefono.Text;
                      

                    string url = "http://localhost:5000/cuenta/registrarUsuario?nombreUsuario=" + nombreUsuario + "&correo=" + correo + "&contrasena=" + contrasenia +
                        "&telefono=" + telefono + "&idFotoCuentaUsuario=" + idFotoPerfil + "&Genero_idGenero=" + genero;
                    var client = new RestClient(url);
                    client.Timeout = -1;
                    RestRequest request = new RestRequest(Method.POST);

                    try
                    {
                        IRestResponse response = client.Execute(request);
                        if (response.ResponseStatus != ResponseStatus.Completed)
                            MessageBox.Show(response.ResponseStatus + " '" + response.StatusCode.ToString() +
                                "' Sucedió algo mal, intente más tarde");
                        else if (response.Content.Equals("1"))
                        {
                            MessageBox.Show("¡Bienvenido a WhatsApp Chacalón!\n Ahora logueate.");
                            eventoRegistro?.Invoke(this, e);
                        }
                        else
                            MessageBox.Show("Los datos son inválidos");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                    textBoxCorreo.BorderBrush = System.Windows.Media.Brushes.Red;
            }
            else
            {
                MessageBox.Show("Hay campos vacíos");
            }

        }

        private void registrarMiImagenPerfil()
        {
            System.Net.ServicePointManager.ServerCertificateValidationCallback = (senderX, certificate, chain, sslPolicyErrors) => { return true; };
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:5000/multimedia/registrarFotoCuentaUsuario");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = "{\"stringBase64\":"+"\""+imagenPerfil_Base64+"\"}";
                MessageBox.Show(json);
                streamWriter.Write(json);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                string result2 = result;
                idFotoPerfil = Int32.Parse(result2);
                MessageBox.Show(""+idFotoPerfil);
            }
        }

        private void buttonCargarFoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog exploradorArchivos = new OpenFileDialog
            {
                Filter = "*.jpg | *.jpg",
                Title = "Imagen del producto",
                RestoreDirectory = true
            };
            
            DialogResult rutaImagen = exploradorArchivos.ShowDialog();

            if (rutaImagen == System.Windows.Forms.DialogResult.OK)
            {
                string imagePath = exploradorArchivos.FileName;
                Uri FilePath = new Uri(imagePath);
                imagenPerfil.Source = new BitmapImage(FilePath);
            }
            try
            {
                byte[] imagen;
                byte[] buffer = null;
                int longitud;
                var PathfileName = string.Empty;


                using (var fs = new FileStream(exploradorArchivos.FileName, FileMode.Open, FileAccess.Read))
                {
                    buffer = new byte[fs.Length];
                    fs.Read(buffer, 0, (int)fs.Length);
                    longitud = (int)fs.Length;
                }
                imagen = buffer;                
                imagenPerfil_Base64 = Convert.ToBase64String(imagen);                    
                    
                
            }
            catch (Exception error)
            {
                Console.WriteLine(error.GetType() + " | | " + error.Message);
            }
        }

        private void comboBoxGenero_Loaded(object sender, RoutedEventArgs e)
        {
            comboBoxGenero.Items.Add("Masculino");
            comboBoxGenero.Items.Add("Femenino");
        }

        private void comboBoxGenero_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBoxGenero.SelectedValue.ToString() == "Masculino")
                genero = 1;
            else if (comboBoxGenero.SelectedValue.ToString() == "Femenino")
                genero = 2;
        }

        private Boolean CamposLlenosRegistro()
        {
            if (textBoxUsuario.Text.Length > 0 && textBoxCorreo.Text.Length > 0 && textBoxTelefono.Text.Length > 0
                && textBoxContrasena.Password.Length > 0 && (comboBoxGenero.SelectedIndex > -1))
                return true;
            else
                return false;
        }
    }
}
