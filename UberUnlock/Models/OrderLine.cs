using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UberUnlock.Models
{
    public class OrderLine
    {
        public int ID { get; set; }
        public int OrderID { get; set; }
        public int? ProductID { get; set; }
        public int Quantity { get; set; }
        public string ProductName { get; set; }
        [Display(Name = "Unit Price")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public decimal UnitPrice { get; set; }
        [Required]
        [MaxLength(15, ErrorMessage = "Invalid IMEI number, IMEI must be no more than fifteen digits long")]
        [MinLength(15, ErrorMessage = "Invalid IMEI number, IMEI must be at least fifteen digits long")]
        public string IMEI { get; set; }    
        public virtual Product Product { get; set; }
        public virtual Order Order { get; set; }
    }
}