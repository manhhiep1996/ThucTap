namespace Travel.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Website")]
    public partial class Website
    {
        public int id { get; set; }

        [StringLength(50)]
        public string TenWeb { get; set; }

        [StringLength(30)]
        public string SDT { get; set; }

        [StringLength(100)]
        public string imgBanner { get; set; }

        [StringLength(100)]
        public string imgFooter { get; set; }

        [Column("Website")]
        [StringLength(30)]
        public string Website1 { get; set; }

        [StringLength(10)]
        public string Skype { get; set; }

        public string NoiDung { get; set; }

        public int? TrangThai { get; set; }
    }
}
