using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using fa18Team28_FinalProject.DAL;
using fa18Team28_FinalProject.Models;

namespace fa18Team28_FinalProject.Models
{
    public class User
    {
        [Key]
        public Int32 UserID { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public Int32 Zipcode { get; set; }
        public Int32 PhoneNumber { get; set; }
        public Int32 CreditCard1 { get; set; }
        public Int32 CreditCard2 { get; set; }
        public Int32 CreditCard3 { get; set; }
        public Int32 NumberofOrders { get; set; }
        public string ReviewsWritten { get; set; }
        public string ReviewsApproved { get; set; }
        public bool Active { get; set; }

        public virtual List<CustomerOrder> CustomerOrders { get; set; }
    }
}

