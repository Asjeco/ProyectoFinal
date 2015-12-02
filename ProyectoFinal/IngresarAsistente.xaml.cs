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
using System.Text.RegularExpressions;

namespace ProyectoFinal
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class IngresarAsistente : Window
    {
        public IngresarAsistente()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            //instanciar bd

             if (Regex.IsMatch(txtNombre.Text, @"^[a-zA-Z]+$"))
              {
                  if (Regex.IsMatch(txtTele.Text, @"\d+$"))
                  {
                      if (cbbProveedor.SelectedIndex > -1)
                    {
            HelpMeAPP db = new HelpMeAPP();
            Asistente asis = new Asistente();
            asis.idProveedor = (int)cbbProveedor.SelectedValue;
            asis.Nombre = txtNombre.Text;
            asis.telefono = txtTele.Text;
           
       

            db.Asistentes.Add(asis);
            db.SaveChanges();
            Window_Loaded_1(sender, e);

                    }
                      else { MessageBox.Show("Elige un Proveedor"); }
             }
             else { MessageBox.Show("Solo numeros #Telefono"); }
         }
         else { MessageBox.Show("Solo letras #Nombre"); }   
        }

        private void Grid_Loaded_1(object sender, RoutedEventArgs e)
        {

        }

        public void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            //Combo de los Proveedores
            HelpMeAPP db = new HelpMeAPP();
            cbbProveedor.ItemsSource = db.Proveedores.ToList();
            cbbProveedor.DisplayMemberPath = "Nombre";
            cbbProveedor.SelectedValuePath = "idProveedor";

            //Combo de los Asistentes
            
            cbbId.ItemsSource = db.Asistentes.ToList();
            cbbId.DisplayMemberPath = "idAsistente";
            cbbId.SelectedValuePath = "idAsistente";
        }

        private void btnProveedor_Click(object sender, RoutedEventArgs e)
        {
            IngresoProveedor ventana = new IngresoProveedor();
            ventana.Show();

        }

        private void btnVerTodos_Click(object sender, RoutedEventArgs e)
        {
            HelpMeAPP db = new HelpMeAPP();
            var registros = from s in db.Asistentes
                            select s;
            dbGrid.ItemsSource = registros.ToList();
        }

        private void btnBorrar_Click(object sender, RoutedEventArgs e)
        {
            HelpMeAPP db = new HelpMeAPP();
            int id = int.Parse(cbbId.Text);
            var asis = db.Asistentes
                         .SingleOrDefault(x => x.idAsistente == id);

            if (asis != null)
            {
                db.Asistentes.Remove(asis);
                db.SaveChanges();

            }
        }
    }
}
