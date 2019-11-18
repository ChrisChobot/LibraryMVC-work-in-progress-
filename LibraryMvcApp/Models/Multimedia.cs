using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryMvcApp.Models
{
    public abstract class Multimedia
    {
        public string ClassName;
        public string Title;
        public string Description;
        public string Author;
        public string Publisher;
        public float Value;

        public Multimedia()
        {
            ClassName = this.GetType().Name;
        }
    }
}