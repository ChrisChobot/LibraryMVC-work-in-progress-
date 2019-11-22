namespace LibraryMvcApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AudioBooks",
                c => new
                    {
                        MultimediaID = c.Int(nullable: false, identity: true),
                        Lector = c.String(),
                        Isbn = c.String(),
                        Lenght = c.Single(nullable: false),
                        ClassName = c.String(),
                        Title = c.String(),
                        Description = c.String(),
                        Author = c.String(),
                        Publisher = c.String(),
                        Value = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.MultimediaID);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        MultimediaID = c.Int(nullable: false, identity: true),
                        ClassName = c.String(),
                        Title = c.String(),
                        Description = c.String(),
                        Author = c.String(),
                        Publisher = c.String(),
                        Value = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.MultimediaID);
            
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        MultimediaID = c.Int(nullable: false, identity: true),
                        ClassName = c.String(),
                        Title = c.String(),
                        Description = c.String(),
                        Author = c.String(),
                        Publisher = c.String(),
                        Value = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.MultimediaID);
            
            CreateTable(
                "dbo.Magazines",
                c => new
                    {
                        MultimediaID = c.Int(nullable: false, identity: true),
                        ClassName = c.String(),
                        Title = c.String(),
                        Description = c.String(),
                        Author = c.String(),
                        Publisher = c.String(),
                        Value = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.MultimediaID);
            
            CreateTable(
                "dbo.MusicRecords",
                c => new
                    {
                        MultimediaID = c.Int(nullable: false, identity: true),
                        ClassName = c.String(),
                        Title = c.String(),
                        Description = c.String(),
                        Author = c.String(),
                        Publisher = c.String(),
                        Value = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.MultimediaID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MusicRecords");
            DropTable("dbo.Magazines");
            DropTable("dbo.Games");
            DropTable("dbo.Books");
            DropTable("dbo.AudioBooks");
        }
    }
}
