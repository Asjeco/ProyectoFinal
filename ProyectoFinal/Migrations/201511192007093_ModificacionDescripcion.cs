namespace ProyectoFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModificacionDescripcion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Servicios", "Descripcion", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Servicios", "Descripcion");
        }
    }
}
