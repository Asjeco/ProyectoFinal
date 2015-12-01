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
    /// Interaction logic for IngresoProveedor.xaml
    /// </summary>
    public partial class IngresoProveedor : Window
    {
        public IngresoProveedor()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            //instanciar bd

          /*  if (Regex.IsMatch(txtNombre.Text, @"^[a-zA-Z]+$"))
            {
                if (Regex.IsMatch(txtSueldo.Text, @"\d+$"))
                {*/
                    HelpMeAPP db = new HelpMeAPP();
                    Proveedor pro = new Proveedor();
                   // pro.idProveedor = (int)cbbDepartamentos.SelectedValue;
                    pro.Nombre = txtNombre.Text;
                    pro.Direcc = txtDirecc.Text;
                    pro.Giro = cbbGiro.Text;
                    pro.Usuario = txtUsuario.Text;
                    pro.Contra = txtContra.Text;
                    if (cbbEdoCuenta.SelectedIndex == 0) {
                        pro.edoCta = 1;
                    }else
                        if (cbbEdoCuenta.SelectedIndex == 1)
                        {
                            pro.edoCta = 0;
                        }
                   // pro.edoCta = Byte.Parse(txtEdoCuenta.Text);
                 //   emp.DepartamentoId = (int)cbbDepartamentos.SelectedValue;

                    db.Proveedores.Add(pro);
                    db.SaveChanges();
                    Window_Loaded_1(sender, e);
               /* }
                else { MessageBox.Show("Solo numeros #sueldo"); }
            }
            else { MessageBox.Show("Solo letras #Nombre"); }   */

        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            HelpMeAPP db = new HelpMeAPP();
            int id = int.Parse(cbbId.Text);
            var registros = from s in db.Proveedores
                            where s.idProveedor == id
                            select new
                            {
                                s.Nombre,
                                s.Direcc,
                                s.Giro,
                                s.Usuario,
                                s.Contra,
                                s.edoCta
                            };
            dbGrid.ItemsSource = registros.ToList();
        }

        

        private void btnBorra_Click(object sender, RoutedEventArgs e)
        {
            HelpMeAPP db = new HelpMeAPP();
            int id = int.Parse(cbbId.Text);
            var pro = db.Proveedores
                         .SingleOrDefault(x => x.idProveedor == id);

            if (pro != null)
            {
                db.Proveedores.Remove(pro);
                db.SaveChanges();

            }
        }

        private void btnTodos_Click(object sender, RoutedEventArgs e)
        {
            HelpMeAPP db = new HelpMeAPP();
            var registros = from s in db.Proveedores
                            select s;
            dbGrid.ItemsSource = registros.ToList();
        }

        private void Grid_Loaded_1(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            HelpMeAPP db = new HelpMeAPP();
            cbbId.ItemsSource = db.Proveedores.ToList();
            cbbId.DisplayMemberPath = "idProveedor";
            cbbId.SelectedValuePath = "idProveedor";
        }
    }
}
