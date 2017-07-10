namespace UberUnlock
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            BasketLines = new HashSet<BasketLine>();
            ProductImageMappings = new HashSet<ProductImageMapping>();
        }

        public int ID { get; set; }
        [Display(Name = "Product name")]
        public string Name { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        [StringLength(50)]
        public string Delivery { get; set; }

        public int? CategoryID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BasketLine> BasketLines { get; set; }

        public virtual Category Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductImageMapping> ProductImageMappings { get; set; }
    }
}
