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
        public string fecha { get; set; }
        public string hora { get; set; }
        public string edoOrden { get; set; }

        public virtual int ProveedoridProveedor { get; set; }
        public virtual int UsuarioidUsuario { get; set; }
        public virtual int ServicioidServicio { get; set; }
        public virtual int AsistenteidAsistente { get; set; }

    }
}
