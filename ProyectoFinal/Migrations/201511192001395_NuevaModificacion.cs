namespace ProyectoFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NuevaModificacion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrdenServicios", "precioEstimado", c => c.Double(nullable: false));
            DropColumn("dbo.OrdenServicios", "precioTotal");
            DropColumn("dbo.Servicios", "precio");
            DropColumn("dbo.Servicios", "Giro");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Servicios", "Giro", c => c.String());
            AddColumn("dbo.Servicios", "precio", c => c.Double(nullable: false));
            AddColumn("dbo.OrdenServicios", "precioTotal", c => c.Double(nullable: false));
            DropColumn("dbo.OrdenServicios", "precioEstimado");
        }
    }
}
