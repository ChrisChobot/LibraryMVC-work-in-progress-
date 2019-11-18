﻿using LibraryMvcApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryMvcApp.Services
{
    public class MultimediaServices : IMultimediaServices
    {
        private Db _db;

        public MultimediaServices()
        {
            _db = new Db();
            InsertData();
        }

        public void InsertData()
        {
            AudioBook audioBook = new AudioBook
            {
                Title = "AudioBook"
            }; AudioBook audioBook1 = new AudioBook
            {
                Title = "AudioBook1"
            };
            Game game = new Game
            {
                Title = "Game"
            };
            Game game1 = new Game
            {
                Title = "Game1"
            };
            MusicRecord musicRecord = new MusicRecord
            {
                Title = "MusicRecord"
            };
            MusicRecord musicRecord1 = new MusicRecord
            {
                Title = "MusicRecord1"
            };
            Book book = new Book
            {
                Title = "Book",
                Isbn = "3213ff"
            };
            Book book1 = new Book
            {
                Title = "Book1",
                Isbn = "dsadawd66"
            };
            Magazine magazine = new Magazine
            {
                Title = "Magazine"
            };
            Magazine magazine1 = new Magazine
            {
                Title = "Magazine1"
            };
                        
            _db.AudioBooks.Add(audioBook);
            _db.AudioBooks.Add(audioBook1);
            _db.Games.Add(game);
            _db.Games.Add(game1);
            _db.MusicRecords.Add(musicRecord);
            _db.MusicRecords.Add(musicRecord1);
            _db.Books.Add(book);
            _db.Books.Add(book1);
            _db.Magazines.Add(magazine);
            _db.Magazines.Add(magazine1);
        }

        public List<Multimedia> GetAllMultimedia()
        {
            var list = new List<Multimedia>();
            list.AddRange(_db.AudioBooks.ToList());
            list.AddRange(_db.Games.ToList());
            list.AddRange(_db.MusicRecords.ToList());
            list.AddRange(_db.Books.ToList());
            list.AddRange(_db.Magazines.ToList());
            return list;
        }
    }
}