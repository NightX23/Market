namespace TestIdentity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class repairingbug1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Complaints", "Feedback", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Complaints", "Feedback", c => c.String(nullable: false));
        }
    }
}
