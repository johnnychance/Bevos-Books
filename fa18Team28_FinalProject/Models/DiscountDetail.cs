using System;
namespace fa18Team28_FinalProject.Models
{
    public class DiscountDetail
    {
        public Int32 DiscountDetailID { get; set; }

        //navigational property
        public CustomerOrder CustomerOrder { get; set; }
        public Discount Discount { get; set; }
    }
}
