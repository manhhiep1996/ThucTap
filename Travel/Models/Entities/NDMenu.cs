namespace Travel.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NDMenu")]
    public partial class NDMenu
    {
        [Key]
        public int idND { get; set; }

        public string TenND { get; set; }

        public string Anh { get; set; }

        public string MoTa { get; set; }

        public int? Gia { get; set; }

        [StringLength(50)]
        public string NhanHieu { get; set; }

        public string DiaChi { get; set; }

        public string NoiDung { get; set; }

        public int? idMenu { get; set; }

        public int? TrangThai { get; set; }

        public virtual Menu Menu { get; set; }
    }
}
