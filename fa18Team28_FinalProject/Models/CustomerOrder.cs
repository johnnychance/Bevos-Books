using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using fa18Team28_FinalProject.DAL;
using fa18Team28_FinalProject.Models;

namespace fa18Team28_FinalProject.Models
{
    public class CustomerOrder
    {
        [Key]
        public Int32 CustomerOrderID { get; set; }

        [Display(Name="Customer Order Date")]
        [DisplayFormat(DataFormatString = "{0:MM/DD/YYYY}")]
        public DateTime CustomerOrderDate { get; set; }

        [Display(Name = "Customer Order Notes")]        
        public String CustomerOrderNotes { get; set; }

        //navigational properties
        public User User { get; set; }
        public List<CustomerOrderDetail> CustomerOrderDetails { get; set; }
        public List<DiscountDetail> DiscountDetails { get; set; }
    }
}
