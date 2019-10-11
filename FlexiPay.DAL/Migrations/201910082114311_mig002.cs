namespace FlexiPay.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig002 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Servicios", "ServicioContrato", c => c.String(maxLength: 50, unicode: false));
            DropColumn("dbo.Servicios", "ServicioContacto");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Servicios", "ServicioContacto", c => c.String(maxLength: 50, unicode: false));
            DropColumn("dbo.Servicios", "ServicioContrato");
        }
    }
}
