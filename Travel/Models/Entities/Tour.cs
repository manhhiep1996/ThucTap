namespace Travel.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tour")]
    public partial class Tour
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tour()
        {
            DatTours = new HashSet<DatTour>();
            DSKHs = new HashSet<DSKH>();
        }

        [Key]
        public int idTour { get; set; }

        public string TenTour { get; set; }

        [StringLength(50)]
        public string PhuongTien { get; set; }

        [StringLength(50)]
        public string ThoiGian { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.Date), Required]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime? NgayKhoiHanh { get; set; }

        [StringLength(50)]
        public string NoiKhoiHanh { get; set; }

        public int? Gia { get; set; }

        public string Anh { get; set; }

        public string LichTrinh { get; set; }

        public string HinhThuc { get; set; }

        public int? LuotDatTour { get; set; }

        public string GioiThieuTour { get; set; }

        public string LichTrinhCT { get; set; }

        public int? idMenu { get; set; }

        public int? GiaNL { get; set; }

        public int? GiaTE { get; set; }

        public int? GiaEB { get; set; }

        public int? TrangThai { get; set; }

        public string MoTa { get; set; }

        public int? KhuyenMai { get; set; }

        public int? TourHot { get; set; }

        public int? SoNguoi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DatTour> DatTours { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DSKH> DSKHs { get; set; }

        public virtual Menu Menu { get; set; }
    }
}
