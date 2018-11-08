using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fa18Team28_FinalProject.Models
{
    public class CustomerOrder
    {
        public Int32 CustomerOrderID { get; set; }

        public DateTime CustomerOrderDate { get; set; }

        public String CustomerOrderDetail { get; set; }

        //navigational properties
        public virtual User User { get; set; }
        public virtual List<CustomerOrderDetail> CustomerOrderDetails { get; set; }
    }
}
