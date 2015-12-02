namespace ProyectoFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EliminarHora : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.OrdenServicios", "hora");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrdenServicios", "hora", c => c.String());
        }
    }
}
