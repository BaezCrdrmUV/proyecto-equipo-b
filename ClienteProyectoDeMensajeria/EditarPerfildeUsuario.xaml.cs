using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Lógica de interacción para EditarPerfildeUsuario.xaml
    /// </summary>
    public partial class EditarPerfildeUsuario : UserControl
    {
        private int genero;
        public EventHandler eventoCancelarEditarPerfil;
        public EditarPerfildeUsuario()
        {
            InitializeComponent();
        }

        private void buttonGuardar_Click(object sender, RoutedEventArgs e)
        {
            string nombreUsuario = textBoxUsuario.Text;
            string correo = textBoxCorreo.Text;
            string contrasenia = textBoxContrasena.Password;
            string telefono = textBoxTelefono.Text;
            int idFotoPerfil = 0;

            string url = "http://localhost:5000/cuenta/modificarUsuario?idCuenta="+ MainWindow.usuarioLogeado.idCuenta+ "&nombreUsuario=" + nombreUsuario + "&correo=" + correo + "&contrasena=" + contrasenia +
                "&telefono=" + telefono + "&idFotoCuentaUsuario=" + idFotoPerfil + "&Genero_idGenero=" + genero;
            var client = new RestClient(url);
            client.Timeout = -1;
            RestRequest request = new RestRequest(Method.PUT);
            try
            {
                IRestResponse response = client.Execute(request);
                if (response.ResponseStatus != ResponseStatus.Completed)
                    MessageBox.Show(response.ResponseStatus + " " + response.StatusCode.ToString() +
                        "Sucedió algo mal, intente más tarde");                
                else if(response.Content.Equals("1"))
                {                                    
                    MainWindow.usuarioLogeado.idFotoCuentaUsuario = 0; // ver que pedo AQUI
                    MainWindow.usuarioLogeado.nombreUsuario = nombreUsuario;
                    MainWindow.usuarioLogeado.telefono = telefono;
                    MainWindow.usuarioLogeado.correo = correo;
                    MainWindow.usuarioLogeado.contrasena = contrasenia;
                    MainWindow.usuarioLogeado.Genero_idGenero = genero;
                    MessageBox.Show("Se guardaron los cambios correctamente");                    
                }
                else
                    MessageBox.Show("No se pudo guardar los cambios");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonCancelar_Click(object sender, RoutedEventArgs e)
        {
            textBoxContrasena.Password = "";
            eventoCancelarEditarPerfil?.Invoke(this, e);
        }

        private void buttonCargarFoto_Click(object sender, RoutedEventArgs e)
        {

        }

        private void comboBoxGenero_Loaded(object sender, RoutedEventArgs e)
        {
            comboBoxGenero.Items.Add("Masculino");
            comboBoxGenero.Items.Add("Femenino");

            if (MainWindow.usuarioLogeado.Genero_idGenero == 1)
                comboBoxGenero.SelectedItem = "Masculino";
            else if (MainWindow.usuarioLogeado.Genero_idGenero == 2)
                comboBoxGenero.SelectedItem = "Femenino";
        }

        private void comboBoxGenero_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBoxGenero.SelectedValue.ToString() == "Masculino")
                genero = 1;
            else if (comboBoxGenero.SelectedValue.ToString() == "Femenino")
                genero = 2;
        }

        private void imagenPerfil_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void textBoxUsuario_Loaded(object sender, RoutedEventArgs e)
        {
            textBoxUsuario.Text = MainWindow.usuarioLogeado.nombreUsuario;                 
        }

        private void textBoxCorreo_Loaded(object sender, RoutedEventArgs e)
        {
            textBoxCorreo.Text = MainWindow.usuarioLogeado.correo;
        }

        private void textBoxTelefono_Loaded(object sender, RoutedEventArgs e)
        {
            textBoxTelefono.Text = MainWindow.usuarioLogeado.telefono;
        }
    }
}
