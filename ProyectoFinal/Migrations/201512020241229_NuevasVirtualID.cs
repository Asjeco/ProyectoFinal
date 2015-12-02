namespace ProyectoFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NuevasVirtualID : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrdenServicios", "idProveedor", "dbo.Proveedors");
            DropForeignKey("dbo.OrdenServicios", "idUsuario", "dbo.Usuarios");
            DropIndex("dbo.OrdenServicios", new[] { "idProveedor" });
            DropIndex("dbo.OrdenServicios", new[] { "idUsuario" });
            RenameColumn(table: "dbo.OrdenServicios", name: "idProveedor", newName: "Proveedor_idProveedor");
            RenameColumn(table: "dbo.OrdenServicios", name: "idUsuario", newName: "Usuario_idUsuario");
            AlterColumn("dbo.OrdenServicios", "Proveedor_idProveedor", c => c.Int());
            AlterColumn("dbo.OrdenServicios", "Usuario_idUsuario", c => c.Int());
            CreateIndex("dbo.OrdenServicios", "Proveedor_idProveedor");
            CreateIndex("dbo.OrdenServicios", "Usuario_idUsuario");
            AddForeignKey("dbo.OrdenServicios", "Proveedor_idProveedor", "dbo.Proveedors", "idProveedor");
            AddForeignKey("dbo.OrdenServicios", "Usuario_idUsuario", "dbo.Usuarios", "idUsuario");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrdenServicios", "Usuario_idUsuario", "dbo.Usuarios");
            DropForeignKey("dbo.OrdenServicios", "Proveedor_idProveedor", "dbo.Proveedors");
            DropIndex("dbo.OrdenServicios", new[] { "Usuario_idUsuario" });
            DropIndex("dbo.OrdenServicios", new[] { "Proveedor_idProveedor" });
            AlterColumn("dbo.OrdenServicios", "Usuario_idUsuario", c => c.Int(nullable: false));
            AlterColumn("dbo.OrdenServicios", "Proveedor_idProveedor", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.OrdenServicios", name: "Usuario_idUsuario", newName: "idUsuario");
            RenameColumn(table: "dbo.OrdenServicios", name: "Proveedor_idProveedor", newName: "idProveedor");
            CreateIndex("dbo.OrdenServicios", "idUsuario");
            CreateIndex("dbo.OrdenServicios", "idProveedor");
            AddForeignKey("dbo.OrdenServicios", "idUsuario", "dbo.Usuarios", "idUsuario", cascadeDelete: true);
            AddForeignKey("dbo.OrdenServicios", "idProveedor", "dbo.Proveedors", "idProveedor", cascadeDelete: true);
        }
    }
}
