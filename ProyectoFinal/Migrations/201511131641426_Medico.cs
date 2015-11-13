namespace ProyectoFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Medico : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Medicos",
                c => new
                    {
                        cedula = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.cedula);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Medicos");
        }
    }
}
