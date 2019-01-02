namespace Travel.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TaiKhoan")]
    public partial class TaiKhoan
    {
        [Key]
        public int idAd { get; set; }

        [StringLength(20)]
        public string TenTK { get; set; }

        [StringLength(20)]
        public string MatKhau { get; set; }
    }
}
