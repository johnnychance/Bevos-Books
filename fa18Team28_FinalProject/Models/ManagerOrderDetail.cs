using System;
namespace fa18Team28_FinalProject.Models
{
    public class ManagerOrderDetail
    {
        public Int32 ManagerOrderDetailID { get; set; }
        public Int32 Quantity { get; set; }
        public decimal Cost { get; set; }
        public Int32 ManagerOrderDetails { get; set; }

        public virtual ManagerOrder Order { get; set; }
        public virtual Book Book { get; set; }
    }
}
