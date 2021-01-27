using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
        public EventHandler eventoChatGrupal;
        public EventHandler eventCerrarSesion;
        public EventHandler eventVerImagenesDelChat;
        String url;
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {

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
    }
}
