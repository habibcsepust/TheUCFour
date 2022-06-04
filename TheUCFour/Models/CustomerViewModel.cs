using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheUCFour.Model.Model;
using System.ComponentModel.DataAnnotations;

namespace TheUCFour.Models
{
    public class CustomerViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Code Field Must Fill")]
        [StringLength(4,MinimumLength = 4,ErrorMessage = "Code Field Required Exact 4 Digit Length.")]
        public string Code { get; set; }
        [Required(ErrorMessage = "Name Field Must Fill")]
        public string Name { get; set; }
        public string Address { get; set; }
        [Required(ErrorMessage = "Email Field Must be Required")]
        [EmailAddress(ErrorMessage = "Please Enter Valid Email Address.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Contact Field Must be Required")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Contact Field Required Exact 11 Digit Length.")]
        [RegularExpression(@"^\d+$(\.\d+)?", ErrorMessage = "Only numaric values are allow")]
        public string Contact { get; set; }
        [RegularExpression(@"^\d+$(\.\d+)?", ErrorMessage = "Only Positive value is allowed")]
        public double LoyalityPoint { get; set; }
        public List<Customer> Customers { get; set; }
    }
}