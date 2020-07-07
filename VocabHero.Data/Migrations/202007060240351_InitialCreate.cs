namespace VocabHero.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FlashCard",
                c => new
                    {
                        FlashCardId = c.Int(nullable: false, identity: true),
                        Word = c.String(nullable: false),
                        Definition = c.String(nullable: false),
                        PartOfSpeech = c.Int(nullable: false),
                        FlashCard_FlashCardId = c.Int(),
                    })
                .PrimaryKey(t => t.FlashCardId)
                .ForeignKey("dbo.FlashCard", t => t.FlashCard_FlashCardId)
                .Index(t => t.FlashCard_FlashCardId);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.UserFlashCard",
                c => new
                    {
                        UserCardId = c.Int(nullable: false, identity: true),
                        FlashCardId = c.Int(nullable: false),
                        Id = c.String(maxLength: 128),
                        UserFlashCard_UserCardId = c.Int(),
                    })
                .PrimaryKey(t => t.UserCardId)
                .ForeignKey("dbo.ApplicationUser", t => t.Id)
                .ForeignKey("dbo.FlashCard", t => t.FlashCardId, cascadeDelete: true)
                .ForeignKey("dbo.UserFlashCard", t => t.UserFlashCard_UserCardId)
                .Index(t => t.FlashCardId)
                .Index(t => t.Id)
                .Index(t => t.UserFlashCard_UserCardId);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserFlashCard", "UserFlashCard_UserCardId", "dbo.UserFlashCard");
            DropForeignKey("dbo.UserFlashCard", "FlashCardId", "dbo.FlashCard");
            DropForeignKey("dbo.UserFlashCard", "Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.FlashCard", "FlashCard_FlashCardId", "dbo.FlashCard");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.UserFlashCard", new[] { "UserFlashCard_UserCardId" });
            DropIndex("dbo.UserFlashCard", new[] { "Id" });
            DropIndex("dbo.UserFlashCard", new[] { "FlashCardId" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.FlashCard", new[] { "FlashCard_FlashCardId" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.UserFlashCard");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.FlashCard");
        }
    }
}
