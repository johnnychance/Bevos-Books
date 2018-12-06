using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using fa18Team28_FinalProject.DAL;
using fa18Team28_FinalProject.Models;

namespace fa18Team28_FinalProject.Models
{
    public class ManagerOrder
    {

        public const Decimal M_SALES_TAX = 0.0825m;

        [Key]
        public int ManagerOrderID { get; set; }

        [Display(Name = "Manager Order Number")]
        public int ManagerOrderNumber { get; set; }

        [Display(Name = "Manager Order Date")]
        [DisplayFormat(DataFormatString = "{0:MM/DD/YYYY}")]
        public DateTime ManagerOrderDate { get; set; }

        [Display(Name = "Manager Order Status")]
        public bool ManagerOrderStatus { get; set; }

        [Display(Name = "Manager Order Detail Notes")]
        public String ManagerOrderDetailNotes { get; set; }

        [Display(Name = "Manager Order Subtotal")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal ManagerOrderSubtotal
        {
            get { return ManagerOrderDetails.Sum(rd => rd.ExtendedCost); }
        }

        [Display(Name = "Sales Tax (8.25%)")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal SalesTax
        {
            get { return ManagerOrderSubtotal * M_SALES_TAX; }
        }

        [Display(Name = "Manager Total")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal ManagerOrderTotal
        {
            get { return ManagerOrderSubtotal + M_SALES_TAX; }
        }

        //navigation properties
        public AppUser AppUser { get; set; }
        public List<ManagerOrderDetail> ManagerOrderDetails { get; set; }

        public ManagerOrder()
        {
            if (ManagerOrderDetails == null)
            {
                ManagerOrderDetails = new List<ManagerOrderDetail>();
            }
        }
    }
}
