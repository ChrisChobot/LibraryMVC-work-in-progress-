namespace LibraryMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixedVariables : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AudioBooks", "Size", c => c.Single(nullable: false));
            AddColumn("dbo.Books", "Isbn", c => c.String());
            AddColumn("dbo.Games", "OverEightteenYears", c => c.String());
            AddColumn("dbo.Games", "Size", c => c.Single(nullable: false));
            AddColumn("dbo.MusicRecords", "Lenght", c => c.Single(nullable: false));
            AddColumn("dbo.MusicRecords", "Size", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MusicRecords", "Size");
            DropColumn("dbo.MusicRecords", "Lenght");
            DropColumn("dbo.Games", "Size");
            DropColumn("dbo.Games", "OverEightteenYears");
            DropColumn("dbo.Books", "Isbn");
            DropColumn("dbo.AudioBooks", "Size");
        }
    }
}
