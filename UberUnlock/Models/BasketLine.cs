namespace UberUnlock
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BasketLine
    {
        public int ID { get; set; }

        public string BasketID { get; set; }

        public int ProductID { get; set; }

        public int Quantity { get; set; }

        public string IMEI { get; set; }

        public DateTime DateCreated { get; set; }

        public virtual Product Product { get; set; }
    }
}
