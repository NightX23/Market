namespace TestIdentity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddComplaintsEntities : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ComplaintAndClaimStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Complaints",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false),
                        TypeId = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        StatusId = c.Int(nullable: false),
                        RespDepartmentId = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        Feedback = c.String(nullable: false),
                        Customer_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.Customer_Id)
                .ForeignKey("dbo.Departments", t => t.RespDepartmentId, cascadeDelete: true)
                .ForeignKey("dbo.ComplaintAndClaimStatus", t => t.StatusId, cascadeDelete: true)
                .ForeignKey("dbo.ComplaintTypes", t => t.TypeId, cascadeDelete: true)
                .Index(t => t.TypeId)
                .Index(t => t.StatusId)
                .Index(t => t.RespDepartmentId)
                .Index(t => t.Customer_Id);
            
            CreateTable(
                "dbo.ComplaintTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Complaints", "TypeId", "dbo.ComplaintTypes");
            DropForeignKey("dbo.Complaints", "StatusId", "dbo.ComplaintAndClaimStatus");
            DropForeignKey("dbo.Complaints", "RespDepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Complaints", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.Complaints", new[] { "Customer_Id" });
            DropIndex("dbo.Complaints", new[] { "RespDepartmentId" });
            DropIndex("dbo.Complaints", new[] { "StatusId" });
            DropIndex("dbo.Complaints", new[] { "TypeId" });
            DropTable("dbo.ComplaintTypes");
            DropTable("dbo.Complaints");
            DropTable("dbo.ComplaintAndClaimStatus");
        }
    }
}
