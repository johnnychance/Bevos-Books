using System;
namespace fa18Team28_FinalProject.Models
{
    public class ManagerOrder
    {
        public int ManagerOrderID { get; set; }
        public DateTime ManagerOrderDate { get; set; }
        public String ManagerOrderDetail { get; set; }

        //navigation properties
        public virtual User User { get; set; }
        public virtual List<ManagerOrderDetail> ManagerOrderDetails { get; set; }

    }
}
