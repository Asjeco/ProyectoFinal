namespace ProyectoFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AgregarTotal : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrdenServicios", "subtotal", c => c.Double(nullable: false));
            AddColumn("dbo.OrdenServicios", "total", c => c.Double(nullable: false));
            DropColumn("dbo.OrdenServicios", "precioEstimado");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrdenServicios", "precioEstimado", c => c.Double(nullable: false));
            DropColumn("dbo.OrdenServicios", "total");
            DropColumn("dbo.OrdenServicios", "subtotal");
        }
    }
}
