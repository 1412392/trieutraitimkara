namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    [Table("Singer")]
    public partial class Singer
    {
        [Display(Name = "ID")]
        public int id { get; set; }

        [Display(Name = "Name")]
        [StringLength(100)]
        public string name { get; set; }


        [Display(Name = "Description")]
        [AllowHtml]
        public string description { get; set; }

        [Display(Name = "Image")]
        [StringLength(500)]
        public string imageurl { get; set; }

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
    }
}
