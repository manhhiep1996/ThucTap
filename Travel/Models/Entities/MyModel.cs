namespace Travel.Models.Entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MyModel : DbContext
    {
        public MyModel()
            : base("name=MyModel")
        {
        }

        public virtual DbSet<DatTour> DatTours { get; set; }
        public virtual DbSet<DSKH> DSKHs { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<NDMenu> NDMenus { get; set; }
        public virtual DbSet<NhanVienHoTro> NhanVienHoTroes { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }
        public virtual DbSet<TaiKhoanNH> TaiKhoanNHs { get; set; }
        public virtual DbSet<Tour> Tours { get; set; }
        public virtual DbSet<VanPhong> VanPhongs { get; set; }
        public virtual DbSet<Website> Websites { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DatTour>()
                .Property(e => e.MaTK)
                .IsUnicode(false);

            modelBuilder.Entity<DSKH>()
                .Property(e => e.DienThoai)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.DienThoai)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .HasMany(e => e.DatTours)
                .WithRequired(e => e.KhachHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhanVienHoTro>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.TenTK)
                .IsFixedLength();

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.MatKhau)
                .IsFixedLength();

            modelBuilder.Entity<TaiKhoanNH>()
                .Property(e => e.MaTK)
                .IsUnicode(false);

            modelBuilder.Entity<Tour>()
                .Property(e => e.Anh)
                .IsUnicode(false);

            modelBuilder.Entity<Tour>()
                .HasMany(e => e.DatTours)
                .WithRequired(e => e.Tour)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<VanPhong>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<VanPhong>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Website>()
                .Property(e => e.SDT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Website>()
                .Property(e => e.Website1)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Website>()
                .Property(e => e.Skype)
                .IsFixedLength();
        }
    }
}
