namespace ProyectoFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CambioTotal : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Asistentes",
                c => new
                    {
                        idAsistente = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        telefono = c.String(),
                        idProveedor = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idAsistente)
                .ForeignKey("dbo.Proveedors", t => t.idProveedor, cascadeDelete: true)
                .Index(t => t.idProveedor);
            
            CreateTable(
                "dbo.OrdenServicios",
                c => new
                    {
                        idOrden = c.Int(nullable: false, identity: true),
                        precioEstimado = c.Double(nullable: false),
                        iva = c.Double(nullable: false),
                        fecha = c.String(),
                        hora = c.String(),
                        edoOrden = c.String(),
                        Asistente = c.String(),
                        idProveedor = c.Int(nullable: false),
                        idUsuario = c.Int(nullable: false),
                        idServicio = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idOrden)
                .ForeignKey("dbo.Proveedors", t => t.idProveedor, cascadeDelete: true)
                .ForeignKey("dbo.Servicios", t => t.idServicio, cascadeDelete: true)
                .ForeignKey("dbo.Usuarios", t => t.idUsuario, cascadeDelete: true)
                .Index(t => t.idProveedor)
                .Index(t => t.idUsuario)
                .Index(t => t.idServicio);
            
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
                "dbo.ProveedorServicios",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        idProveedor = c.Int(nullable: false),
                        idServicio = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Proveedors", t => t.idProveedor, cascadeDelete: true)
                .ForeignKey("dbo.Servicios", t => t.idServicio, cascadeDelete: true)
                .Index(t => t.idProveedor)
                .Index(t => t.idServicio);
            
            CreateTable(
                "dbo.Servicios",
                c => new
                    {
                        idServicio = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.idServicio);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        idUsuario = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Ubicacion = c.String(),
                    })
                .PrimaryKey(t => t.idUsuario);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrdenServicios", "idUsuario", "dbo.Usuarios");
            DropForeignKey("dbo.ProveedorServicios", "idServicio", "dbo.Servicios");
            DropForeignKey("dbo.OrdenServicios", "idServicio", "dbo.Servicios");
            DropForeignKey("dbo.ProveedorServicios", "idProveedor", "dbo.Proveedors");
            DropForeignKey("dbo.OrdenServicios", "idProveedor", "dbo.Proveedors");
            DropForeignKey("dbo.Asistentes", "idProveedor", "dbo.Proveedors");
            DropIndex("dbo.ProveedorServicios", new[] { "idServicio" });
            DropIndex("dbo.ProveedorServicios", new[] { "idProveedor" });
            DropIndex("dbo.OrdenServicios", new[] { "idServicio" });
            DropIndex("dbo.OrdenServicios", new[] { "idUsuario" });
            DropIndex("dbo.OrdenServicios", new[] { "idProveedor" });
            DropIndex("dbo.Asistentes", new[] { "idProveedor" });
            DropTable("dbo.Usuarios");
            DropTable("dbo.Servicios");
            DropTable("dbo.ProveedorServicios");
            DropTable("dbo.Proveedors");
            DropTable("dbo.OrdenServicios");
            DropTable("dbo.Asistentes");
        }
    }
}
