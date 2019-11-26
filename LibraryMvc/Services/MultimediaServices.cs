using LibraryMvc.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace LibraryMvc.Services
{
    public class MultimediaServices : IMultimediaServices
    {
        private ApplicationDbContext _db;
        private static readonly string _imagesDirectory = HttpContext.Current.Server.MapPath("~/Images");

        public MultimediaServices(ApplicationDbContext applicationDbContext)
        {
            _db = applicationDbContext;
            // InsertData();
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
            _db.SaveChanges();
        }

        public List<Multimedia> GetAllMultimedia()
        {
            _db = ApplicationDbContext.Create();
            var list = new List<Multimedia>();
            list.AddRange(_db.AudioBooks.ToList());
            list.AddRange(_db.Games.ToList());
            list.AddRange(_db.MusicRecords.ToList());
            list.AddRange(_db.Books.ToList());
            list.AddRange(_db.Magazines.ToList());
            return list;
        }

        public Multimedia GetObject(int id, string className)
        {
            _db = ApplicationDbContext.Create();
            dynamic foundObject;

            switch (className)
            {
                case "AudioBook":
                    foundObject = _db.AudioBooks.FirstOrDefault((x) => x.MultimediaID == id);               
                    break;
                case "Game":
                    foundObject = _db.Games.FirstOrDefault((x) => x.MultimediaID == id);
                    break;
                case "MusicRecord":
                    foundObject = _db.MusicRecords.FirstOrDefault((x) => x.MultimediaID == id);
                    break;
                case "Book":
                    foundObject = _db.Books.FirstOrDefault((x) => x.MultimediaID == id);
                    break;
                case "Magazine":
                    foundObject = _db.Magazines.FirstOrDefault((x) => x.MultimediaID == id);
                    break;
                default:
                    return null;
            }

            if (foundObject != null)
            {
                return foundObject;
            }
            else
            {
                return null;
            }
        }

        public void AddObject(Multimedia multimedia)
        {
            _db = ApplicationDbContext.Create();
            switch (multimedia)
            {
                case AudioBook audioBook:
                    _db.AudioBooks.Add(audioBook);
                    break;
                case Game game:
                    _db.Games.Add(game);
                    break;
                case MusicRecord musicRecord:
                    _db.MusicRecords.Add(musicRecord);
                    break;

                case Book book:
                    _db.Books.Add(book);
                    break;
                case Magazine magazine:
                    _db.Magazines.Add(magazine);
                    break;

                case null:
                default:
                    //TODO log error
                    return;
            }

            _db.SaveChanges();
        }

        public void EditObject(Multimedia multimedia)
        {
            _db = ApplicationDbContext.Create();
            switch (multimedia)
            {
                case AudioBook audioBook:
                    _db.AudioBooks.AddOrUpdate(audioBook);//.FirstOrDefault((x) => x.MultimediaID == multimedia.MultimediaID); 
                    break;
                case Game game:
                    _db.Games.AddOrUpdate(game);
                    break;
                case MusicRecord musicRecord:
                    _db.MusicRecords.AddOrUpdate(musicRecord);
                    break;
                case Book book:
                    _db.Books.AddOrUpdate(book);
                    break;
                case Magazine magazine:
                    _db.Magazines.AddOrUpdate(magazine);
                    break;

                case null:
                default:
                    //TODO log error
                    return;
            }
            
            _db.SaveChanges();
        }

        public static string NextPossibleFilename() //TODO add semaphore/lock
        {
            var fileNames = Directory.GetFiles(_imagesDirectory);
            List<int> fileNumbers = new List<int>();

            foreach (var name in fileNames)
            {
                var fileNameNumber = Regex.Match(name, @"(\d+(?=.*(?=\.)))(?!.*?(\d*\\))");

                if (int.TryParse(fileNameNumber.ToString(), out int number))
                {
                    fileNumbers.Add(number);
                }
            }

            fileNumbers.Sort();

            int FindLowestNumber()
            {
                int fileNumbersCount = fileNumbers.Count;

                for (int i = 0; i < fileNumbersCount; i++)
                {
                    if (fileNumbers[i] != i)
                    {
                        return i;
                    }
                }

                return fileNumbersCount;
            }         

            return string.Format("{0}.png", FindLowestNumber());
        }

        public void DeleteObject(int id, string className)
        {
            _db = ApplicationDbContext.Create();
            dynamic foundObject;

            switch (className)
            {
                case "AudioBook":
                    foundObject = _db.AudioBooks.FirstOrDefault((x) => x.MultimediaID == id); //todo select instead firstOrDefault
                    if (foundObject != null)
                    {
                        _db.AudioBooks.Remove(foundObject);
                    }
                    break;
                case "Game":
                    foundObject = _db.Games.FirstOrDefault((x) => x.MultimediaID == id);
                    if (foundObject != null)
                    {
                        _db.Games.Remove(foundObject);
                    }
                    break;
                case "MusicRecord":
                    foundObject = _db.MusicRecords.FirstOrDefault((x) => x.MultimediaID == id);
                    if (foundObject != null)
                    {
                        _db.MusicRecords.Remove(foundObject);
                    }
                    break;
                case "Book":
                    foundObject = _db.Books.FirstOrDefault((x) => x.MultimediaID == id);
                    if (foundObject != null)
                    {
                        _db.Books.Remove(foundObject);
                    }
                    break;
                case "Magazine":
                    foundObject = _db.Magazines.FirstOrDefault((x) => x.MultimediaID == id);
                    
                    if (foundObject != null)
                    {
                        _db.Magazines.Remove(foundObject);
                    }
                    break;
                default:
                    return;
            }

            TryDeleteCoverPhoto(foundObject);
            _db.SaveChanges();
        }

        public void DeleteCoverPhoto(int id, string className)
        {
            _db = ApplicationDbContext.Create();
            dynamic foundObject;

            switch (className)
            {
                case "AudioBook":
                    foundObject = _db.AudioBooks.FirstOrDefault((x) => x.MultimediaID == id);
                    break;
                case "Game":
                    foundObject = _db.Games.FirstOrDefault((x) => x.MultimediaID == id);
                    break;
                case "MusicRecord":
                    foundObject = _db.MusicRecords.FirstOrDefault((x) => x.MultimediaID == id);
                    break;
                case "Book":
                    foundObject = _db.Books.FirstOrDefault((x) => x.MultimediaID == id);
                    break;
                case "Magazine":
                    foundObject = _db.Magazines.FirstOrDefault((x) => x.MultimediaID == id);
                    break;
                default:
                    return;
            }

            if (foundObject != null)
            {
                TryDeleteCoverPhoto(foundObject);
                ((Multimedia)foundObject).CoverPhoto = string.Empty;
                _db.SaveChanges();
            }          
        }

        private void TryDeleteCoverPhoto(Multimedia multimedia)
        {
            if (!string.IsNullOrWhiteSpace(multimedia.CoverPhoto)) 
            {
                string filePath = string.Format("{0}\\{1}", _imagesDirectory, multimedia.CoverPhoto);

                if ((File.Exists(filePath)))
                {
                    File.Delete(filePath);
                }
            }
        }
    }
}