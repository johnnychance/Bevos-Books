using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fa18Team28_FinalProject.Models;

namespace fa18Team28_FinalProject.Models
{
    public class ShoppingCartViewModel
    {
        public List<CartItem> CartItems { get; set; }
        public decimal CartTotal { get; set; }
    }
}
