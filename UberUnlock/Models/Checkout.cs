using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UberUnlock.Models
{
    public class Checkout
    {

        [NotMapped]
        [Required]
        [Display(Name = "Cardholder's name")]
        public string NameOnCard { get; set; }
        [NotMapped]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string ContactEmail { get; set; }
        [NotMapped]
        [CreditCard]
        [Required]
        [Display(Name = "Credit card number")]
        public string CreditCardNumber { get; set; }
        [NotMapped]
        [Required]
        [Display(Name = "Month")]
        public int? CreditCardExpirationMonth { get; set; }
        [NotMapped]
        [Required]
        [Range(2017, 2027)]
        [Display(Name = "Year")]
        public int? CreditCardExpirationYear { get; set; }
        [NotMapped]
        [Required]
        [MinLength(3)]
        [MaxLength(4)]
        [Display(Name = "CCV")]
        public string CreditCardVerificationValue { get; set; }
        //[NotMapped]
        //[Required]
        //[Display(Name = "Zipcode")]
        //public int Zipcode { get; set; }
    }
}