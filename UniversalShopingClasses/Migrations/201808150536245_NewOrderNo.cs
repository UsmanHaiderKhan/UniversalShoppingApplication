namespace UniversalShopingClasses.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewOrderNo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "OrderNo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "OrderNo");
        }
    }
}
