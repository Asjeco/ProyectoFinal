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
    /// Interaction logic for Servicios.xaml
    /// </summary>
    public partial class Servicios : Window
    {
        public Servicios()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
         if (Regex.IsMatch(txtNombre.Text, @"^[a-zA-Z]+$"))
            {
                if (Regex.IsMatch(txtDescripcion.Text, @"^[a-zA-Z]+$"))
                {
                    if (Regex.IsMatch(txtPrecio.Text, @"^\d+$"))
                {

            HelpMeAPP db = new HelpMeAPP();
            Servicio ser = new Servicio();
          
            ser.Nombre = txtNombre.Text.Trim();
            ser.Descripcion = txtDescripcion.Text.Trim();

            ser.precio = Convert.ToDouble(txtPrecio.Text.Trim());
           
          

            db.Servicios.Add(ser);
            db.SaveChanges();
           // Window_Loaded_1(sender, e);
                }
                    else { MessageBox.Show("Solo Numeros #Precio"); }

               }
                else { MessageBox.Show("Solo letras #Descripcion"); }
            }
            else { MessageBox.Show("Solo letras #Nombre"); }   
        }

        private void btnVerTodos_Click(object sender, RoutedEventArgs e)
        {
            HelpMeAPP db = new HelpMeAPP();
            var registros = from s in db.Servicios
                            select s;
            dbGrid.ItemsSource = registros.ToList();
        }
    }
}
