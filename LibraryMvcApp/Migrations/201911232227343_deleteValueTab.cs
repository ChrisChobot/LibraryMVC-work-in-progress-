namespace LibraryMvcApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteValueTab : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AudioBooks", "Value");
            DropColumn("dbo.Books", "Value");
            DropColumn("dbo.Games", "Value");
            DropColumn("dbo.Magazines", "Value");
            DropColumn("dbo.MusicRecords", "Value");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MusicRecords", "Value", c => c.Single(nullable: false));
            AddColumn("dbo.Magazines", "Value", c => c.Single(nullable: false));
            AddColumn("dbo.Games", "Value", c => c.Single(nullable: false));
            AddColumn("dbo.Books", "Value", c => c.Single(nullable: false));
            AddColumn("dbo.AudioBooks", "Value", c => c.Single(nullable: false));
        }
    }
}
