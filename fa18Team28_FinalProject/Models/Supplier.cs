using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using fa18Team28_FinalProject.Models;

namespace fa18Team28_FinalProject.Models
{
    public class Supplier
    {
        [Key]
        public int SupplierID { get; set; }

        [Display(Name = "Supplier Name")]
        [Required(ErrorMessage = "Please include the supplier's name")]
        public string SupplierName { get; set; }

        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Please enter the supplier's email address")]
        [RegularExpression(".+\\@.+\\..+",
                                    ErrorMessage = "Please enter a valid email address")]
        public string SupplierEmail { get; set; }

        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Please enter the supplier's phone number")]
        public string SupplierPhone { get; set; }

        [Display(Name = "Established Date")]
        [Required(ErrorMessage = "Please enter the established date")]
        public DateTime EstablishedDate { get; set; }

        [Display(Name = "Preferred Supplier")]
        public bool PreferredSupplier { get; set; }

        [Display(Name = "Notes")]
        public string SupplierNotes { get; set; }

        public List<ProductDetail> ProductDetails { get; set; }

        public Supplier()
        {
            if (ProductDetails == null)
            {
                ProductDetails = new List<ProductDetail>();
            }
        }
    }
}
