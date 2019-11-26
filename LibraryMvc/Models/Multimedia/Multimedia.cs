﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryMvc.Models
{
    public abstract class Multimedia
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MultimediaID { get; set; }
        public string ClassName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public string CoverPhoto { get; set; }

        public Multimedia()
        {
            ClassName = this.GetType().Name;
        }
    }
}