namespace LibraryMvcApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class littleCleanUp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AudioBooks", "CoverPhoto", c => c.String());
            AddColumn("dbo.Books", "CoverPhoto", c => c.String());
            AddColumn("dbo.Games", "CoverPhoto", c => c.String());
            AddColumn("dbo.Magazines", "CoverPhoto", c => c.String());
            AddColumn("dbo.MusicRecords", "CoverPhoto", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MusicRecords", "CoverPhoto");
            DropColumn("dbo.Magazines", "CoverPhoto");
            DropColumn("dbo.Games", "CoverPhoto");
            DropColumn("dbo.Books", "CoverPhoto");
            DropColumn("dbo.AudioBooks", "CoverPhoto");
        }
    }
}
