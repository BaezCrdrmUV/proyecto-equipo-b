using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
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
    /// <summary>
    /// Lógica de interacción para AgregarAmigo.xaml
    /// </summary>
    public partial class AgregarAmigo : UserControl
    {
        public EventHandler eventoCancelar;
       
        public AgregarAmigo()
        {
            InitializeComponent();
        }

        private void buttonAgregar_Click(object sender, RoutedEventArgs e)
        {
            string nombreDeUsuario = textBoxNombreUsuario.Text;

            string urlValidarUsuario = "http://localhost:5000/cuenta/validarExistencia?nombreUsuario=" + nombreDeUsuario;

            RestClient client = new RestClient(urlValidarUsuario);
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
                    string urlAgregarAmigo = "http://localhost:5000/chat/agregarAmigo?nombreUsuario="+ 
                        MainWindow.usuarioLogeado.nombreUsuario + "&amigoNombreUsuario=" + nombreDeUsuario;
                    client = new RestClient(urlAgregarAmigo);
                    client.Timeout = -1;
                    var requestAgregarAmigo = new RestRequest(Method.POST);
                    IRestResponse responseAgregarAmigo = client.Execute(requestAgregarAmigo);
                    MessageBox.Show("agregado? " +response.Content);
                }
                else
                    MessageBox.Show("No existe este usuario en WhatsApp Chacalón");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonCancelar_Click(object sender, RoutedEventArgs e)
        {
            eventoCancelar?.Invoke(this, e);

        }

        private void listAmigos_Loaded(object sender, RoutedEventArgs e)
        {
            if (listAmigos.Items.Count > 0) listAmigos.Items.Clear();
            string url = "http://localhost:5000/chat/obtenerAmigos?nombreUsuario=" + MainWindow.usuarioLogeado.nombreUsuario;
            RestClient client = new RestClient(url);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);

            try
            {
                IRestResponse response = client.Execute(request);
                var amigos = Json.Decode(response.Content);
                foreach (var amigo in amigos)
                {
                    listAmigos.Items.Add(amigo.amigoNombreUsuario);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
