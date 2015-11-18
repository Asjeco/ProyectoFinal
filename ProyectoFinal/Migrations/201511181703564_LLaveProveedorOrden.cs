namespace ProyectoFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LLaveProveedorOrden : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.OrdenServicios", "ProveedoridProveedor");
            AddForeignKey("dbo.OrdenServicios", "ProveedoridProveedor", "dbo.Proveedors", "idProveedor", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrdenServicios", "ProveedoridProveedor", "dbo.Proveedors");
            DropIndex("dbo.OrdenServicios", new[] { "ProveedoridProveedor" });
        }
    }
}
