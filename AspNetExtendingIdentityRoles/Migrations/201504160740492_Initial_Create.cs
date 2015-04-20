namespace HNWebPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial_Create : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Announcements",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 100),
                        Content = c.String(),
                        Created = c.DateTime(nullable: false),
                        Author = c.String(maxLength: 100),
                        Contact_ContactID = c.Int(),
                        Home_ID = c.Int(),
                        Meeting_ID = c.Int(),
                        Schedule_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Contacts", t => t.Contact_ContactID)
                .ForeignKey("dbo.Homes", t => t.Home_ID)
                .ForeignKey("dbo.Meetings", t => t.Meeting_ID)
                .ForeignKey("dbo.Schedules", t => t.Schedule_ID)
                .Index(t => t.Contact_ContactID)
                .Index(t => t.Home_ID)
                .Index(t => t.Meeting_ID)
                .Index(t => t.Schedule_ID);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        ContactID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 30),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Position = c.String(nullable: false, maxLength: 100),
                        Location = c.String(nullable: false, maxLength: 100),
                        Phone = c.Long(),
                        EXT = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ContactID);
            
            CreateTable(
                "dbo.Resources",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 100),
                        FileName = c.String(nullable: false, maxLength: 100),
                        CreatedOn = c.DateTime(nullable: false),
                        FileContent = c.Binary(nullable: false),
                        MimeType = c.String(nullable: false, maxLength: 256),
                        Contact_ContactID = c.Int(),
                        Home_ID = c.Int(),
                        Meeting_ID = c.Int(),
                        Schedule_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Contacts", t => t.Contact_ContactID)
                .ForeignKey("dbo.Homes", t => t.Home_ID)
                .ForeignKey("dbo.Meetings", t => t.Meeting_ID)
                .ForeignKey("dbo.Schedules", t => t.Schedule_ID)
                .Index(t => t.Contact_ContactID)
                .Index(t => t.Home_ID)
                .Index(t => t.Meeting_ID)
                .Index(t => t.Schedule_ID);
            
            CreateTable(
                "dbo.DeathNotifications",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                        Date = c.DateTime(nullable: false),
                        Location = c.String(maxLength: 100),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Homes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 100),
                        Content = c.String(),
                        Created = c.DateTime(),
                        Author = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Meetings",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                        Description = c.String(maxLength: 1000),
                        Date = c.DateTime(),
                        Location = c.String(maxLength: 100),
                        Type = c.String(maxLength: 100),
                        RSVP = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Schedules",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserName = c.String(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        User_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.LoginProvider, t.ProviderKey })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserClaims", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Resources", "Schedule_ID", "dbo.Schedules");
            DropForeignKey("dbo.Announcements", "Schedule_ID", "dbo.Schedules");
            DropForeignKey("dbo.Resources", "Meeting_ID", "dbo.Meetings");
            DropForeignKey("dbo.Announcements", "Meeting_ID", "dbo.Meetings");
            DropForeignKey("dbo.Resources", "Home_ID", "dbo.Homes");
            DropForeignKey("dbo.Announcements", "Home_ID", "dbo.Homes");
            DropForeignKey("dbo.Resources", "Contact_ContactID", "dbo.Contacts");
            DropForeignKey("dbo.Announcements", "Contact_ContactID", "dbo.Contacts");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "User_Id" });
            DropIndex("dbo.Resources", new[] { "Schedule_ID" });
            DropIndex("dbo.Resources", new[] { "Meeting_ID" });
            DropIndex("dbo.Resources", new[] { "Home_ID" });
            DropIndex("dbo.Resources", new[] { "Contact_ContactID" });
            DropIndex("dbo.Announcements", new[] { "Schedule_ID" });
            DropIndex("dbo.Announcements", new[] { "Meeting_ID" });
            DropIndex("dbo.Announcements", new[] { "Home_ID" });
            DropIndex("dbo.Announcements", new[] { "Contact_ContactID" });
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Schedules");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Meetings");
            DropTable("dbo.Homes");
            DropTable("dbo.DeathNotifications");
            DropTable("dbo.Resources");
            DropTable("dbo.Contacts");
            DropTable("dbo.Announcements");
            DropTable("dbo.Admins");
        }
    }
}
