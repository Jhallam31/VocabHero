namespace VocabHero.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateToday : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FlashCardUserAttempt", "AttemptSuccessful", c => c.Boolean(nullable: false));
            DropColumn("dbo.FlashCardUserAttempt", "IsSuccessful");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FlashCardUserAttempt", "IsSuccessful", c => c.Boolean(nullable: false));
            DropColumn("dbo.FlashCardUserAttempt", "AttemptSuccessful");
        }
    }
}
