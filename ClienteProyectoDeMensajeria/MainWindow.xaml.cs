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
            string correoUsuario = correoU.Text.Trim();
            string contraseñaUsuario = contraseñaU.Password.Trim();
            
            if (ValidarDatosIngresados(correoUsuario, contraseñaUsuario))
            {
                MessageBox.Show("Datos correctos");
                
            }
            else
            {
                MessageBox.Show("Datos invalidos");
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
