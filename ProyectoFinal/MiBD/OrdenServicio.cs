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
        [Key]
        public int idOrden { get; set; }
        public double precioEstimado { get; set; }
        public double iva { get; set; }
        public DateTime fecha { get; set; }
        public string hora { get; set; }
        public string edoOrden { get; set; }
       // public string Asistente { get; set; }

        public virtual int idProveedor { get; set; }
        public virtual int idUsuario { get; set; }

        public virtual List<Servicio> ListaServicios { get; set; } 
        

    }
}
