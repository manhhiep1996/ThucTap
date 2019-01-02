using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Travel.Models.Entities;

namespace Travel.Models.DAO
{
    public class BankDAO
    {
        MyModel md;
        public BankDAO()
        {
            md = new MyModel();
        }
        public IQueryable<TaiKhoanNH> ListBank()
        {
            var rs = (from b in md.TaiKhoanNHs
                      where b.TrangThai == 1
                      select b);
            return rs;
        }
        public void AddBank(TaiKhoanNH ng)
        {
            TaiKhoanNH b = new TaiKhoanNH();
            b.MaTK = ng.MaTK;
            b.TenTK = ng.TenTK;
            b.TenNganHang = ng.TenNganHang;
            b.TrangThai = 1;
            md.TaiKhoanNHs.Add(b);
            md.SaveChanges();

        }
        public void ChangeBank(TaiKhoanNH ng)
        {
            TaiKhoanNH b = md.TaiKhoanNHs.Find(ng.MaTK);
            if (b != null)
            {
                b.MaTK = ng.MaTK;
                b.TenTK = ng.TenTK;
                b.TenNganHang = ng.TenNganHang;
                md.SaveChanges();
            }
        }
        public void DeleteBank(TaiKhoanNH ng)
        {
            TaiKhoanNH b = md.TaiKhoanNHs.Find(ng.MaTK);
            if (b != null)
            {
                b.TrangThai = 0;
                md.SaveChanges();
            }
        }
        public TaiKhoanNH FindBankById(string id)
        {
            return md.TaiKhoanNHs.Find(id);
        }
    }
}