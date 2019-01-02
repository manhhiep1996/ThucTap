using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using Travel.Models.DTO;
using Travel.Models.Entities;

namespace Travel.Models.DAO
{
    public class TourDAO
    {
        MyModel md;
        public TourDAO()
        {
            md = new MyModel();
        }
        public TourDTO Tour(int id)
        {
            TourDTO rs = (from t in md.Tours
                      where t.TrangThai == 1 && t.idTour == id
                      select new TourDTO()
                      {
                          idTour = t.idTour,
                          TenTour = t.TenTour,
                          PhuongTien = t.PhuongTien,
                          ThoiGian = t.ThoiGian,
                          NgayKhoiHanh = t.NgayKhoiHanh.ToString(),
                          NoiKhoiHanh = t.NoiKhoiHanh,
                          Gia = t.Gia,
                          Anh = t.Anh,
                          LichTrinh = t.LichTrinh,
                          HinhThuc = t.HinhThuc,
                          LuotDatTour = t.LuotDatTour,
                          GioiThieuTour = t.GioiThieuTour,
                          LichTrinhCT = t.LichTrinhCT,
                          TourHot = t.TourHot,
                          idMenu = t.idMenu,
                          GiaNL = t.GiaNL,
                          GiaTE = t.GiaTE,
                          GiaEB = t.GiaEB,
                          TieuDe = t.MoTa,
                          KhuyenMai = t.KhuyenMai,
                          SoNguoi = t.SoNguoi,
                      }).First();
            return rs;
        }
        public IQueryable<TourDTO> ListTour()
        {
            var rs = (from t in md.Tours
                      join m in md.Menus
                      on t.idMenu equals m.idMenu
                      where t.TrangThai == 1 && t.LuotDatTour < t.SoNguoi
                      orderby t.idTour descending
                      select new TourDTO()
                      {
                          idTour = t.idTour,
                          TenTour = t.TenTour,
                          PhuongTien = t.PhuongTien,
                          ThoiGian = t.ThoiGian,
                          NgayKhoiHanh = t.NgayKhoiHanh.ToString(),
                          NoiKhoiHanh = t.NoiKhoiHanh,
                          Gia = t.Gia,
                          Anh = t.Anh,
                          LichTrinh = t.LichTrinh,
                          HinhThuc = t.HinhThuc,
                          LuotDatTour = t.LuotDatTour,
                          GioiThieuTour = t.GioiThieuTour,
                          LichTrinhCT = t.LichTrinhCT,
                          idMenu = t.idMenu,
                          GiaNL = t.GiaNL,
                          GiaTE = t.GiaTE,
                          GiaEB = t.GiaEB,
                          TenMenu = m.TenMenu,
                          NoiDung = m.NoiDung,
                          TieuDe = t.MoTa,
                          KhuyenMai = t.KhuyenMai,
                          TourHot = t.TourHot,
                          SoNguoi = t.SoNguoi,
                      });
            return rs;
        }
        public IQueryable<TourDTO> AllTour()
        {
            var rs = (from t in md.Tours
                      join m in md.Menus
                      on t.idMenu equals m.idMenu
                      where t.TrangThai == 1
                      orderby t.idTour descending
                      select new TourDTO() {
                          idTour = t.idTour,
                          TenTour = t.TenTour,
                          PhuongTien = t.PhuongTien,
                          ThoiGian = t.ThoiGian,
                          NgayKhoiHanh = t.NgayKhoiHanh.ToString(),
                          NoiKhoiHanh = t.NoiKhoiHanh,
                          Gia = t.Gia,
                          Anh = t.Anh,
                          LichTrinh = t.LichTrinh,
                          HinhThuc = t.HinhThuc,
                          LuotDatTour = t.LuotDatTour,
                          GioiThieuTour = t.GioiThieuTour,
                          LichTrinhCT = t.LichTrinhCT,
                          idMenu = t.idMenu,
                          GiaNL = t.GiaNL,
                          GiaTE = t.GiaTE,
                          GiaEB = t.GiaEB,
                          TenMenu = m.TenMenu,
                          NoiDung = m.NoiDung,
                          TieuDe = t.MoTa,
                          KhuyenMai = t.KhuyenMai,
                          TourHot = t.TourHot,
                          SoNguoi = t.SoNguoi,
                      });
            return rs;
        }
        public IQueryable<TourDTO> ListTourHot()
        {
            var rs = (from t in md.Tours
                      join m in md.Menus
                      on t.idMenu equals m.idMenu
                      where t.TourHot == 1 && t.TrangThai == 1
                      orderby t.idTour descending
                      select new TourDTO() {
                          idTour = t.idTour,
                          TenTour = t.TenTour,
                          PhuongTien = t.PhuongTien,
                          ThoiGian = t.ThoiGian,
                          NgayKhoiHanh = t.NgayKhoiHanh.ToString(),
                          NoiKhoiHanh = t.NoiKhoiHanh,
                          Gia = t.Gia,
                          Anh = t.Anh,
                          LichTrinh = t.LichTrinh,
                          HinhThuc = t.HinhThuc,
                          LuotDatTour = t.LuotDatTour,
                          GioiThieuTour = t.GioiThieuTour,
                          LichTrinhCT = t.LichTrinhCT,
                          idMenu = t.idMenu,
                          GiaNL = t.GiaNL,
                          GiaTE = t.GiaTE,
                          GiaEB = t.GiaEB,
                          TenMenu = m.TenMenu,
                          NoiDung = m.NoiDung,
                          TieuDe = t.MoTa,
                          KhuyenMai = t.KhuyenMai,
                          TourHot = t.TourHot,
                          SoNguoi = t.SoNguoi,
                      });
            return rs;
        }
        public void ThemTour(Tour nt)
        {
            Tour t = new Tour();
            t.TenTour = nt.TenTour;
            t.PhuongTien = nt.PhuongTien;
            t.ThoiGian = nt.ThoiGian;
            t.NgayKhoiHanh = nt.NgayKhoiHanh;
            t.NoiKhoiHanh = nt.NoiKhoiHanh;
            t.Gia = nt.Gia;
            t.LichTrinh = nt.LichTrinh;
            t.HinhThuc = nt.HinhThuc;
            t.GiaNL = nt.GiaNL;
            t.GiaTE = nt.GiaTE;
            t.GiaEB = nt.GiaEB;
            t.GioiThieuTour = nt.GioiThieuTour;
            t.LichTrinhCT = nt.LichTrinhCT;
            if(nt.KhuyenMai != null)
            {
                t.KhuyenMai = nt.KhuyenMai;
            }
            else
            {
                t.KhuyenMai = 0;
            }
            t.TourHot = nt.TourHot;
            t.MoTa = nt.MoTa;
            t.TrangThai = 1;
            t.LuotDatTour = 0;
            t.SoNguoi = nt.SoNguoi;
            t.idMenu = nt.idMenu;
            t.Anh = "/Content/Picture/" + nt.Anh;
            md.Tours.Add(t);
            md.SaveChanges();
            
        }
        public void SuaTour(Tour ut)
        {
            Tour t = md.Tours.Find(ut.idTour);
            if (t != null)
            {
                t.TenTour = ut.TenTour;
                t.PhuongTien = ut.PhuongTien;
                t.ThoiGian = ut.ThoiGian;
                t.NgayKhoiHanh = ut.NgayKhoiHanh;
                t.NoiKhoiHanh = ut.NoiKhoiHanh;
                t.Gia = ut.Gia;
                if (ut.Anh != null)
                {
                    t.Anh = "/Content/Picture/" + ut.Anh;
                }
                
                t.LichTrinh = ut.LichTrinh;
                t.HinhThuc = ut.HinhThuc;
                t.GiaNL = ut.GiaNL;
                t.GiaTE = ut.GiaTE;
                t.GiaEB = ut.GiaEB;
                t.SoNguoi = ut.SoNguoi;
                t.GioiThieuTour = ut.GioiThieuTour;
                t.LichTrinhCT = ut.LichTrinhCT;
                t.KhuyenMai = ut.KhuyenMai;
                t.MoTa = ut.MoTa;
                t.TourHot = ut.TourHot;
                t.idMenu = ut.idMenu;
                md.SaveChanges();
            }
        }
        public void XoaTour(Tour nt)
        {
            Tour t = md.Tours.Find(nt.idTour);
            if (t != null)
            {
                t.TrangThai = 0;
                md.SaveChanges();
            }
        }
        public Tour FindTourById(int id)
        {
            return md.Tours.Find(id);
        }
        public IQueryable<TourDTO> TimTour(string ten, string ngay, string gia)
        {
            int gt = 0;
            if(gia != null)
            {
                gt = int.Parse(gia);
            }
            var rs = (from t1 in md.Tours where t1.TrangThai == 1 && t1.TenTour.Contains(ten) && t1.ThoiGian.Contains(ngay) && (t1.Gia >= (gt - 1000000) && t1.Gia <= gt) select t1);
            if(ten == "" && ngay == "0" && gt == 0 )
            {
                rs = (from t1 in md.Tours where t1.TrangThai == 1 select t1);
            }
            if(ten != "" && ngay != "0" && gt == 0)
            {
                rs = (from t1 in md.Tours where t1.TrangThai == 1 && t1.TenTour.Contains(ten) && t1.ThoiGian.Contains(ngay) select t1);
            }
            if (ten != "" && ngay == "0" && gt == 0)
            {
                rs = (from t1 in md.Tours where t1.TrangThai == 1 && t1.TenTour.Contains(ten) select t1);
            }
            if (ten != "" && ngay == "0" && gt != 0)
            {
                rs = (from t1 in md.Tours where t1.TrangThai == 1 && t1.TenTour.Contains(ten) && (t1.Gia >= (gt - 1000000) && t1.Gia <= gt) select t1);
            }
            if (ten == "" && ngay != "0" && gt != 0)
            {
                rs = (from t1 in md.Tours where t1.TrangThai == 1 && t1.ThoiGian.Contains(ngay) && (t1.Gia >= (gt - 1000000) && t1.Gia <= gt) select t1);
            }
            if (ten == "" && ngay != "0" && gt == 0)
            {
                rs = (from t1 in md.Tours where t1.TrangThai == 1 && t1.ThoiGian.Contains(ngay) select t1);
            }
            if (ten == "" && ngay == "0" && gt != 0)
            {
                rs = (from t1 in md.Tours where t1.TrangThai == 1 && (t1.Gia >= (gt - 1000000) && t1.Gia <= gt) select t1);
            }
            return rs.Join(from m in md.Menus where m.TrangThai == 1 select m, t => t.idMenu, m => m.idMenu, 
                (tour, menu) => new TourDTO() {
                    idTour = tour.idTour,
                    TenTour = tour.TenTour,
                    PhuongTien = tour.PhuongTien,
                    ThoiGian = tour.ThoiGian,
                    NgayKhoiHanh = tour.NgayKhoiHanh.ToString(),
                    NoiKhoiHanh = tour.NoiKhoiHanh,
                    Gia = tour.Gia,
                    Anh = tour.Anh,
                    LichTrinh = tour.LichTrinh,
                    HinhThuc = tour.HinhThuc,
                    LuotDatTour = tour.LuotDatTour,
                    GioiThieuTour = tour.GioiThieuTour,
                    LichTrinhCT = tour.LichTrinhCT,
                    TourHot = tour.TourHot,
                    idMenu = tour.idMenu,
                    GiaNL = tour.GiaNL,
                    GiaTE = tour.GiaTE,
                    GiaEB = tour.GiaEB,
                    TieuDe = tour.MoTa,
                    KhuyenMai = tour.KhuyenMai,
                    SoNguoi = tour.SoNguoi,
                });
        }
    }
}