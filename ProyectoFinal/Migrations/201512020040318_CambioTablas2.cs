namespace ProyectoFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CambioTablas2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Servicios", "OrdenServicio_idOrden", "dbo.OrdenServicios");
            DropForeignKey("dbo.OrdenServicios", "Proveedor_idProveedor1", "dbo.Proveedors");
            DropForeignKey("dbo.OrdenServicios", "Proveedor_idProveedor", "dbo.Proveedors");
            DropIndex("dbo.OrdenServicios", new[] { "Proveedor_idProveedor" });
            DropIndex("dbo.OrdenServicios", new[] { "Proveedor_idProveedor1" });
            DropIndex("dbo.Servicios", new[] { "OrdenServicio_idOrden" });
            DropColumn("dbo.OrdenServicios", "idProveedor");
            RenameColumn(table: "dbo.OrdenServicios", name: "Proveedor_idProveedor", newName: "idProveedor");
            AlterColumn("dbo.OrdenServicios", "idProveedor", c => c.Int(nullable: false));
            CreateIndex("dbo.OrdenServicios", "idProveedor");
            AddForeignKey("dbo.OrdenServicios", "idProveedor", "dbo.Proveedors", "idProveedor", cascadeDelete: true);
            DropColumn("dbo.OrdenServicios", "Proveedor_idProveedor1");
            DropColumn("dbo.Servicios", "OrdenServicio_idOrden");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Servicios", "OrdenServicio_idOrden", c => c.Int());
            AddColumn("dbo.OrdenServicios", "Proveedor_idProveedor1", c => c.Int());
            DropForeignKey("dbo.OrdenServicios", "idProveedor", "dbo.Proveedors");
            DropIndex("dbo.OrdenServicios", new[] { "idProveedor" });
            AlterColumn("dbo.OrdenServicios", "idProveedor", c => c.Int());
            RenameColumn(table: "dbo.OrdenServicios", name: "idProveedor", newName: "Proveedor_idProveedor");
            AddColumn("dbo.OrdenServicios", "idProveedor", c => c.Int(nullable: false));
            CreateIndex("dbo.Servicios", "OrdenServicio_idOrden");
            CreateIndex("dbo.OrdenServicios", "Proveedor_idProveedor1");
            CreateIndex("dbo.OrdenServicios", "Proveedor_idProveedor");
            AddForeignKey("dbo.OrdenServicios", "Proveedor_idProveedor", "dbo.Proveedors", "idProveedor");
            AddForeignKey("dbo.OrdenServicios", "Proveedor_idProveedor1", "dbo.Proveedors", "idProveedor");
            AddForeignKey("dbo.Servicios", "OrdenServicio_idOrden", "dbo.OrdenServicios", "idOrden");
        }
    }
}
