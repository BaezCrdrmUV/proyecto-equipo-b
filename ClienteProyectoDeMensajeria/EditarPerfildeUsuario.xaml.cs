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
        public EventHandler eventoCancelarEditarPerfil;
        public EditarPerfildeUsuario()
        {
            InitializeComponent();
        }

        private void buttonCancelar_Click(object sender, RoutedEventArgs e)
        {
            eventoCancelarEditarPerfil?.Invoke(this, e);
        }
    }
}
