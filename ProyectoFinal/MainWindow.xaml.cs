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

namespace ProyectoFinal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnAltaProveedor_Click(object sender, RoutedEventArgs e)
        {
            IngresoProveedor ventana = new IngresoProveedor();
            ventana.Show();
        }

        private void btnUsuario_Click(object sender, RoutedEventArgs e)
        {
            IngresarUsuario ventana1 = new IngresarUsuario();
            ventana1.Show();
        }

        private void btnServicio_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
