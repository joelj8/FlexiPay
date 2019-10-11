namespace FlexiPay.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mig20191008 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Facturas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ServicioID = c.Int(nullable: false),
                        Monto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Pagado = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FechaLimite = c.DateTime(nullable: false),
                        FechaPago = c.DateTime(nullable: false),
                        Aprobacion = c.String(maxLength: 20, unicode: false),
                        TarjetaID = c.Int(nullable: false),
                        Coment = c.String(storeType: "ntext"),
                        Inactivo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Servicios", t => t.ServicioID, cascadeDelete: true)
                .ForeignKey("dbo.Tarjetas", t => t.TarjetaID, cascadeDelete: true)
                .Index(t => t.ServicioID)
                .Index(t => t.TarjetaID);
            
            CreateTable(
                "dbo.Servicios",
                c => new
                    {
                        ServicioID = c.Int(nullable: false, identity: true),
                        ServicioName = c.String(maxLength: 50, unicode: false),
                        ServicioContacto = c.String(maxLength: 50, unicode: false),
                        ServicioTelefono = c.String(maxLength: 20, unicode: false),
                        Inactivo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ServicioID);
            
            CreateTable(
                "dbo.Tarjetas",
                c => new
                    {
                        TarjetaID = c.Int(nullable: false, identity: true),
                        TarjetaNumero = c.String(maxLength: 20, unicode: false),
                        Inactivo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TarjetaID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Facturas", "TarjetaID", "dbo.Tarjetas");
            DropForeignKey("dbo.Facturas", "ServicioID", "dbo.Servicios");
            DropIndex("dbo.Facturas", new[] { "TarjetaID" });
            DropIndex("dbo.Facturas", new[] { "ServicioID" });
            DropTable("dbo.Tarjetas");
            DropTable("dbo.Servicios");
            DropTable("dbo.Facturas");
        }
    }
}
