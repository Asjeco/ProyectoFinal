using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.MiBD
{
    public class OrdenServicio
    {

         public OrdenServicio(){

            this.Proveedor = new Proveedor();
            this.ListaServicios = new List<Servicio>();
        }

        [Key]
        public int idOrden { get; set; }
        public DateTime fecha { get; set; }
        public string hora { get; set; }
        public string edoOrden { get; set; }
        public double subtotal { get; set; }
        public double iva { get; set; }
        public double total { get; set; }
       // public string Asistente { get; set; }

      //  public virtual int idProveedor { get; set; }
       // public virtual int idUsuario { get; set; }
        public virtual Proveedor Proveedor { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual List<Servicio> ListaServicios { get; set; } 
        

    }

      
    /*
        public int InvoiceId { get; set; }

        public virtual SalesPerson SalesPerson { get; set; }

       // public DateTime SaleDate { get; set; }

       // public virtual List<Product> SaleList { get; set; } */

}
