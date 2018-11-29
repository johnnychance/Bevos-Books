using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using fa18Team28_FinalProject.DAL;
using fa18Team28_FinalProject.Models;

namespace fa18Team28_FinalProject.Models
{
    public class Review
    {
        [Key]
        public int ReviewID { get; set; }

        public string ReviewText { get; set; }

        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5")]
        public int Rating { get; set; }

        [Display(Name = "Author User")]
        public string Author_user { get; set; }

        [Display(Name = "Approver User")]
        public string Approver_user { get; set; }

        //navigation properties
        public AppUser Author { get; set; }
        public AppUser Approver { get; set; }
        public Book Book { get; set; }

    }
}
