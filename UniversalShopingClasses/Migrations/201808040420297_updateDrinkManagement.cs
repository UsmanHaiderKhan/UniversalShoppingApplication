namespace UniversalShopingClasses.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateDrinkManagement : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DrinkCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Drinks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ShortDescription = c.String(),
                        LongDescription = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsPreferredDrink = c.Boolean(nullable: false),
                        InStock = c.Boolean(nullable: false),
                        Category_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DrinkCategories", t => t.Category_Id)
                .Index(t => t.Category_Id);
            
            CreateTable(
                "dbo.ProductImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Caption = c.String(),
                        Perority = c.Int(nullable: false),
                        Url = c.String(),
                        Drink_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Drinks", t => t.Drink_Id)
                .Index(t => t.Drink_Id);
            
            CreateTable(
                "dbo.DrinkOrderDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Single(nullable: false),
                        ImageUrl = c.String(),
                        Qauntity = c.Int(nullable: false),
                        Amount = c.Long(nullable: false),
                        DrinkOrder_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DrinkOrders", t => t.DrinkOrder_Id)
                .Index(t => t.DrinkOrder_Id);
            
            CreateTable(
                "dbo.DrinkOrders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BuyerName = c.String(),
                        EmailAddress = c.String(),
                        FullAddress = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        Phone = c.Double(nullable: false),
                        OrderStatus_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DrinkOrderStatus", t => t.OrderStatus_Id)
                .Index(t => t.OrderStatus_Id);
            
            CreateTable(
                "dbo.DrinkOrderStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DrinkOrders", "OrderStatus_Id", "dbo.DrinkOrderStatus");
            DropForeignKey("dbo.DrinkOrderDetails", "DrinkOrder_Id", "dbo.DrinkOrders");
            DropForeignKey("dbo.ProductImages", "Drink_Id", "dbo.Drinks");
            DropForeignKey("dbo.Drinks", "Category_Id", "dbo.DrinkCategories");
            DropIndex("dbo.DrinkOrders", new[] { "OrderStatus_Id" });
            DropIndex("dbo.DrinkOrderDetails", new[] { "DrinkOrder_Id" });
            DropIndex("dbo.ProductImages", new[] { "Drink_Id" });
            DropIndex("dbo.Drinks", new[] { "Category_Id" });
            DropTable("dbo.DrinkOrderStatus");
            DropTable("dbo.DrinkOrders");
            DropTable("dbo.DrinkOrderDetails");
            DropTable("dbo.ProductImages");
            DropTable("dbo.Drinks");
            DropTable("dbo.DrinkCategories");
        }
    }
}
