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

        public const Decimal SALES_TAX = 0.0825m;

        [Key]
        public Int32 CustomerOrderID { get; set; }

        [Display(Name = "Customer Order Number")]
        public int CustomerOrderNumber { get; set; }

        [Display(Name="Customer Order Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime CustomerOrderDate { get; set; }

        [Display(Name = "Customer Order Status")]
        public bool CustomerOrderStatus { get; set; }

        [Display(Name = "Customer Order Notes")]        
        public String CustomerOrderNotes { get; set; }

        [Display(Name = "Customer Order Subtotal")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal CustomerOrderSubtotal
        {
            get { return CustomerOrderDetails.Sum(rd => rd.ExtendedPrice); }
        }

        [Display(Name = "Sales Tax (8.25%)")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal SalesTax
        {
            get { return CustomerOrderSubtotal * SALES_TAX; }
        }

        [Display(Name = "Customer Order Total")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal CustomerOrderTotal
        {
            get { return CustomerOrderSubtotal + SalesTax; } 
        }

        //navigational properties
        public AppUser AppUser { get; set; }
        public List<CustomerOrderDetail> CustomerOrderDetails { get; set; }
        public List<DiscountDetail> DiscountDetails { get; set; }

        public CustomerOrder()
        {
            if (CustomerOrderDetails == null)
            {
                CustomerOrderDetails = new List<CustomerOrderDetail>();
            }
        }
    }
}
