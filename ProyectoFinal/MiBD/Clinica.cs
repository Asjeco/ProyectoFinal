using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ProyectoFinal.MiBD
{
    public class Clinica : DbContext {

        public DbSet<Medico> Medicos { get; set; } //<clase> Medico(tablas)
    

    }
}
