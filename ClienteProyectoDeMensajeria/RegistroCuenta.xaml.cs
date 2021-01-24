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
            eventoRegistro?.Invoke(this, e);
        }
    }
}
