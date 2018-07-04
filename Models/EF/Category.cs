namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Category")]
    public partial class Category
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Category()
        {
            Media = new HashSet<Media>();
        }
        [Display(Name = "ID")]
        public int id { get; set; }

        [Display(Name = "Name")]
        [StringLength(100)]
        public string name { get; set; }

        [Display(Name = "Views")]
        public int? views { get; set; }


        [StringLength(1000)]
        [Display(Name = "Image")]
        public string imageurl { get; set; }

        public DateTime? createDate { get; set; }

        [Display(Name = "SeoTitle")]
        [StringLength(100)]
        public string seotitle { get; set; }

        [Display(Name = "Keyword")]
        [StringLength(500)]
        public string keyword { get; set; }

        [Display(Name = "MetaDescription")]
        [StringLength(500)]
        public string metadescription { get; set; }

        public int? isDelete { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Media> Media { get; set; }
    }
}
