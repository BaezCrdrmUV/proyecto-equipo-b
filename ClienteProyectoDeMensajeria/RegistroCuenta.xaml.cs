using ClienteProyectoDeMensajeria.ClasesReutilizables;
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
using System.Windows.Shapes;

namespace ClienteProyectoDeMensajeria
{
    /// <summary>
    /// Lógica de interacción para RegistroCuenta.xaml
    /// </summary>
    public partial class RegistroCuenta : UserControl
    {
        private int genero;
        public EventHandler eventoCancelarRegistro;
        public EventHandler eventoRegistro;
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
                    string nombreUsuario = textBoxUsuario.Text;
                    string correo = textBoxCorreo.Text;
                    string contrasenia = textBoxContrasena.Password;
                    string telefono = textBoxTelefono.Text;
                    int idFotoPerfil = 0; // ver que pedo aqui      

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

        private void buttonCargarFoto_Click(object sender, RoutedEventArgs e)
        {

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
