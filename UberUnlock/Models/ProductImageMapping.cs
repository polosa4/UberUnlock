namespace UberUnlock
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ProductImageMapping
    {
        public int ID { get; set; }

        public int ImageNumber { get; set; }

        public int ProductID { get; set; }

        public int ProductImageID { get; set; }

        public virtual ProductImage ProductImage { get; set; }

        public virtual Product Product { get; set; }
    }
}
