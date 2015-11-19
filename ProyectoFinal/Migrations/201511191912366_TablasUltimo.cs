namespace ProyectoFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TablasUltimo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Asistentes", "telefono", c => c.String());
            AddColumn("dbo.OrdenServicios", "iva", c => c.Double(nullable: false));
            AddColumn("dbo.OrdenServicios", "fecha", c => c.String());
            AddColumn("dbo.OrdenServicios", "hora", c => c.String());
            AddColumn("dbo.Usuarios", "Ubicacion", c => c.String());
            DropColumn("dbo.Usuarios", "Direcc");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Usuarios", "Direcc", c => c.String());
            DropColumn("dbo.Usuarios", "Ubicacion");
            DropColumn("dbo.OrdenServicios", "hora");
            DropColumn("dbo.OrdenServicios", "fecha");
            DropColumn("dbo.OrdenServicios", "iva");
            DropColumn("dbo.Asistentes", "telefono");
        }
    }
}
