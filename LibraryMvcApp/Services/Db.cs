using LibraryMvcApp.Models;
using System.Collections.Generic;

namespace LibraryMvcApp.Services
{
    public class Db
    {
        public List<AudioBook> AudioBooks = new List<AudioBook>();
        public List<Game> Games = new List<Game>();
        public List<MusicRecord> MusicRecords = new List<MusicRecord>();

        public List<Book> Books = new List<Book>();
        public List<Magazine> Magazines = new List<Magazine>();
    }
}