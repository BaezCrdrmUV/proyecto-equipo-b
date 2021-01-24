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
    public partial class MainWindow : Window
    {
        RegistroCuenta userControlRegistroCuenta;
        MenuPrincipalUsuario UserControlPrincipal = new MenuPrincipalUsuario();
        Estados UserControlEstados = new Estados();
        EditarPerfildeUsuario UserControlPerfil = new EditarPerfildeUsuario();
        ChatGrupal UserControlChatGrupal = new ChatGrupal();
        public MainWindow()
        {
            InitializeComponent();
            UserControlPrincipal.eventoEstados += EventoEstados;
            UserControlPrincipal.eventoPerfil += EventoPerfil;
            UserControlPrincipal.eventoChatGrupal += EventoChatGrupal;
        }

        private void iniciarSesion(object sender, RoutedEventArgs e)
        {            
            DesaparecerComponentes();
            UserControlPrincipal.Visibility = Visibility.Visible;
            gridPrincipal.Children.Add(UserControlPrincipal);
            /*var url = $"http://localhost:5000/estado";
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
            }*/

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

        private void registrarUsuario(object sender, RoutedEventArgs e)
        {
            userControlRegistroCuenta = new RegistroCuenta();
            userControlRegistroCuenta.eventoRegistro += EventoRegistrar;
            userControlRegistroCuenta.eventoCancelarRegistro += EventoCancelarRegistro;
            DesaparecerComponentes();
            userControlRegistroCuenta.Visibility = Visibility.Visible;
            gridPrincipal.Children.Add(userControlRegistroCuenta);
        }        

        public void EventoRegistrar(object sender, EventArgs e)
        {                   
            UserControlPrincipal.Visibility = Visibility.Visible;
            gridPrincipal.Children.Remove(userControlRegistroCuenta);
            gridPrincipal.Children.Add(UserControlPrincipal);
        }

        private void EventoCancelarRegistro(object sender, EventArgs e)
        {
            gridPrincipal.Children.Remove(userControlRegistroCuenta);
            AparecerComponentes();
        }

        private void EventoEstados(object sender, EventArgs e)
        {
            gridPrincipal.Children.Remove(UserControlPrincipal);
            UserControlEstados.Visibility = Visibility.Visible;
            gridPrincipal.Children.Add(UserControlEstados);
        }

        private void EventoPerfil(object sender, EventArgs e)
        {
            UserControlPerfil.Visibility = Visibility.Visible;
            gridPrincipal.Children.Remove(UserControlPrincipal);
            gridPrincipal.Children.Add(UserControlPerfil);
        }

        private void EventoChatGrupal(object sender, EventArgs e)
        {
            UserControlChatGrupal.Visibility = Visibility.Visible;
            gridPrincipal.Children.Remove(UserControlPrincipal);
            gridPrincipal.Children.Add(UserControlChatGrupal);
        }

        public void AparecerComponentes()
        {
            buttonLogin.Visibility = Visibility.Visible;
            buttonRegistrar.Visibility = Visibility.Visible;
            textBoxCorreo.Visibility = Visibility.Visible;
            labelCorreo.Visibility = Visibility.Visible;
            labelContrasena.Visibility = Visibility.Visible;
            textboxContrasena.Visibility = Visibility.Visible;
            labelTitulo.Visibility = Visibility.Visible;
        }

        public void DesaparecerComponentes()
        {
            buttonLogin.Visibility = Visibility.Collapsed;
            buttonRegistrar.Visibility = Visibility.Collapsed;
            textBoxCorreo.Visibility = Visibility.Collapsed;
            labelCorreo.Visibility = Visibility.Collapsed;
            labelContrasena.Visibility = Visibility.Collapsed;
            textboxContrasena.Visibility = Visibility.Collapsed;
            labelTitulo.Visibility = Visibility.Collapsed;
        }
    }
}
