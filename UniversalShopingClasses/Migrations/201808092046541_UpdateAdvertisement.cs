namespace UniversalShopingClasses.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateAdvertisement : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Advertisements", "User_Id", "dbo.Users");
            DropIndex("dbo.Advertisements", new[] { "User_Id" });
            AddColumn("dbo.Advertisements", "FullAddress", c => c.String());
            AddColumn("dbo.Advertisements", "Contact", c => c.Double(nullable: false));
            DropColumn("dbo.Advertisements", "User_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Advertisements", "User_Id", c => c.Int());
            DropColumn("dbo.Advertisements", "Contact");
            DropColumn("dbo.Advertisements", "FullAddress");
            CreateIndex("dbo.Advertisements", "User_Id");
            AddForeignKey("dbo.Advertisements", "User_Id", "dbo.Users", "Id");
        }
    }
}
