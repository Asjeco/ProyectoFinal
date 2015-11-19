namespace ProyectoFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LLavesAsistente : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AsistentesProveedors",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        ProveedoridProveedor = c.Int(nullable: false),
                        AsistenteidAsistente = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Asistentes", t => t.AsistenteidAsistente, cascadeDelete: true)
                .ForeignKey("dbo.Proveedors", t => t.ProveedoridProveedor, cascadeDelete: true)
                .Index(t => t.ProveedoridProveedor)
                .Index(t => t.AsistenteidAsistente);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AsistentesProveedors", "ProveedoridProveedor", "dbo.Proveedors");
            DropForeignKey("dbo.AsistentesProveedors", "AsistenteidAsistente", "dbo.Asistentes");
            DropIndex("dbo.AsistentesProveedors", new[] { "AsistenteidAsistente" });
            DropIndex("dbo.AsistentesProveedors", new[] { "ProveedoridProveedor" });
            DropTable("dbo.AsistentesProveedors");
        }
    }
}
