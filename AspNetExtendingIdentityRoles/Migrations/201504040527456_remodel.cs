namespace HNWebPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class remodel : DbMigration
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
                        Contact_ID = c.Int(),
                        Home_ID = c.Int(),
                        Meeting_ID = c.Int(),
                        Schedule_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Contacts", t => t.Contact_ID)
                .ForeignKey("dbo.Homes", t => t.Home_ID)
                .ForeignKey("dbo.Meetings", t => t.Meeting_ID)
                .ForeignKey("dbo.Schedules", t => t.Schedule_ID)
                .Index(t => t.Contact_ID)
                .Index(t => t.Home_ID)
                .Index(t => t.Meeting_ID)
                .Index(t => t.Schedule_ID);
            
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
                        Announcement_ID = c.Int(),
                        Contact_ID = c.Int(),
                        Home_ID = c.Int(),
                        Meeting_ID = c.Int(),
                        Schedule_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Announcements", t => t.Announcement_ID)
                .ForeignKey("dbo.Contacts", t => t.Contact_ID)
                .ForeignKey("dbo.Homes", t => t.Home_ID)
                .ForeignKey("dbo.Meetings", t => t.Meeting_ID)
                .ForeignKey("dbo.Schedules", t => t.Schedule_ID)
                .Index(t => t.Announcement_ID)
                .Index(t => t.Contact_ID)
                .Index(t => t.Home_ID)
                .Index(t => t.Meeting_ID)
                .Index(t => t.Schedule_ID);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 30),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Position = c.String(nullable: false, maxLength: 100),
                        Phone = c.Long(),
                        EXT = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
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
                "dbo.Schedules",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.ID);
            
            AlterColumn("dbo.AspNetRoles", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.AspNetUsers", "UserName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Resources", "Schedule_ID", "dbo.Schedules");
            DropForeignKey("dbo.Announcements", "Schedule_ID", "dbo.Schedules");
            DropForeignKey("dbo.Resources", "Meeting_ID", "dbo.Meetings");
            DropForeignKey("dbo.Announcements", "Meeting_ID", "dbo.Meetings");
            DropForeignKey("dbo.Resources", "Home_ID", "dbo.Homes");
            DropForeignKey("dbo.Announcements", "Home_ID", "dbo.Homes");
            DropForeignKey("dbo.Resources", "Contact_ID", "dbo.Contacts");
            DropForeignKey("dbo.Announcements", "Contact_ID", "dbo.Contacts");
            DropForeignKey("dbo.Resources", "Announcement_ID", "dbo.Announcements");
            DropIndex("dbo.Resources", new[] { "Schedule_ID" });
            DropIndex("dbo.Resources", new[] { "Meeting_ID" });
            DropIndex("dbo.Resources", new[] { "Home_ID" });
            DropIndex("dbo.Resources", new[] { "Contact_ID" });
            DropIndex("dbo.Resources", new[] { "Announcement_ID" });
            DropIndex("dbo.Announcements", new[] { "Schedule_ID" });
            DropIndex("dbo.Announcements", new[] { "Meeting_ID" });
            DropIndex("dbo.Announcements", new[] { "Home_ID" });
            DropIndex("dbo.Announcements", new[] { "Contact_ID" });
            AlterColumn("dbo.AspNetUsers", "UserName", c => c.String());
            AlterColumn("dbo.AspNetRoles", "Name", c => c.String());
            DropTable("dbo.Schedules");
            DropTable("dbo.Meetings");
            DropTable("dbo.Homes");
            DropTable("dbo.DeathNotifications");
            DropTable("dbo.Contacts");
            DropTable("dbo.Resources");
            DropTable("dbo.Announcements");
            DropTable("dbo.Admins");
        }
    }
}
