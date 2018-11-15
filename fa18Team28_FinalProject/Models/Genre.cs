using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using fa18Team28_FinalProject.DAL;
using fa18Team28_FinalProject.Models;

namespace fa18Team28_FinalProject.Models
{
    public class Genre
    {
        [Key]
        public Int32 GenreID { get; set; }

        [Display(Name = "Genre Name")]
        public string GenreName { get; set; }

        //navigational properties
        public List<Book> Books { get; set; }
    }
}
