namespace ProyectoFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EliminarCampos : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Asistentes", "ProveedoridProveedor");
            DropColumn("dbo.Servicios", "ProveedoridProveedor");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Servicios", "ProveedoridProveedor", c => c.Int(nullable: false));
            AddColumn("dbo.Asistentes", "ProveedoridProveedor", c => c.Int(nullable: false));
        }
    }
}
