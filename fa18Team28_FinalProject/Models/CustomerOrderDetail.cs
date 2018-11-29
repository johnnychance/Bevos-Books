using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using fa18Team28_FinalProject.DAL;
using fa18Team28_FinalProject.Models;

namespace fa18Team28_FinalProject.Models
{    
    public class CustomerOrderDetail
    {        
        [Key]
        public Int32 CustomerOrderDetailID { get; set; }

        public Int32 Quantity { get; set; }

        [Display(Name = "Product Price")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal ProductPrice { get; set; }

        [Display(Name = "Extended Price")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal ExtendedPrice { get; set; }

        [Display(Name = "Customer Order Detail Notes")]
        public Int32 CustomerOrderDetailNotes { get; set; }
               
        //navigational property
        public CustomerOrder CustomerOrder { get; set; }
        public Book Book { get; set; }
    }
}
