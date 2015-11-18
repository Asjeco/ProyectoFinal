namespace ProyectoFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CrearLLaves : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Usuarios", "Direcc", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Usuarios", "Direcc");
        }
    }
}
