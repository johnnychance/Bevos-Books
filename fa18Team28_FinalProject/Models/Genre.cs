using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace fa18Team28_FinalProject.Models
{
    public class Language
    {
        public Int32 GenreID { get; set; }

        public String Name { get; set; }

        //navigational properties
        public List<Book> Books { get; set; }
    }
}
