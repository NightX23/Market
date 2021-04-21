namespace TestIdentity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImprovingComplaintEntity2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Complaints", "RateId", c => c.String());
            AddColumn("dbo.Complaints", "Rate_Id", c => c.Int());
            CreateIndex("dbo.Complaints", "Rate_Id");
            AddForeignKey("dbo.Complaints", "Rate_Id", "dbo.Rates", "Id");
            DropColumn("dbo.Complaints", "Rate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Complaints", "Rate", c => c.Int(nullable: false));
            DropForeignKey("dbo.Complaints", "Rate_Id", "dbo.Rates");
            DropIndex("dbo.Complaints", new[] { "Rate_Id" });
            DropColumn("dbo.Complaints", "Rate_Id");
            DropColumn("dbo.Complaints", "RateId");
            DropTable("dbo.Rates");
        }
    }
}
