namespace LibraryMvcApp.Services
{
    using LibraryMvcApp.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class MultimediaUsersDbContext : DbContext
    {
        // Your context has been configured to use a 'MultimediaUsersDbContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'LibraryMvcApp.Services.MultimediaUsersDbContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'MultimediaUsersDbContext' 
        // connection string in the application configuration file.
        public MultimediaUsersDbContext()
            : base("name=MultimediaUsersDbContext")
        {
        }
        
        public DbSet<AudioBook> AudioBooks { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<MusicRecord> MusicRecords { get; set; }

        public DbSet<Book> Books { get; set; }
        public DbSet<Magazine> Magazines { get; set; }
    }
}