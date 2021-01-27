
using ClienteProyectoDeMensajeria.ClasesReutilizables;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;
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
        public static dynamic usuarioLogeado;
        RegistroCuenta userControlRegistroCuenta;
        MenuPrincipalUsuario UserControlPrincipal = new MenuPrincipalUsuario();
        Estados UserControlEstados = new Estados();
        EditarPerfildeUsuario UserControlEditarPerfil = new EditarPerfildeUsuario();
        AgregarAmigo UserControlAgregarAmigo = new AgregarAmigo();
        ChatGrupal UserControlChatGrupal = new ChatGrupal();
        VerImagenesDelChat UserControlImagenesDelChat = new VerImagenesDelChat();
        public MainWindow()
        {
            InitializeComponent();
            UserControlPrincipal.eventoEstados += EventoVerEstados;
            UserControlPrincipal.eventoPerfil += EventoVerPerfil;
            UserControlPrincipal.eventoAgregarAmigo += EventoVerAgregarAmigo;
            UserControlPrincipal.eventoChatGrupal += EventoVerChatGrupal;
            UserControlPrincipal.eventCerrarSesion += EventoCerrarSesion;
            UserControlPrincipal.eventVerImagenesDelChat += EventoVerImagenesDelChat;

            UserControlEstados.eventoCerrarEstados += EventoCerrarEstados;

            UserControlEditarPerfil.eventoCancelarEditarPerfil += EventoCancelarEditarPerfil;

            UserControlAgregarAmigo.eventoCancelar += EventoCancelarAgregarAmigo;

            UserControlChatGrupal.eventoCancelarChatGrupal += EventoCancelarChatGrupal;

            UserControlImagenesDelChat.eventoCerrarImagenesDelChat += EventoCerrarImagenesDelChat;
        }

        private void iniciarSesion(object sender, RoutedEventArgs e)
        {
            if (ValidarDatosIngresados())
            {
                if (Validacion.EsCorreoElectronicoValido(textBoxCorreo.Text))
                {                    
                    string correo = textBoxCorreo.Text;
                    string contrasena = textboxContrasena.Password;
                    string url = "http://localhost:5000/cuenta/login?correo=" + correo + "&contrasena=" + contrasena;

                    RestClient client = new RestClient(url);
                    client.Timeout = -1;
                    var request = new RestRequest(Method.POST);
                    request.AddParameter("text/plain", "", ParameterType.RequestBody);
                    try
                    {
                        IRestResponse response = client.Execute(request);                        
                        if (response.ResponseStatus != ResponseStatus.Completed)
                            MessageBox.Show(response.ResponseStatus + " '" + response.StatusCode.ToString() +
                                "' Sucedió algo mal, intente más tarde");
                        else if (response.Content.Length == 0)
                        {
                            MessageBox.Show("Los datos son inválidos");
                        }
                        else
                        {
                            usuarioLogeado = Json.Decode(response.Content);
                            DesaparecerComponentes();
                            UserControlPrincipal.Visibility = Visibility.Visible;
                            gridPrincipal.Children.Add(UserControlPrincipal);
                        }
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
                textBoxCorreo.BorderBrush = System.Windows.Media.Brushes.Red;
                textboxContrasena.BorderBrush = System.Windows.Media.Brushes.Red;
            }
                                  
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
                            DesaparecerComponentes();
                            UserControlPrincipal.Visibility = Visibility.Visible;
                            gridPrincipal.Children.Add(UserControlPrincipal);
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                MessageBox.Show(ex+"");
            }*/
        }

        private bool ValidarDatosIngresados()
        {           
            if (textBoxCorreo.Text.Length > 0 && textboxContrasena.Password.Length > 0)
            {
                return true;
            }
            else            
                return false;           
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
            AparecerComponentes();            
            gridPrincipal.Children.Remove(userControlRegistroCuenta);
        }

        private void EventoCancelarRegistro(object sender, EventArgs e)
        {
            gridPrincipal.Children.Remove(userControlRegistroCuenta);
            AparecerComponentes();
        }

        private void EventoVerEstados(object sender, EventArgs e)
        {
            gridPrincipal.Children.Remove(UserControlPrincipal);
            UserControlEstados.Visibility = Visibility.Visible;
            gridPrincipal.Children.Add(UserControlEstados);
        }

        private void EventoVerPerfil(object sender, EventArgs e)
        {
            UserControlEditarPerfil.Visibility = Visibility.Visible;
            gridPrincipal.Children.Remove(UserControlPrincipal);
            gridPrincipal.Children.Add(UserControlEditarPerfil);
        }

        private void EventoVerAgregarAmigo(object sender, EventArgs e)
        {
            UserControlAgregarAmigo.Visibility = Visibility.Visible;
            gridPrincipal.Children.Remove(UserControlPrincipal);
            gridPrincipal.Children.Add(UserControlAgregarAmigo);
        }

        private void EventoVerChatGrupal(object sender, EventArgs e)
        {
            UserControlChatGrupal.Visibility = Visibility.Visible;
            gridPrincipal.Children.Remove(UserControlPrincipal);
            gridPrincipal.Children.Add(UserControlChatGrupal);
        }

        private void EventoVerImagenesDelChat(object sender, EventArgs e)
        {
            UserControlImagenesDelChat.Visibility = Visibility.Visible;
            gridPrincipal.Children.Remove(UserControlPrincipal);
            gridPrincipal.Children.Add(UserControlImagenesDelChat);
        }

        private void EventoCerrarSesion(object sender, EventArgs e)
        {         
            gridPrincipal.Children.Remove(UserControlPrincipal);
            AparecerComponentes();
        }

        private void EventoCancelarChatGrupal(object sender, EventArgs e)
        {
            gridPrincipal.Children.Remove(UserControlChatGrupal);
            gridPrincipal.Children.Add(UserControlPrincipal);
            UserControlPrincipal.Visibility = Visibility.Visible;
        }

        private void EventoCancelarEditarPerfil(object sender, EventArgs e)
        {
            gridPrincipal.Children.Remove(UserControlEditarPerfil);
            gridPrincipal.Children.Add(UserControlPrincipal);
            UserControlPrincipal.Visibility = Visibility.Visible;
        }

        private void EventoCancelarAgregarAmigo(object sender, EventArgs e)
        {
            gridPrincipal.Children.Remove(UserControlAgregarAmigo);
            gridPrincipal.Children.Add(UserControlPrincipal);
            UserControlPrincipal.Visibility = Visibility.Visible;
        }

        public void EventoCerrarEstados(object sender, EventArgs e)
        {
            gridPrincipal.Children.Remove(UserControlEstados);
            gridPrincipal.Children.Add(UserControlPrincipal);
            UserControlPrincipal.Visibility = Visibility.Visible;
        }

        private void EventoCerrarImagenesDelChat(object sender, EventArgs e)
        {
            gridPrincipal.Children.Remove(UserControlImagenesDelChat);
            gridPrincipal.Children.Add(UserControlPrincipal);
            UserControlPrincipal.Visibility = Visibility.Visible;
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
