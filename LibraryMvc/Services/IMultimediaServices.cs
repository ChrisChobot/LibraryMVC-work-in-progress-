using LibraryMvc.Models;
using System.Collections.Generic;

namespace LibraryMvc.Services
{
    public interface IMultimediaServices
    {
        List<Multimedia> GetAllMultimedia();
        Multimedia GetObject(int id, string className);
        void AddObject(Multimedia multimedia);
        void EditObject(Multimedia multimedia);
        void DeleteObject(int id, string className);
        void DeleteCoverPhoto(int id, string className);
    }
}