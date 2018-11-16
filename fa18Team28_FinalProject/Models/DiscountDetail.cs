using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using fa18Team28_FinalProject.DAL;
using fa18Team28_FinalProject.Models;

namespace fa18Team28_FinalProject.Models
{
    public class DiscountDetail
    {
        [Key]
        public Int32 DiscountDetailID { get; set; }

        //navigational property
        public CustomerOrder CustomerOrder { get; set; }
        public Discount Discount { get; set; }
    }
}
