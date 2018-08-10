namespace UniversalShopingClasses.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedNewModules : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AuctionCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Auctions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        BidPrice = c.Single(nullable: false),
                        Specification = c.String(),
                        Postedon = c.DateTime(nullable: false),
                        FullAddress = c.String(),
                        Contact = c.Double(nullable: false),
                        Description = c.String(),
                        AuctionCategory_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AuctionCategories", t => t.AuctionCategory_Id)
                .Index(t => t.AuctionCategory_Id);
            
            AddColumn("dbo.ProductImages", "Auction_Id", c => c.Int());
            CreateIndex("dbo.ProductImages", "Auction_Id");
            AddForeignKey("dbo.ProductImages", "Auction_Id", "dbo.Auctions", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductImages", "Auction_Id", "dbo.Auctions");
            DropForeignKey("dbo.Auctions", "AuctionCategory_Id", "dbo.AuctionCategories");
            DropIndex("dbo.Auctions", new[] { "AuctionCategory_Id" });
            DropIndex("dbo.ProductImages", new[] { "Auction_Id" });
            DropColumn("dbo.ProductImages", "Auction_Id");
            DropTable("dbo.Auctions");
            DropTable("dbo.AuctionCategories");
        }
    }
}
