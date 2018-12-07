using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace fa18Team28_FinalProject.Models
{
   
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {

        //TODO:  Add any fields that you need for creating a new user

        //NOTE: Here is the property for email
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        //NOTE: Here is the logic for putting in a password
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        [Display(Name = "First Name")]
        public String FirstName { get; set; }

        //Additional fields go here
        [Required(ErrorMessage = "Last name is required.")]
        [Display(Name = "Last Name")]
        public String LastName { get; set; }

        //street address
        [Required(ErrorMessage = "Street Address is required.")]
        [Display(Name = "Street Address")]
        public String StreetAddress { get; set; }

        //City
        [Required(ErrorMessage = "City is required.")]
        [Display(Name = "City")]
        public String City { get; set; }

        //State
        [Required(ErrorMessage = "State is required.")]
        [Display(Name = "State")]
        public String State { get; set; }

        //Zipcode
        [Required(ErrorMessage = "Zipcode is required.")]
        [Display(Name = "Zipcode")]
        public String Zipcode { get; set; }

        //NOTE: Here is the property for phone number
        [Required(ErrorMessage = "Phone number is required")]
        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        //Birthday (Malik)
        [Display(Name = "Birthday")]
        public string Birthday { get; set; }

        //SSN (Malik)
        [Display(Name = "Social Security Number")]
        public string SSN { get; set; }

        //Middle Initial (Malik)
        [Display(Name = "Middle Initial")]
        public string MiddleInitial { get; set; }
    }
    public class ChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class EditViewModel
    {
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }
    }

    public class IndexViewModel
    {
        public bool HasPassword { get; set; }
        public String UserName { get; set; }
        public String Email { get; set; }
        public String UserID { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String StreetAddress { get; set; }
        public String PhoneNumber { get; set; }
    }

    public class CreditCardViewModel
    {
        [Display(Name = "Credit Card 1")]
        [StringLength(16, ErrorMessage = "Credit Cards must be 16 characters long.", MinimumLength = 16)]
        public string CreditCard1 { get; set; }

        [Display(Name = "Credit Card 2")]
        [StringLength(16, ErrorMessage = "Credit Cards must be 16 characters long.", MinimumLength = 16)]
        public string CreditCard2 { get; set; }

        [Display(Name = "Credit Card 3")]
        [StringLength(16, ErrorMessage = "Credit Cards must be 16 characters long.", MinimumLength = 16)]
        public string CreditCard3 { get; set; }
    }
}
