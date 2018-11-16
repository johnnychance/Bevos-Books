using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using fa18Team28_FinalProject.DAL;
using fa18Team28_FinalProject.Models;

namespace fa18Team28_FinalProject.Models
{
    public class ManagerOrderDetail
    {
        [Key]
        public Int32 ManagerOrderDetailID { get; set; }

        public Int32 Quantity { get; set; }

        [Display(Name = "Product Cost")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal ProductCost { get; set; }

        [Display(Name = "Extended Cost")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal ExtendedCost { get; set; }

        [Display(Name = "Manager Order Details Notes")]
        public Int32 ManagerOrderDetailsNotes { get; set; }

        public ManagerOrder ManagerOrder { get; set; }
        public Book Book { get; set; }
    }
}
