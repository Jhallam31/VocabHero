namespace VocabHero.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newMigrate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FlashCard", "FlashCard_FlashCardId", "dbo.FlashCard");
            DropForeignKey("dbo.UserFlashCard", "UserFlashCard_UserCardId", "dbo.UserFlashCard");
            DropForeignKey("dbo.UserFlashCard", "FlashCardId", "dbo.FlashCard");
            DropIndex("dbo.FlashCard", new[] { "FlashCard_FlashCardId" });
            DropIndex("dbo.UserFlashCard", new[] { "Id" });
            DropIndex("dbo.UserFlashCard", new[] { "UserFlashCard_UserCardId" });
            RenameColumn(table: "dbo.UserFlashCard", name: "Id", newName: "UserID");
            AlterColumn("dbo.UserFlashCard", "UserID", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.UserFlashCard", "UserID");
            AddForeignKey("dbo.UserFlashCard", "FlashCardId", "dbo.FlashCard", "FlashCardId");
            DropColumn("dbo.FlashCard", "FlashCard_FlashCardId");
            DropColumn("dbo.UserFlashCard", "UserFlashCard_UserCardId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserFlashCard", "UserFlashCard_UserCardId", c => c.Int());
            AddColumn("dbo.FlashCard", "FlashCard_FlashCardId", c => c.Int());
            DropForeignKey("dbo.UserFlashCard", "FlashCardId", "dbo.FlashCard");
            DropIndex("dbo.UserFlashCard", new[] { "UserID" });
            AlterColumn("dbo.UserFlashCard", "UserID", c => c.String(maxLength: 128));
            RenameColumn(table: "dbo.UserFlashCard", name: "UserID", newName: "Id");
            CreateIndex("dbo.UserFlashCard", "UserFlashCard_UserCardId");
            CreateIndex("dbo.UserFlashCard", "Id");
            CreateIndex("dbo.FlashCard", "FlashCard_FlashCardId");
            AddForeignKey("dbo.UserFlashCard", "FlashCardId", "dbo.FlashCard", "FlashCardId", cascadeDelete: false);
            AddForeignKey("dbo.UserFlashCard", "UserFlashCard_UserCardId", "dbo.UserFlashCard", "UserCardId");
            AddForeignKey("dbo.FlashCard", "FlashCard_FlashCardId", "dbo.FlashCard", "FlashCardId");
        }
    }
}
