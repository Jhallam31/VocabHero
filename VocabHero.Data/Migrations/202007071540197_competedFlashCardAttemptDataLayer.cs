namespace VocabHero.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class competedFlashCardAttemptDataLayer : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FlashCardUserAttempt",
                c => new
                    {
                        UserAttemptId = c.Int(nullable: false, identity: true),
                        IsSuccessful = c.Boolean(nullable: false),
                        UserCardId = c.Int(nullable: false),
                        RankAdd = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserAttemptId)
                .ForeignKey("dbo.UserFlashCard", t => t.UserCardId)
                .Index(t => t.UserCardId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FlashCardUserAttempt", "UserCardId", "dbo.UserFlashCard");
            DropIndex("dbo.FlashCardUserAttempt", new[] { "UserCardId" });
            DropTable("dbo.FlashCardUserAttempt");
        }
    }
}
