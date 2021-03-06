﻿using System;
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
        public string Usuario { get; set; }
        public string Contra { get; set; }
        public byte edoCta { get; set; }


       
        public virtual ICollection<Asistente> Asistentes { get; set; }
        public virtual ICollection<OrdenServicio> Ordenes { get; set; }

      //  public virtual List<OrdenServicio> ProveedorList { get; set; } 
    }
}
