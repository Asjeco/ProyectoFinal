namespace ProyectoFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CambioTablas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        idUsuario = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.idUsuario);
            
            DropTable("dbo.Medicos");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Medicos",
                c => new
                    {
                        cedula = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.cedula);
            
            DropTable("dbo.Usuarios");
        }
    }
}
