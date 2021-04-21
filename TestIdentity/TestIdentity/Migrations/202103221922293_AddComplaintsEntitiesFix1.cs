namespace TestIdentity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddComplaintsEntitiesFix1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Complaints", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.Complaints", new[] { "Customer_Id" });
            DropColumn("dbo.Complaints", "CustomerId");
            RenameColumn(table: "dbo.Complaints", name: "Customer_Id", newName: "CustomerId");
            AlterColumn("dbo.Complaints", "CustomerId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Complaints", "CustomerId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Complaints", "CustomerId");
            AddForeignKey("dbo.Complaints", "CustomerId", "dbo.Customers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Complaints", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Complaints", new[] { "CustomerId" });
            AlterColumn("dbo.Complaints", "CustomerId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Complaints", "CustomerId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Complaints", name: "CustomerId", newName: "Customer_Id");
            AddColumn("dbo.Complaints", "CustomerId", c => c.Int(nullable: false));
            CreateIndex("dbo.Complaints", "Customer_Id");
            AddForeignKey("dbo.Complaints", "Customer_Id", "dbo.Customers", "Id");
        }
    }
}
