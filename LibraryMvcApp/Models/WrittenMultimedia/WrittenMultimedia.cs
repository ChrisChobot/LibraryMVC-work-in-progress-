using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryMvcApp.Models
{
    public abstract class WrittenMultimedia : Multimedia
    {
        string TableOfContents;
        string CoverPhoto;
        int PagesCount;
    }
}