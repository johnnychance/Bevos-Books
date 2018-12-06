using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using fa18Team28_FinalProject.DAL;
using fa18Team28_FinalProject.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace fa18Team28_FinalProject.Models
{
    public class ManagerOrderDetail
    {
        [Key]
        public Int32 ManagerOrderDetailID { get; set; }

        [Range(1, 1500000, ErrorMessage = "The value must be more than 1.")]
        public Int32 Quantity { get; set; }

        [Display(Name = "Product Cost")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal ProductCost { get; set; }

        [Display(Name = "Extended Cost")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal ExtendedCost { get; set; }

        [Display(Name = "Manager Order Details Notes")]
        public Int32 ManagerOrderDetailsNotes { get; set; }

        public ManagerOrder ManagerOrder { get; set; }
        public Book Book { get; set; }
    }
}
