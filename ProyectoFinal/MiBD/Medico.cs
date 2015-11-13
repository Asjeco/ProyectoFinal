using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.MiBD
{
    public class Medico
    {
        [Key]
        public int cedula { get; set; }
        public string Nombre { get; set; }
        

    }
}
