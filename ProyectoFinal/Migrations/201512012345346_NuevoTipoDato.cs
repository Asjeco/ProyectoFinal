namespace ProyectoFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NuevoTipoDato : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.OrdenServicios", "fecha", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.OrdenServicios", "fecha", c => c.String());
        }
    }
}
