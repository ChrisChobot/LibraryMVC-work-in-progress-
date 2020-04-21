namespace LibraryMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixedVariablesInModelsForSure : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "TableOfContents", c => c.String());
            AddColumn("dbo.Books", "PagesCount", c => c.Int(nullable: false));
            AddColumn("dbo.Magazines", "Number", c => c.String());
            AddColumn("dbo.Magazines", "Gift", c => c.String());
            AddColumn("dbo.Magazines", "GiftName", c => c.String());
            AddColumn("dbo.Magazines", "TableOfContents", c => c.String());
            AddColumn("dbo.Magazines", "PagesCount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Magazines", "PagesCount");
            DropColumn("dbo.Magazines", "TableOfContents");
            DropColumn("dbo.Magazines", "GiftName");
            DropColumn("dbo.Magazines", "Gift");
            DropColumn("dbo.Magazines", "Number");
            DropColumn("dbo.Books", "PagesCount");
            DropColumn("dbo.Books", "TableOfContents");
        }
    }
}
