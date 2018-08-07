namespace UniversalShopingClasses.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OLXClasses : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Advertisements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 300, unicode: false),
                        Description = c.String(maxLength: 8000, unicode: false),
                        Price = c.Single(nullable: false),
                        PostedOn = c.DateTime(nullable: false),
                        SubCategory_Id = c.Int(),
                        Type_Id = c.Int(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AdvertisementSubCategories", t => t.SubCategory_Id)
                .ForeignKey("dbo.AdvertisementTypes", t => t.Type_Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.SubCategory_Id)
                .Index(t => t.Type_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.AdvertisementSubCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50, unicode: false),
                        AdvertismentCateory_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AdvertismentCateories", t => t.AdvertismentCateory_Id, cascadeDelete: true)
                .Index(t => t.AdvertismentCateory_Id);
            
            CreateTable(
                "dbo.AdvertismentCateories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AdvertisementTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.ProductImages", "Advertisement_Id", c => c.Int());
            CreateIndex("dbo.ProductImages", "Advertisement_Id");
            AddForeignKey("dbo.ProductImages", "Advertisement_Id", "dbo.Advertisements", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Advertisements", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Advertisements", "Type_Id", "dbo.AdvertisementTypes");
            DropForeignKey("dbo.Advertisements", "SubCategory_Id", "dbo.AdvertisementSubCategories");
            DropForeignKey("dbo.AdvertisementSubCategories", "AdvertismentCateory_Id", "dbo.AdvertismentCateories");
            DropForeignKey("dbo.ProductImages", "Advertisement_Id", "dbo.Advertisements");
            DropIndex("dbo.AdvertisementSubCategories", new[] { "AdvertismentCateory_Id" });
            DropIndex("dbo.ProductImages", new[] { "Advertisement_Id" });
            DropIndex("dbo.Advertisements", new[] { "User_Id" });
            DropIndex("dbo.Advertisements", new[] { "Type_Id" });
            DropIndex("dbo.Advertisements", new[] { "SubCategory_Id" });
            DropColumn("dbo.ProductImages", "Advertisement_Id");
            DropTable("dbo.AdvertisementTypes");
            DropTable("dbo.AdvertismentCateories");
            DropTable("dbo.AdvertisementSubCategories");
            DropTable("dbo.Advertisements");
        }
    }
}
