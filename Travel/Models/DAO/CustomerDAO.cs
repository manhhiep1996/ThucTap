using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Travel.Models.DTO;
using Travel.Models.Entities;

namespace Travel.Models.DAO
{
    public class CustomerDAO
    {
        MyModel md;
        public CustomerDAO()
        {
            md = new MyModel();
        }
        public IQueryable<DSKH> ListNameCustomer(int? id)
        {
            var rs = (from c in md.DSKHs
                      where (c.idKHCha == null || c.idKHCha == 2) && c.TrangThai == 1 && (c.idTour == id || c.idTour == null)
                      select c);
            return rs;
        }
        public IQueryable<DSKH> ListCustomer(int id)
        {
            var rs = (from c in md.DSKHs
                      where c.TrangThai == 1 && c.idTour == id
                      select c);
            return rs;
        }
        public void AddCustomer(DSKH lc, int id)
        {
            DSKH c = new DSKH();
            c.HoTen = lc.HoTen;
            c.NamSinh = lc.NamSinh;
            c.DiaChi = lc.DiaChi;
            c.DienThoai = lc.DienThoai;
            c.DiemDon = lc.DiemDon;
            c.idKHCha = lc.idKHCha;
            c.QuanHe = lc.QuanHe;
            c.GhiChu = lc.GhiChu;
            c.TrangThai = 1;
            c.idTour = id;
            md.DSKHs.Add(c);
            Tour t = md.Tours.Find(id);
            t.LuotDatTour += 1;
            md.SaveChanges();
        }
        public void EditCustomer(DSKH lc)
        {
            DSKH c = md.DSKHs.Find(lc.idKH);
            c.HoTen = lc.HoTen;
            if(lc.NamSinh != null)
            {
                c.NamSinh = lc.NamSinh;
            }
            c.DiaChi = lc.DiaChi;
            c.DienThoai = lc.DienThoai;
            c.DiemDon = lc.DiemDon;
            c.idKHCha = lc.idKHCha;
            c.QuanHe = lc.QuanHe;
            c.GhiChu = lc.GhiChu;
            md.SaveChanges();
        }
        public void DeleteCutomer(int id)
        {
            DSKH c = md.DSKHs.Find(id);
            if (c != null)
            {
                c.TrangThai = 0;
            }
            Tour t = md.Tours.Find(c.idTour);
            t.LuotDatTour -= 1;
            md.SaveChanges();
        }
        public DSKH FindCustomerById(int id)
        {
            return md.DSKHs.Find(id);
        }
    }
}