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
    /// Interaction logic for OrdenesServicios.xaml
    /// </summary>
    public partial class OrdenesServicios : Window
    {

        private List<Servicio> ServiciosNuevos;  
        public OrdenesServicios()
        {
            InitializeComponent();
            ServiciosNuevos = new List<Servicio>();
        }

        

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {

               HelpMeAPP db = new HelpMeAPP();
                //parse the product code as int from the TextBox
               int id =  (int)cbbServicio.SelectedValue;
                //We query the database for the product
                Servicio p = db.Servicios.SingleOrDefault(x => x.idServicio == id);

              
                ServiciosNuevos.Add(new Servicio()
                {
                    idServicio = p.idServicio,
                    Nombre = p.Nombre,
                    Descripcion = p.Descripcion,

                    precio = p.precio
                });

                BindDataGrid();
             
        }

        private void BindDataGrid()
        {
            //we query the array cart and add a new calculated field Subtotal
            var cartItems = from s in ServiciosNuevos
                            select new
                            {
                                s.idServicio,
                                s.Nombre,
                                s.Descripcion,
                               
                                s.precio
                              
                            };

            //refresh dataGridview-----------
            dgServicios.ItemsSource = null;
            dgServicios.ItemsSource = cartItems;

            //we add the total with sum(price) and apply a currency formating.
            lblSubtotal.Content = string.Format("Subtotal: {0}", ServiciosNuevos.Sum(x => x.precio ).ToString("C"));
            lblIVA.Content = string.Format("IVA 16%: {0}", ServiciosNuevos.Sum(x => x.precio * 0.16).ToString("C"));
            lblTotal.Content = string.Format("Total: {0}", ServiciosNuevos.Sum(x => x.precio * 1.16).ToString("C"));
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            HelpMeAPP db = new HelpMeAPP();
            cbbCliente.ItemsSource = db.Usuarios.ToList();
            cbbCliente.DisplayMemberPath = "Nombre";
            cbbCliente.SelectedValuePath = "idUsuario";

            cbbProveedor.ItemsSource = db.Proveedores.ToList();
            cbbProveedor.DisplayMemberPath = "Nombre";
            cbbProveedor.SelectedValuePath = "idProveedor";

            cbbServicio.ItemsSource = db.Servicios.ToList();
            cbbServicio.DisplayMemberPath = "Nombre";
            cbbServicio.SelectedValuePath = "idServicio";

        }

        private void btnGenerar_Click(object sender, RoutedEventArgs e)
        {
           
            if (ServiciosNuevos.Count > 0 && cbbProveedor.SelectedIndex > -1 && cbbCliente.SelectedIndex > -1)
            {
           
                using (HelpMeAPP db = new HelpMeAPP())
                {
                    
                    using (var dbTransaction = db.Database.BeginTransaction())
                    {
                        try
                        {
                            
                            OrdenServicio orden = new OrdenServicio();
                            orden.fecha = DateTime.Now;
                         
                            orden.Proveedor = db.Proveedores.SingleOrDefault(s => s.idProveedor == (int)cbbProveedor.SelectedValue);
                            orden.Usuario = db.Usuarios.SingleOrDefault(s => s.idUsuario == (int)cbbCliente.SelectedValue);

                          
                            foreach (var ser in ServiciosNuevos)
                            {
                                
                                Servicio p = db.Servicios.SingleOrDefault(i => i.idServicio == ser.idServicio);
                                orden.ListaServicios.Add(p);

                            }

                           
                            db.Ordenes.Add(orden);
                            //Save Changed to the database
                            db.SaveChanges();
                            //Make the changes permanent 
                            dbTransaction.Commit();
                            
                            MessageBox.Show(string.Format("Transaction #{0}  Saved", orden.idOrden), "Success", MessageBoxButton.OK,
                                MessageBoxImage.Information);
                        }
                        catch
                        {
                            //if an error is produced, we rollback everything
                            dbTransaction.Rollback();
                            //We notify the user of the error
                            MessageBox.Show("Transaction Error, unable to generate invoice", "Fatal Error", MessageBoxButton.OK,
                                MessageBoxImage.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select at least one product and a Sales Person", "Data Error",
                    MessageBoxButton.OK, MessageBoxImage.Stop);
            }
        }
    }
}
