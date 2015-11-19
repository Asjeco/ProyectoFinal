namespace ProyectoFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LLavesServicio : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProveedorServicios",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        ProveedoridProveedor = c.Int(nullable: false),
                        ServicioidServicio = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Proveedors", t => t.ProveedoridProveedor, cascadeDelete: true)
                .ForeignKey("dbo.Servicios", t => t.ServicioidServicio, cascadeDelete: true)
                .Index(t => t.ProveedoridProveedor)
                .Index(t => t.ServicioidServicio);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProveedorServicios", "ServicioidServicio", "dbo.Servicios");
            DropForeignKey("dbo.ProveedorServicios", "ProveedoridProveedor", "dbo.Proveedors");
            DropIndex("dbo.ProveedorServicios", new[] { "ServicioidServicio" });
            DropIndex("dbo.ProveedorServicios", new[] { "ProveedoridProveedor" });
            DropTable("dbo.ProveedorServicios");
        }
    }
}
