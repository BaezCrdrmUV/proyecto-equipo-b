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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ClienteProyectoDeMensajeria
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void iniciarSesion(object sender, RoutedEventArgs e)
        {
            var url = $"http://localhost:5000/estado";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            MessageBox.Show("Entró al método");
            System.Net.ServicePointManager.ServerCertificateValidationCallback = (senderX, certificate, chain, sslPolicyErrors) => { return true; };
            try
            {
                MessageBox.Show("Entró al try");
                using (WebResponse response = request.GetResponse())
                {
                    MessageBox.Show("Primer using");
                    using (Stream strReader = response.GetResponseStream())
                    {
                        MessageBox.Show("Segundo using");
                        if (strReader == null) return;
                        MessageBox.Show("Despues del if");
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            MessageBox.Show("Último using");
                            string responseBody = objReader.ReadToEnd();
                            // Do something with responseBody
                            Console.WriteLine(responseBody);
                            MessageBox.Show(responseBody);
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                MessageBox.Show(ex+"");
            }

        }

        private void registrarUsuario(object sender, RoutedEventArgs e)
        {

        }

        private bool ValidarDatosIngresados(string nombreUsuario, string contraseña)
        {
            bool datosValidos = false;

            if (nombreUsuario != "" && contraseña != "")
            {
                datosValidos = true;
                return datosValidos;
            }
            else
            {
                return datosValidos;
            }
        }
    }
}
