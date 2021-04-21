namespace TestIdentity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImprovingComplaintEntity3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Complaints", "EmployeeId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Complaints", "EmployeeId", c => c.String(nullable: false));
        }
    }
}
