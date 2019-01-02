using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Travel.Models.DTO;
using Travel.Models.Entities;

namespace Travel.Models.DAO
{
    public class BookTourDAO
    {
        MyModel md;
        public BookTourDAO()
        {
            md = new MyModel();
        }
        public IQueryable<BookTourDTO> ListBookTour(int id)
        {
            var rs = (from dt in md.DatTours
                      join t in md.Tours
                      on dt.idTour equals t.idTour
                      join k in md.KhachHangs
                      on dt.idKH equals k.idKH
                      where dt.idTour == id 
                      select new BookTourDTO()
                      {
                          idTour = dt.idTour,
                          idKH = k.idKH,
                          HoTen = k.HoTen,
                          DiaChi = k.DiaChi,
                          DienThoai = k.DienThoai,
                          Email = k.Email,
                          DiemDon = k.DiemDon,
                          GhiChu = k.GhiChu,
                          SoNL = k.SoNL,
                          SoTE = k.SoTE,
                          SoEB = k.SoEB,
                          TongTien = dt.TongTien,
                          HinhThucTT = k.HinhThucTT,
                          TenTour = t.TenTour,
                          XacNhanTT = k.XacNhanTT,
                          NgayDatTour = dt.NgayDatTour,
                          NgayTT = dt.NgayTT,
                          idVP = dt.idVP,
                          MaTK = dt.MaTK,
                      });
            return rs;
        }
        public BookTourDTO Detail(int idkh, int idtour)
        {
            var rs = (from dt in md.DatTours
                      join t in md.Tours
                      on dt.idTour equals t.idTour
                      join k in md.KhachHangs
                      on dt.idKH equals k.idKH
                      where t.TrangThai == 1 && dt.idTour == idtour && dt.idKH == idkh
                      select new BookTourDTO()
                      {
                          idTour = dt.idTour,
                          idKH = k.idKH,
                          HoTen = k.HoTen,
                          DiaChi = k.DiaChi,
                          DienThoai = k.DienThoai,
                          Email = k.Email,
                          DiemDon = k.DiemDon,
                          GhiChu = k.GhiChu,
                          SoNL = k.SoNL,
                          SoTE = k.SoTE,
                          SoEB = k.SoEB,
                          TongTien = dt.TongTien,
                          HinhThucTT = k.HinhThucTT,
                          TenTour = t.TenTour,
                          XacNhanTT = k.XacNhanTT,
                          NgayDatTour = dt.NgayDatTour,
                          NgayTT = dt.NgayTT,
                          idVP = dt.idVP,
                          MaTK = dt.MaTK,
                      }).First();
            return rs;
        }
        public void DatTour(BookTourDTO dt)
        {
            DatTour t = new DatTour();
            Tour tour = md.Tours.Find(dt.idTour);
            KhachHang k = new KhachHang();
            k.HoTen = dt.HoTen;
            k.DiaChi = dt.DiaChi;
            k.DienThoai = dt.DienThoai;
            k.Email = dt.Email;
            k.DiemDon = dt.DiemDon;
            k.GhiChu = dt.GhiChu;
            k.SoNL = dt.SoNL;
            k.SoTE = dt.SoTE;
            k.SoEB = dt.SoEB;
            k.HinhThucTT = dt.HinhThucTT;
            k.TrangThai = 1;
            k.XacNhanTT = 0;
            md.KhachHangs.Add(k);
            md.SaveChanges();
            t.idKH = k.idKH;
            t.idTour = dt.idTour;
            t.NgayDatTour = DateTime.Now;
            t.TongTien = dt.TongTien;
            md.DatTours.Add(t);
            md.SaveChanges();
        }
        public void EditBookTour(BookTourDTO dt)
        {
            DatTour b = md.DatTours.Find(dt.idTour, dt.idKH);
            Tour t = md.Tours.Find(dt.idTour);
            KhachHang c = md.KhachHangs.Find(dt.idKH);
            c.DiemDon = dt.DiemDon;
            c.SoNL = dt.SoNL;
            c.SoTE = dt.SoTE;
            c.SoEB = dt.SoEB;
            c.HinhThucTT = dt.HinhThucTT;
            c.GhiChu = dt.GhiChu;
            b.TongTien = dt.SoNL * t.GiaNL + dt.SoTE * t.GiaTE + dt.SoEB * t.GiaEB;
            c.HinhThucTT = dt.HinhThucTT;
            if(dt.HinhThucTT == "CK")
            {
                b.MaTK = dt.MaTK;
                b.idVP = null;
            }
            if(dt.HinhThucTT == "VP")
            {
                b.idVP = dt.idVP;
                b.MaTK = null;
            }
            md.SaveChanges();
        }
        public void Payment(int idkh, int idtour)
        {
            KhachHang c = md.KhachHangs.Find(idkh);
            DatTour b = md.DatTours.Find(idtour, idkh);
            b.NgayTT = DateTime.Now;
            c.XacNhanTT = 1;
            md.SaveChanges();
        }
        
    }
}