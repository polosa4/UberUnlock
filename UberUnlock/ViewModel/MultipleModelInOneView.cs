using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UberUnlock.Models;


namespace UberUnlock.ViewModel
{
    public class MultipleModelInOneView
    {
        public List<BasketLine> BasketLines { get; set; }
        public OrderLine Orders { get; set; }
        public Order Order { get; set; }
        public Product Products { get; set; }
        public List<OrderLine> OrdersList { get; set; }
    }
}