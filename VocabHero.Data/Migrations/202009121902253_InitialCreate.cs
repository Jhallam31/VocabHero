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
                    })
                .PrimaryKey(t => t.FlashCardId);
            
            CreateTable(
                "dbo.UserFlashCard",
                c => new
                    {
                        UserCardId = c.Int(nullable: false, identity: true),
                        FlashCardId = c.Int(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 128),
                        UserFlashCard_UserCardId = c.Int(),
                    })
                .PrimaryKey(t => t.UserCardId)
                .ForeignKey("dbo.ApplicationUser", t => t.UserId)
                .ForeignKey("dbo.FlashCard", t => t.FlashCardId, cascadeDelete: true)
                .ForeignKey("dbo.UserFlashCard", t => t.UserFlashCard_UserCardId)
                .Index(t => t.FlashCardId)
                .Index(t => t.UserId)
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
                "dbo.FlashCardUserAttempt",
                c => new
                    {
                        UserAttemptId = c.Int(nullable: false, identity: true),
                        IsSuccessful = c.Boolean(nullable: false),
                        UserCardId = c.Int(nullable: false),
                        Guess = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserAttemptId)
                .ForeignKey("dbo.UserFlashCard", t => t.UserCardId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.UserCardId)
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
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                        IdentityRole_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.UserFlashCard", "UserFlashCard_UserCardId", "dbo.UserFlashCard");
            DropForeignKey("dbo.UserFlashCard", "FlashCardId", "dbo.FlashCard");
            DropForeignKey("dbo.UserFlashCard", "UserId", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.FlashCardUserAttempt", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.FlashCardUserAttempt", "UserCardId", "dbo.UserFlashCard");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.FlashCardUserAttempt", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.FlashCardUserAttempt", new[] { "UserCardId" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.UserFlashCard", new[] { "UserFlashCard_UserCardId" });
            DropIndex("dbo.UserFlashCard", new[] { "UserId" });
            DropIndex("dbo.UserFlashCard", new[] { "FlashCardId" });
            DropTable("dbo.IdentityRole");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.FlashCardUserAttempt");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.UserFlashCard");
            DropTable("dbo.FlashCard");
        }
    }
}
