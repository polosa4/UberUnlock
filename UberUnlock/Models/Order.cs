using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.PeerToPeer.Collaboration;
using System.Web;
using Braintree;

namespace UberUnlock.Models
{
    public class Order
    {
        [Display(Name = "OrderID")]
        public int OrderID { get; set; }
        [Display(Name = "User")]
        public string UserID { get; set; }
        public string DeliveryName { get; set; }
        [Display(Name = "Total Price")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public decimal TotalPrice { get; set; }
        [Display(Name = "Time Of Order")]
        public DateTime DateCreated { get; set; }
        public List<OrderLine> OrderLines { get; set; }
        [Required]
        [MaxLength(15)]
        [MinLength(15)]
        public string IMEI { get; set; }

        

    }
}