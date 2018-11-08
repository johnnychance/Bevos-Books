using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace fa18Team28_FinalProject.Models
{
    public class Book
    {
        public Int32 BookID { get; set; }

        [Display(Name = "Published Date")]
        [DataType(DataType.Date)]
        public DateTime PublishedDate { get; set; }

        public Int32 UniqueID { get; set; }

        public String Title { get; set; }

        public String Author { get; set; }

        public String Description { get; set; }

        public Decimal Price { get; set; }

        public Decimal Cost { get; set; }

        public Int32 Reordered { get; set; }

        [Display(Name = "Copies On Hand")]
        public Int32 CopiesOnHand { get; set; }

        [Display(Name = "Last Ordered")]
        [DataType(DataType.Date)]
        public DateTime LastOrdered { get; set; }

        //navigational property for language
        public Genre Genre { get; set; }

    }
}
