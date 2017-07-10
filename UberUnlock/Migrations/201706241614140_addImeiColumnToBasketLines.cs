namespace UberUnlock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addImeiColumnToBasketLines : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderLines", "IMEI", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrderLines", "IMEI");
        }
    }
}
