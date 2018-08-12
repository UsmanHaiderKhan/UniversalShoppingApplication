namespace UniversalShopingClasses.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewFeedTbl : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FeedBacks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Subject = c.String(),
                        FeedDetail = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.FeedBacks");
        }
    }
}
