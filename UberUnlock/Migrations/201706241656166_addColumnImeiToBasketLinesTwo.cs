namespace UberUnlock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addColumnImeiToBasketLinesTwo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BasketLines", "IMEI", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.BasketLines", "IMEI");
        }
    }
}
