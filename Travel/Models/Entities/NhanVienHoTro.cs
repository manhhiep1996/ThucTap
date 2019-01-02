namespace Travel.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhanVienHoTro")]
    public partial class NhanVienHoTro
    {
        [Key]
        public int idNV { get; set; }

        [StringLength(50)]
        public string TenNV { get; set; }

        [StringLength(15)]
        public string SDT { get; set; }

        [StringLength(50)]
        public string ViTri { get; set; }

        public string Anh { get; set; }

        [StringLength(50)]
        public string ChucDanh { get; set; }

        public int? TrangThai { get; set; }
    }
}
