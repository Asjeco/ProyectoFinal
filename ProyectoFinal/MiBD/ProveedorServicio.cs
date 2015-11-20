using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProyectoFinal.MiBD
{
    public class ProveedorServicio
    {
        
        public int id { get; set; }

        public virtual int idProveedor { get; set; }
        public virtual int idServicio { get; set; }

    }
}
