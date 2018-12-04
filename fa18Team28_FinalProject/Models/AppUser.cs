using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; 
using fa18Team28_FinalProject.DAL;
using fa18Team28_FinalProject.Models;

namespace fa18Team28_FinalProject.Models
{
    public class AppUser : IdentityUser
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleInitial { get; set; }
        public string SSN { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public string Birthday { get; set; }
        public Int32 CreditCard1 { get; set; }
        public Int32 CreditCard2 { get; set; }
        public Int32 CreditCard3 { get; set; }
        public Int32 NumberofOrders { get; set; }
        public bool Active { get; set; }

        //navigational properties
        public List<CustomerOrder> CustomerOrders { get; set; }
        public List<ManagerOrder> ManagerOrders { get; set; }

        [InverseProperty("Author")]
        public List<Review> ReviewsWritten { get; set; }

        [InverseProperty("Approver")]
        public List<Review> ReviewsApproved { get; set; }
    }
}

