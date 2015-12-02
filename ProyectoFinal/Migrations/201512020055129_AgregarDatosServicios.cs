namespace ProyectoFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AgregarDatosServicios : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ServicioOrdenServicios",
                c => new
                    {
                        Servicio_idServicio = c.Int(nullable: false),
                        OrdenServicio_idOrden = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Servicio_idServicio, t.OrdenServicio_idOrden })
                .ForeignKey("dbo.Servicios", t => t.Servicio_idServicio, cascadeDelete: true)
                .ForeignKey("dbo.OrdenServicios", t => t.OrdenServicio_idOrden, cascadeDelete: true)
                .Index(t => t.Servicio_idServicio)
                .Index(t => t.OrdenServicio_idOrden);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ServicioOrdenServicios", "OrdenServicio_idOrden", "dbo.OrdenServicios");
            DropForeignKey("dbo.ServicioOrdenServicios", "Servicio_idServicio", "dbo.Servicios");
            DropIndex("dbo.ServicioOrdenServicios", new[] { "OrdenServicio_idOrden" });
            DropIndex("dbo.ServicioOrdenServicios", new[] { "Servicio_idServicio" });
            DropTable("dbo.ServicioOrdenServicios");
        }
    }
}
