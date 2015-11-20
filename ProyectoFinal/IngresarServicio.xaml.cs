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
    /// Interaction logic for IngresarServicio.xaml
    /// </summary>
    public partial class IngresarServicio : Window
    {
        public IngresarServicio()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            HelpMeAPP db = new HelpMeAPP();
            Servicio ser = new Servicio();
            ser.Nombre = txtNombre.Text;
            ser.Descripcion = txbDescripcion.Text;

            ProveedorServicio proser = new ProveedorServicio();
            object x = db.Servicios.ToList();

           // proser.idServicio = x.;
            proser.idProveedor = (int)cbbProveedor.SelectedValue;


            db.Servicios.Add(ser);
            db.SaveChanges();
        }

        private void btnGuardar_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            HelpMeAPP db = new HelpMeAPP();
            cbbProveedor.ItemsSource = db.Proveedores.ToList();
            cbbProveedor.DisplayMemberPath = "Nombre";
            cbbProveedor.SelectedValuePath = "idProveedor";
        }
    }
}
