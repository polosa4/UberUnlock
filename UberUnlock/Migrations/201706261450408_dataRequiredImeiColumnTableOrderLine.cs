namespace UberUnlock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dataRequiredImeiColumnTableOrderLine : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.OrderLines", "IMEI", c => c.String(nullable: true, maxLength: 15));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.OrderLines", "IMEI", c => c.String());
        }
    }
}
