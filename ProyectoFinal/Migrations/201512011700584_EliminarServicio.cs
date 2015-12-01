namespace ProyectoFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EliminarServicio : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProveedorServicios", "idProveedor", "dbo.Proveedors");
            DropForeignKey("dbo.OrdenServicios", "idServicio", "dbo.Servicios");
            DropForeignKey("dbo.ProveedorServicios", "idServicio", "dbo.Servicios");
            DropIndex("dbo.OrdenServicios", new[] { "idServicio" });
            DropIndex("dbo.ProveedorServicios", new[] { "idProveedor" });
            DropIndex("dbo.ProveedorServicios", new[] { "idServicio" });
            DropColumn("dbo.OrdenServicios", "idServicio");
            DropTable("dbo.ProveedorServicios");
            DropTable("dbo.Servicios");
        }
        
        public override void Down()
        {
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
                "dbo.ProveedorServicios",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        idProveedor = c.Int(nullable: false),
                        idServicio = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            AddColumn("dbo.OrdenServicios", "idServicio", c => c.Int(nullable: false));
            CreateIndex("dbo.ProveedorServicios", "idServicio");
            CreateIndex("dbo.ProveedorServicios", "idProveedor");
            CreateIndex("dbo.OrdenServicios", "idServicio");
            AddForeignKey("dbo.ProveedorServicios", "idServicio", "dbo.Servicios", "idServicio", cascadeDelete: true);
            AddForeignKey("dbo.OrdenServicios", "idServicio", "dbo.Servicios", "idServicio", cascadeDelete: true);
            AddForeignKey("dbo.ProveedorServicios", "idProveedor", "dbo.Proveedors", "idProveedor", cascadeDelete: true);
        }
    }
}
