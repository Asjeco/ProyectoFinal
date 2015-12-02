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
        public OrdenesServicios()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            //If a product code is not empty we search the database
           // if (Regex.IsMatch(TxtProdCode.Text.Trim(), @"^\d+$"))
           // {
            HelpMeAPP db = new HelpMeAPP();
                //parse the product code as int from the TextBox
                int id = int.Parse(TxtProdCode.Text);
                //We query the database for the product
                Product p = db.Products.SingleOrDefault(x => x.Id == id);
                if (p != null) //if product was found
                {
                    //store in a temp variable (if user clicks on add we will need this for the Array)
                    tmpProduct = p;
                    //We display the product information on a label 
                    cprod.Content = string.Format("ID: {0}, Name: {1}, Price: {2}, InStock (Qty): {3}", p.Id, p.Name, p.Price, p.Qty);
                }
                else
                {
                    //if product was not found we display a user notification window
                    MessageBox.Show("Product not found. (Only numbers allowed)", "Product code error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            //}
        }
    }
}
