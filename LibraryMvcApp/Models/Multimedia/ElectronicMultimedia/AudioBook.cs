using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LibraryMvcApp.Models
{
    public class AudioBook : ElectronicMultimedia
    {
        public string Lector { get; set; }
        public string Isbn { get; set; }
        public float Lenght { get; set; }
    }
}