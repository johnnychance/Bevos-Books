using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using fa18Team28_FinalProject.DAL;
using fa18Team28_FinalProject.Models;

namespace fa18Team28_FinalProject.Models
{
    public enum DiscountType
    {
        PercentOff,
        FreeShipping,
    }

    public class Discount
    {
        [Key]
        public Int32 DiscountID { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 1)]
        public string DiscountCode { get; set; }

        public string Description { get; set; }

        [Required]
        public DiscountType Type { get; set; }

        [Display(Name = "Start Date")]
        [DisplayFormat(DataFormatString = "{0:MM/DD/YYYY}")]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        [DisplayFormat(DataFormatString = "{0:MM/DD/YYYY}")]
        public DateTime EndDate { get; set; }

        //navigational property
        public List<DiscountDetail> DiscountDetails { get; set; }
    }
}
