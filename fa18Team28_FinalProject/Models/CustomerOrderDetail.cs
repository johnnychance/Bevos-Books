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
        private const Decimal TAX_RATE = 0.0825m;

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

        /*[Display(Name = "Order Subtotal")]        [DisplayFormat(DataFormatString = "{0:C}")]        public Decimal OrderSubtotal        {            get { return CustomerOrderDetail.Sum(od => od.ExtendedPrice); }        }

        [Display(Name = "OrderTax")]        [DisplayFormat(DataFormatString = "{0:C}")]        public Decimal OrderTax        {            get { return OrderSubtotal * TAX_RATE; }        }

        [Display(Name = "Order Total")]        [DisplayFormat(DataFormatString = "{0:C}")]        public Decimal OrderTotal        {            get { return OrderSubtotal + OrderTax; }        }*/
               
        //navigational property
        public CustomerOrder Order { get; set; }
        public Book Book { get; set; }
    }
}
