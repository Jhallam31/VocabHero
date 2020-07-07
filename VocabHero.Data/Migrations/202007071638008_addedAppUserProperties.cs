namespace VocabHero.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedAppUserProperties : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ApplicationUser", "DisplayName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ApplicationUser", "DisplayName");
        }
    }
}
