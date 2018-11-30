using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using fa18Team28_FinalProject.DAL;
using fa18Team28_FinalProject.Models;

namespace fa18Team28_FinalProject.Models
{
    public class AppUser : IdentityUser
    {
        //[Key]
        //public Int32 AppUserID { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public string Password { get; set; }
        //public string Email { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        //public string PhoneNumber { get; set; }
        public Int32 CreditCard1 { get; set; }
        public Int32 CreditCard2 { get; set; }
        public Int32 CreditCard3 { get; set; }
        public Int32 NumberofOrders { get; set; }
        public string ReviewsWritten { get; set; }
        public string ReviewsApproved { get; set; }
        public bool Active { get; set; }

        public List<CustomerOrder> CustomerOrders { get; set; }
        public List<ManagerOrder> ManagerOrders { get; set; }
    }
}

