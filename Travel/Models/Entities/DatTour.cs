namespace Travel.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DatTour")]
    public partial class DatTour
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idTour { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idKH { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayDatTour { get; set; }

        public int? TongTien { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayTT { get; set; }

        public int? idVP { get; set; }

        [StringLength(16)]
        public string MaTK { get; set; }

        public virtual KhachHang KhachHang { get; set; }

        public virtual TaiKhoanNH TaiKhoanNH { get; set; }

        public virtual Tour Tour { get; set; }

        public virtual VanPhong VanPhong { get; set; }
    }
}
