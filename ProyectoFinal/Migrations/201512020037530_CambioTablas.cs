namespace ProyectoFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CambioTablas : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrdenServicios", "idProveedor", "dbo.Proveedors");
            DropIndex("dbo.OrdenServicios", new[] { "idProveedor" });
            CreateTable(
                "dbo.Servicios",
                c => new
                    {
                        idServicio = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Descripcion = c.String(),
                        precio = c.Double(nullable: false),
                        OrdenServicio_idOrden = c.Int(),
                    })
                .PrimaryKey(t => t.idServicio)
                .ForeignKey("dbo.OrdenServicios", t => t.OrdenServicio_idOrden)
                .Index(t => t.OrdenServicio_idOrden);
            
            AddColumn("dbo.OrdenServicios", "Proveedor_idProveedor", c => c.Int());
            AddColumn("dbo.OrdenServicios", "Proveedor_idProveedor1", c => c.Int());
            CreateIndex("dbo.OrdenServicios", "Proveedor_idProveedor");
            CreateIndex("dbo.OrdenServicios", "Proveedor_idProveedor1");
            AddForeignKey("dbo.OrdenServicios", "Proveedor_idProveedor1", "dbo.Proveedors", "idProveedor");
            AddForeignKey("dbo.OrdenServicios", "Proveedor_idProveedor", "dbo.Proveedors", "idProveedor");
            DropColumn("dbo.OrdenServicios", "Asistente");
            DropColumn("dbo.Proveedors", "Giro");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Proveedors", "Giro", c => c.String());
            AddColumn("dbo.OrdenServicios", "Asistente", c => c.String());
            DropForeignKey("dbo.OrdenServicios", "Proveedor_idProveedor", "dbo.Proveedors");
            DropForeignKey("dbo.OrdenServicios", "Proveedor_idProveedor1", "dbo.Proveedors");
            DropForeignKey("dbo.Servicios", "OrdenServicio_idOrden", "dbo.OrdenServicios");
            DropIndex("dbo.Servicios", new[] { "OrdenServicio_idOrden" });
            DropIndex("dbo.OrdenServicios", new[] { "Proveedor_idProveedor1" });
            DropIndex("dbo.OrdenServicios", new[] { "Proveedor_idProveedor" });
            DropColumn("dbo.OrdenServicios", "Proveedor_idProveedor1");
            DropColumn("dbo.OrdenServicios", "Proveedor_idProveedor");
            DropTable("dbo.Servicios");
            CreateIndex("dbo.OrdenServicios", "idProveedor");
            AddForeignKey("dbo.OrdenServicios", "idProveedor", "dbo.Proveedors", "idProveedor", cascadeDelete: true);
        }
    }
}
