using System;
using ProyectoFinal.MiBD;
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

namespace ProyectoFinal
{
    /// <summary>
    /// Interaction logic for IngresarUsuario.xaml
    /// </summary>
    public partial class IngresarUsuario : Window
    {
        public IngresarUsuario()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            HelpMeAPP db = new HelpMeAPP();
            Usuario usu = new Usuario();
            usu.Nombre = txtNombre.Text;
            usu.Ubicacion = txtUbicacion.Text;
           
           
            

            db.Usuarios.Add(usu);
            db.SaveChanges();
        }
    }
}
