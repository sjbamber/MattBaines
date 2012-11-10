namespace MattBaines.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdvertisingCreativeObjects",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(nullable: false),
                        Content = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        Category_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AdvertisingCreativeCategories", t => t.Category_Id)
                .Index(t => t.Category_Id);
            
            CreateTable(
                "dbo.AdvertisingCreativeCategories",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        Colour = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WorkILikes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Type = c.String(),
                        Title = c.String(nullable: false),
                        Course = c.String(),
                        Year = c.String(),
                        Summary = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Guid(nullable: false),
                        Username = c.String(nullable: false),
                        Email = c.String(),
                        Password = c.String(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Comment = c.String(),
                        IsApproved = c.Boolean(nullable: false),
                        PasswordFailuresSinceLastSuccess = c.Int(nullable: false),
                        LastPasswordFailureDate = c.DateTime(),
                        LastActivityDate = c.DateTime(),
                        LastLockoutDate = c.DateTime(),
                        LastLoginDate = c.DateTime(),
                        ConfirmationToken = c.String(),
                        CreateDate = c.DateTime(),
                        IsLockedOut = c.Boolean(nullable: false),
                        LastPasswordChangedDate = c.DateTime(),
                        PasswordVerificationToken = c.String(),
                        PasswordVerificationTokenExpirationDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleId = c.Guid(nullable: false),
                        RoleName = c.String(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.RoleId);
            
            CreateTable(
                "dbo.RoleUsers",
                c => new
                    {
                        Role_RoleId = c.Guid(nullable: false),
                        User_UserId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Role_RoleId, t.User_UserId })
                .ForeignKey("dbo.Roles", t => t.Role_RoleId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_UserId, cascadeDelete: true)
                .Index(t => t.Role_RoleId)
                .Index(t => t.User_UserId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.RoleUsers", new[] { "User_UserId" });
            DropIndex("dbo.RoleUsers", new[] { "Role_RoleId" });
            DropIndex("dbo.AdvertisingCreativeObjects", new[] { "Category_Id" });
            DropForeignKey("dbo.RoleUsers", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.RoleUsers", "Role_RoleId", "dbo.Roles");
            DropForeignKey("dbo.AdvertisingCreativeObjects", "Category_Id", "dbo.AdvertisingCreativeCategories");
            DropTable("dbo.RoleUsers");
            DropTable("dbo.Roles");
            DropTable("dbo.Users");
            DropTable("dbo.WorkILikes");
            DropTable("dbo.AdvertisingCreativeCategories");
            DropTable("dbo.AdvertisingCreativeObjects");
        }
    }
}
