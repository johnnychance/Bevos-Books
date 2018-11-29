using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using fa18Team28_FinalProject.Models;

namespace fa18Team28_FinalProject.Models
{
    public class ProductDetail
    {
        [Key]
        public Int32 ProductDetailID { get; set; }

        public Book Book { get; set; }
        public Supplier Supplier { get; set; }
        
    }
}
