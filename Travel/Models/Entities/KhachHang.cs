namespace Travel.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhachHang")]
    public partial class KhachHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KhachHang()
        {
            DatTours = new HashSet<DatTour>();
        }

        [Key]
        public int idKH { get; set; }

        [StringLength(50)]
        public string HoTen { get; set; }

        public string DiaChi { get; set; }

        [StringLength(15)]
        public string DienThoai { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(100)]
        public string DiemDon { get; set; }

        public string GhiChu { get; set; }

        public int? SoNL { get; set; }

        public int? SoTE { get; set; }

        public int? SoEB { get; set; }

        [StringLength(50)]
        public string HinhThucTT { get; set; }

        public int? TrangThai { get; set; }

        public int? XacNhanTT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DatTour> DatTours { get; set; }
    }
}
