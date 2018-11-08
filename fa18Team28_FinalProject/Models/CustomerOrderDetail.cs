using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fa18Team28_FinalProject.Models
{
    public class CustomerOrderDetail
    {
        public Int32 CustomerOrderDetailID { get; set; }

        public Int32 Quantity { get; set; }

        public decimal Price { get; set; }

        public Int32 CustomerOrderDetails { get; set; }

        //navigational property
        public virtual CustomerOrder Order { get; set; }

        public virtual Book Book { get; set; }
    }
}
