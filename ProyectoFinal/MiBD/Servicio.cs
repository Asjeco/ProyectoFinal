using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.MiBD
{
    public class Servicio
    {
        [Key]
        public int idServicio { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public double precio { get; set; }

        public virtual List<OrdenServicio> ListaOrdenes { get; set; } 
       // public virtual ICollection<ProveedorServicio> ProveedorServicios { get; set; }
        //public virtual ICollection<OrdenServicio> Ordenes { get; set; }
    }
}
