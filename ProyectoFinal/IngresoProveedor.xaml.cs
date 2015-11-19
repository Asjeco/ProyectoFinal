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
                    pro.Nombre = txtNombre.Text;
                    pro.Direcc = txtDirecc.Text;
                    pro.Giro = txtGiro.Text;
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
               /* }
                else { MessageBox.Show("Solo numeros #sueldo"); }
            }
            else { MessageBox.Show("Solo letras #Nombre"); }   */

        }
    }
}
