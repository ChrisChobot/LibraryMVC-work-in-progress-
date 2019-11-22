using LibraryMvcApp.Models;
using System.Collections.Generic;

namespace LibraryMvcApp.Services
{
    public interface IMultimediaServices
    {
        List<Multimedia> GetAllMultimedia();
        void AddObject(Multimedia multimedia);
    }
}