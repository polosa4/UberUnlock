namespace UberUnlock
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class ProductImage
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProductImage()
        {
            ProductImageMappings = new HashSet<ProductImageMapping>();
        }

        public int ID { get; set; }

        [StringLength(100)]
        [Display(Name="File")]
        [Index(IsUnique = true)]
        public string FileName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductImageMapping> ProductImageMappings { get; set; }
    }
}
