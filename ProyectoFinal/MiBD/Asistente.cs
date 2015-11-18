using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.MiBD
{
    public class Asistente
    {
        [Key]
        public int idAsistente { get; set; }
        public string Nombre { get; set; }

        public virtual int ProveedoridProveedor { get; set; }
        public virtual ICollection<OrdenServicio> Ordenes { get; set; }
    
    }
}
