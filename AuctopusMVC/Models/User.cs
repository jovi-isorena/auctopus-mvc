using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AuctopusMVC.Models
{

    public class User
    {
        public int UserId { get; set; }
        [Required]
        [Display(Name="First Name")]
        [StringLength(100, ErrorMessage="First Name must be {2} - {1} characters.", MinimumLength=2)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Last Name must be {2} - {1} characters.", MinimumLength = 2)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Confirm Email")]
        [Compare("Email", ErrorMessage = "Emails do not match. Please try again.")]
        [DataType(DataType.EmailAddress)]
        public string ConfirmEmail { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [StringLength(24, ErrorMessage = "Password must be {2} - {1} characters.", MinimumLength = 6)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Passwords do not match. Please try again.")]
        public string ConfirmPassword { get; set; }
        
    }
    public class LoginModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [StringLength(24, ErrorMessage = "Password must be {2} - {1} characters.", MinimumLength = 6)]
        public string Password { get; set; }
    }
}