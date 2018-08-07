namespace UniversalShopingClasses.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        PhoneNo = c.Long(nullable: false),
                        Subject = c.String(),
                        Message = c.String(),
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
                        ProductBrand_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductBrands", t => t.ProductBrand_Id)
                .Index(t => t.ProductBrand_Id);
            
            CreateTable(
                "dbo.ProductBrands",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        ImageUrl = c.String(nullable: false),
                        ProductType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductTypes", t => t.ProductType_Id)
                .Index(t => t.ProductType_Id);
            
            CreateTable(
                "dbo.ProductTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Caption = c.String(),
                        Perority = c.Int(nullable: false),
                        Url = c.String(),
                        Drink_Id = c.Int(),
                        Fabric_Id = c.Int(),
                        Mobile_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Drinks", t => t.Drink_Id)
                .ForeignKey("dbo.Fabrics", t => t.Fabric_Id)
                .ForeignKey("dbo.Mobiles", t => t.Mobile_Id)
                .Index(t => t.Drink_Id)
                .Index(t => t.Fabric_Id)
                .Index(t => t.Mobile_Id);
            
            CreateTable(
                "dbo.Fabrics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Single(nullable: false),
                        Description = c.String(),
                        ProductBrand_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductBrands", t => t.ProductBrand_Id)
                .Index(t => t.ProductBrand_Id);
            
            CreateTable(
                "dbo.Genders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Mobiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Single(nullable: false),
                        Description = c.String(),
                        BlueTooth = c.Boolean(nullable: false),
                        ThreeG = c.Boolean(nullable: false),
                        FourG = c.Boolean(nullable: false),
                        Wifi = c.Boolean(nullable: false),
                        Ram = c.Int(nullable: false),
                        FrontCam = c.Int(nullable: false),
                        BackCam = c.Int(nullable: false),
                        Color = c.String(),
                        ScreenSize = c.Int(nullable: false),
                        Battery = c.Int(nullable: false),
                        Stock = c.Int(),
                        Accessories = c.String(),
                        Warranty = c.DateTime(nullable: false),
                        Features = c.String(),
                        ReleaseDate = c.DateTime(),
                        ProductBrand_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductBrands", t => t.ProductBrand_Id)
                .Index(t => t.ProductBrand_Id);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Single(nullable: false),
                        ImageUrl = c.String(),
                        Qauntity = c.Int(nullable: false),
                        Amount = c.Long(nullable: false),
                        Order_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.Order_Id)
                .Index(t => t.Order_Id);
            
            CreateTable(
                "dbo.Orders",
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
                .ForeignKey("dbo.OrderStatus", t => t.OrderStatus_Id)
                .Index(t => t.OrderStatus_Id);
            
            CreateTable(
                "dbo.OrderStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Rank = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fullname = c.String(nullable: false),
                        Loginid = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        ConfirmPassword = c.String(nullable: false),
                        ImageUrl = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Cnic = c.Long(nullable: false),
                        DateofBirth = c.DateTime(nullable: false),
                        MobileNo = c.Long(nullable: false),
                        FullAddress = c.String(nullable: false),
                        City = c.String(nullable: false),
                        State = c.String(nullable: false),
                        Gender_Id = c.Int(),
                        Role_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Genders", t => t.Gender_Id)
                .ForeignKey("dbo.Roles", t => t.Role_Id)
                .Index(t => t.Gender_Id)
                .Index(t => t.Role_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "Role_Id", "dbo.Roles");
            DropForeignKey("dbo.Users", "Gender_Id", "dbo.Genders");
            DropForeignKey("dbo.Orders", "OrderStatus_Id", "dbo.OrderStatus");
            DropForeignKey("dbo.OrderDetails", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.ProductImages", "Mobile_Id", "dbo.Mobiles");
            DropForeignKey("dbo.Mobiles", "ProductBrand_Id", "dbo.ProductBrands");
            DropForeignKey("dbo.ProductImages", "Fabric_Id", "dbo.Fabrics");
            DropForeignKey("dbo.Fabrics", "ProductBrand_Id", "dbo.ProductBrands");
            DropForeignKey("dbo.ProductImages", "Drink_Id", "dbo.Drinks");
            DropForeignKey("dbo.Drinks", "ProductBrand_Id", "dbo.ProductBrands");
            DropForeignKey("dbo.ProductBrands", "ProductType_Id", "dbo.ProductTypes");
            DropIndex("dbo.Users", new[] { "Role_Id" });
            DropIndex("dbo.Users", new[] { "Gender_Id" });
            DropIndex("dbo.Orders", new[] { "OrderStatus_Id" });
            DropIndex("dbo.OrderDetails", new[] { "Order_Id" });
            DropIndex("dbo.Mobiles", new[] { "ProductBrand_Id" });
            DropIndex("dbo.Fabrics", new[] { "ProductBrand_Id" });
            DropIndex("dbo.ProductImages", new[] { "Mobile_Id" });
            DropIndex("dbo.ProductImages", new[] { "Fabric_Id" });
            DropIndex("dbo.ProductImages", new[] { "Drink_Id" });
            DropIndex("dbo.ProductBrands", new[] { "ProductType_Id" });
            DropIndex("dbo.Drinks", new[] { "ProductBrand_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.Roles");
            DropTable("dbo.OrderStatus");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Mobiles");
            DropTable("dbo.Genders");
            DropTable("dbo.Fabrics");
            DropTable("dbo.ProductImages");
            DropTable("dbo.ProductTypes");
            DropTable("dbo.ProductBrands");
            DropTable("dbo.Drinks");
            DropTable("dbo.Contacts");
        }
    }
}
