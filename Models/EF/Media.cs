namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Media
    {
        [Display(Name = "ID")]
        public int id { get; set; }

        [Display(Name = "Name")]
        [StringLength(500)]
        public string name { get; set; }

        [Display(Name = "Category")]
        public int? categoryid { get; set; }

        [Display(Name = "File")]
        [StringLength(1000)]
        public string url { get; set; }

        [Display(Name = "Image")]
        [StringLength(500)]
        public string imageurl { get; set; }

        [Display(Name = "Description")]
        [Column(TypeName = "ntext")]
        public string description { get; set; }

        [Display(Name = "MediaType")]
        public int? mediatype { get; set; }

        [Display(Name = "DisplayOrder")]
        public int? displayorder { get; set; }

        [Display(Name = "Composer")]
        [StringLength(100)]
        public string composer { get; set; }

        [Display(Name = "ListSingerID")]
        public string ListSingerID { get; set; }

        [Display(Name = "ListSingerName")]
        public string ListSingerName { get; set; }

        [Display(Name = "ListAccountID")]
        public string ListAccountID { get; set; }

        [Display(Name = "ListAccountName")]
        public string ListAccountName { get; set; }


        [Display(Name = "Views")]
        public int? views { get; set; }

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

        public DateTime? createDate { get; set; }

        public DateTime? deleteDate { get; set; }

        public virtual Category Category { get; set; }

        public virtual MediaType MediaType1 { get; set; }
    }
}
