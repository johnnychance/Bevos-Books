using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace fa18Team28_FinalProject.Models
{
    public class CartItem
    {
        [Key]
        public string ItemID { get; set; }

        public string CartID { get; set; }

        public int Quantity { get; set; }

        public System.DateTime DateCreated { get; set; }

        //public int BookID { get; set; }

        

        public List<CustomerOrderDetail> CustomerOrderDetails { get; set; }
        public Book Book { get; set; }


    }
}
