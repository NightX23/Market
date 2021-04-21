namespace TestIdentity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImprovingComplaintEntity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Complaints", "EmployeeId", c => c.String(nullable: false));
            AddColumn("dbo.Complaints", "Rate", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Complaints", "Rate");
            DropColumn("dbo.Complaints", "EmployeeId");
        }
    }
}
