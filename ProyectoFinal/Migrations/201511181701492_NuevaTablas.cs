namespace ProyectoFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NuevaTablas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Asistentes",
                c => new
                    {
                        idAsistente = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        ProveedoridProveedor = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idAsistente);
            
            CreateTable(
                "dbo.OrdenServicios",
                c => new
                    {
                        idOrden = c.Int(nullable: false, identity: true),
                        precioTotal = c.Double(nullable: false),
                        edoOrden = c.String(),
                        ProveedoridProveedor = c.Int(nullable: false),
                        UsuarioidUsuario = c.Int(nullable: false),
                        ServicioidServicio = c.Int(nullable: false),
                        AsistenteidAsistente = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idOrden)
                .ForeignKey("dbo.Asistentes", t => t.AsistenteidAsistente, cascadeDelete: true)
                .ForeignKey("dbo.Servicios", t => t.ServicioidServicio, cascadeDelete: true)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioidUsuario, cascadeDelete: true)
                .Index(t => t.UsuarioidUsuario)
                .Index(t => t.ServicioidServicio)
                .Index(t => t.AsistenteidAsistente);
            
            CreateTable(
                "dbo.Proveedors",
                c => new
                    {
                        idProveedor = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Direcc = c.String(),
                        Giro = c.String(),
                        Usuario = c.String(),
                        Contra = c.String(),
                        edoCta = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.idProveedor);
            
            CreateTable(
                "dbo.Servicios",
                c => new
                    {
                        idServicio = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        precio = c.Double(nullable: false),
                        Giro = c.String(),
                        ProveedoridProveedor = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idServicio);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrdenServicios", "UsuarioidUsuario", "dbo.Usuarios");
            DropForeignKey("dbo.OrdenServicios", "ServicioidServicio", "dbo.Servicios");
            DropForeignKey("dbo.OrdenServicios", "AsistenteidAsistente", "dbo.Asistentes");
            DropIndex("dbo.OrdenServicios", new[] { "AsistenteidAsistente" });
            DropIndex("dbo.OrdenServicios", new[] { "ServicioidServicio" });
            DropIndex("dbo.OrdenServicios", new[] { "UsuarioidUsuario" });
            DropTable("dbo.Servicios");
            DropTable("dbo.Proveedors");
            DropTable("dbo.OrdenServicios");
            DropTable("dbo.Asistentes");
        }
    }
}
