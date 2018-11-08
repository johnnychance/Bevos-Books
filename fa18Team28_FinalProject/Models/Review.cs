using System;
namespace fa18Team28_FinalProject.Models
{
    public class Review
    {
        public int ReviewID { get; set; }
        public string ReviewText { get; set; }
        public int Rating { get; set; }
        public string Author_user { get; set; }
        public string Approver_user { get; set; }

        //navigation properties
        public User Author { get; set; }
        public User Approver { get; set; }

    }
}
