namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KaraReqest")]
    public partial class KaraReqest
    {
        public int id { get; set; }

        [StringLength(500)]
        public string medianame { get; set; }

        [StringLength(500)]
        public string singer { get; set; }

        [StringLength(1000)]
        public string urlDemo { get; set; }

        [StringLength(100)]
        public string guestname { get; set; }

        [StringLength(100)]
        public string guestemail { get; set; }

        [StringLength(100)]
        public string guestphone { get; set; }

        [StringLength(2000)]
        public string description { get; set; }

        public int? isDelete { get; set; }

        public DateTime? createDate { get; set; }

        public DateTime? deleteDate { get; set; }
    }
}
