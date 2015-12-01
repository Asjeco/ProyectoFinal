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

            //instanciar bd

            /*  if (Regex.IsMatch(txtNombre.Text, @"^[a-zA-Z]+$"))
              {
                  if (Regex.IsMatch(txtSueldo.Text, @"\d+$"))
                  {*/
            HelpMeAPP db = new HelpMeAPP();
            Usuario usu = new Usuario();
            usu.Nombre = txtNombre.Text;
            usu.Ubicacion = txtUbicacion.Text;
           
           
            

            db.Usuarios.Add(usu);
            db.SaveChanges();
            Window_Loaded_1(sender, e);

            /* }
                else { MessageBox.Show("Solo numeros #sueldo"); }
            }
            else { MessageBox.Show("Solo letras #Nombre"); }   */
        }

        private void btnVerTodos_Click(object sender, RoutedEventArgs e)
        {
            HelpMeAPP db = new HelpMeAPP();
            var registros = from s in db.Usuarios
                            select s;
            dbGrid.ItemsSource = registros.ToList();
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            HelpMeAPP db = new HelpMeAPP();
            int id = int.Parse(cbbID.Text);
            var registros = from s in db.Usuarios
                            where s.idUsuario == id
                            select new
                            {
                                s.Nombre,
                                s.Ubicacion
                                
                            };
            dbGrid.ItemsSource = registros.ToList();
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            HelpMeAPP db = new HelpMeAPP();
            cbbID.ItemsSource = db.Usuarios.ToList();
            cbbID.DisplayMemberPath = "idUsuario";
            cbbID.SelectedValuePath = "idUsuario";
        }

        private void btnBorrar_Click(object sender, RoutedEventArgs e)
        {
            HelpMeAPP db = new HelpMeAPP();
            int id = int.Parse(cbbID.Text);
            var usu = db.Usuarios
                         .SingleOrDefault(x => x.idUsuario == id);

            if (usu != null)
            {
                db.Usuarios.Remove(usu);
                db.SaveChanges();

            }
        }
    }
}
