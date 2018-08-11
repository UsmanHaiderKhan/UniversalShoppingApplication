namespace UniversalShopingClasses.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateBrandValidation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ProductBrands", "ImageUrl", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ProductBrands", "ImageUrl", c => c.String(nullable: false));
        }
    }
}
