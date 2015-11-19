using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ProyectoFinal.MiBD
{
    public class HelpMeAPP : DbContext {

        public DbSet<Usuario> Usuarios { get; set; } //<clase> (tablas)
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Servicio> Servicios { get; set; }
        public DbSet<Asistente> Asistentes { get; set; }
        public DbSet<OrdenServicio> Ordenes { get; set; }
        public DbSet<ProveedorServicio> ProveedorServicios { get; set; }
        public DbSet<AsistentesProveedor> AsistenteProveedores { get; set; }
    

    }
}
