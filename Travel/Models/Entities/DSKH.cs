namespace Travel.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DSKH")]
    public partial class DSKH
    {
        [Key]
        public int idKH { get; set; }

        [StringLength(100)]
        public string HoTen { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.Date), Required]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime? NamSinh { get; set; }

        public string DiaChi { get; set; }

        [StringLength(15)]
        public string DienThoai { get; set; }

        public string DiemDon { get; set; }

        public string GhiChu { get; set; }

        public int? idTour { get; set; }

        public int? TrangThai { get; set; }

        public int? idKHCha { get; set; }

        [StringLength(50)]
        public string QuanHe { get; set; }

        [StringLength(20)]
        public string GioiTinh { get; set; }

        public virtual Tour Tour { get; set; }
    }
}
