namespace Travel.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TaiKhoanNH")]
    public partial class TaiKhoanNH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TaiKhoanNH()
        {
            DatTours = new HashSet<DatTour>();
        }

        [Key]
        [StringLength(16)]
        public string MaTK { get; set; }

        [StringLength(200)]
        public string TenTK { get; set; }

        [StringLength(200)]
        public string TenNganHang { get; set; }

        public int? TrangThai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DatTour> DatTours { get; set; }
    }
}
