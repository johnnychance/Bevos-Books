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
    public class Book
    {
        [Key]
        public Int32 BookID { get; set; }
        
        [Display(Name = "Published Date")]
        [DataType(DataType.Date)]
        public DateTime PublishedDate { get; set; }

        [Display(Name = "Unique ID")]
        public Int32 UniqueID { get; set; }
                
        public string Title { get; set; }
                
        public string Author { get; set; }

        public string Description { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [DisplayFormat(DataFormatString ="{0:C}")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Cost { get; set; }

        public Int32 Reordered { get; set; }

        public Int32 PurchaseCount { get; set; }

        [Display(Name = "Copies On Hand")]
        public Int32 CopiesOnHand { get; set; }

        [Display(Name = "Last Ordered")]
        [DataType(DataType.Date)]
        public DateTime LastOrdered { get; set; }

        //profit margin
        [Display(Name = "Profit Margin")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal ProfitMargin
        {
            get { return Price - Cost; }
        }

        //navigational properties for book
        public Genre Genre { get; set; }
        public List<CustomerOrderDetail> CustomerOrderDetails { get; set; }
        public List<ManagerOrderDetail> ManagerOrderDetails { get; set; }

        public List<Review> Reviews { get; set; }
        public List<ProductDetail> ProductDetails { get; set; }
        public List<CartItem> CartItems { get; set; }



    }
}
