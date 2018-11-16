using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using fa18Team28_FinalProject.DAL;
using fa18Team28_FinalProject.Models;

namespace fa18Team28_FinalProject.Models
{
    public class ManagerOrder
    {
        [Key]
        public int ManagerOrderID { get; set; }

        [Display(Name = "Manager Order Date")]
        [DisplayFormat(DataFormatString = "{0:MM/DD/YYYY}")]
        public DateTime ManagerOrderDate { get; set; }

        [Display(Name = "Manager Order Detail Notes")]
        public String ManagerOrderDetailNotes { get; set; }

        //navigation properties
        public User User { get; set; }
        public List<ManagerOrderDetail> ManagerOrderDetails { get; set; }

    }
}
