using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.MiBD
{
    public class Proveedor
    {
        [Key]
        public int idProveedor { get; set; }
        public string Nombre { get; set; }
        public string Direcc { get; set; }
        public string Giro { get; set; }
        public string Usuario { get; set; }
        public string Contra { get; set; }
        public byte edoCta { get; set; }

        public virtual ICollection<ProveedorServicio> ProveedorServicios { get; set; }
        public virtual ICollection<AsistentesProveedor> AsistentesProveedor { get; set; }
        public virtual ICollection<OrdenServicio> Ordenes { get; set; }

        
    }
}
