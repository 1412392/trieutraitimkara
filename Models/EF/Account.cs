namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Account")]
    public partial class Account
    {
        [Display(Name = "ID")]
        public int id { get; set; }

        [Display(Name = "Email")]
        [StringLength(100)]
        public string email { get; set; }

        [Display(Name = "Password")]
        [StringLength(200)]
        public string password { get; set; }

        [Display(Name = "FullName")]
        [StringLength(100)]
        public string name { get; set; }

        [Display(Name = "Phone")]
        [StringLength(20)]
        public string phone { get; set; }

        public int? isDelete { get; set; }

        public DateTime? createDate { get; set; }

        public DateTime? deleteDate { get; set; }

        public int? role { get; set; }
    }
}
