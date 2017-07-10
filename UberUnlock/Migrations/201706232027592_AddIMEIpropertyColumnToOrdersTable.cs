namespace UberUnlock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIMEIpropertyColumnToOrdersTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "IMEI", c => c.String(nullable: false, maxLength: 15));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "IMEI");
        }
    }
}
