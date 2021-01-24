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
    /// Lógica de interacción para MenuPrincipalUsuario.xaml
    /// </summary>
    public partial class MenuPrincipalUsuario : UserControl
    {
        public EventHandler eventoEstados;
        public EventHandler eventoPerfil;
        public EventHandler eventoChatGrupal;
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
    }
}
