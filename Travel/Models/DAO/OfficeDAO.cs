using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Travel.Models.Entities;

namespace Travel.Models.DAO
{
    public class OfficeDAO
    {
        MyModel md;
        public OfficeDAO()
        {
            md = new MyModel();
        }
        public IQueryable<VanPhong> ListOffice()
        {
            var rs = (from o in md.VanPhongs
                      where o.TrangThai == 1
                      select o);
            return rs;
        }
        public void AddOffice(VanPhong vp)
        {
            VanPhong v = new VanPhong();
            v.TenVP = vp.TenVP;
            v.DiaChi = vp.DiaChi;
            v.SDT = vp.SDT;
            v.Email = vp.Email;
            v.TrangThai = 1;
            md.VanPhongs.Add(v);
            md.SaveChanges();

        }
        public void ChangeOffice(VanPhong vp)
        {
            VanPhong v = md.VanPhongs.Find(vp.idVP);
            if (v != null)
            {
                v.TenVP = vp.TenVP;
                v.DiaChi = vp.DiaChi;
                v.SDT = vp.SDT;
                v.Email = vp.Email;
                md.SaveChanges();
            }
        }
        public void DeleteOffice(VanPhong vp)
        {
            VanPhong v = md.VanPhongs.Find(vp.idVP);
            if (v != null)
            {
                v.TrangThai = 0;
                md.SaveChanges();
            }
        }
        public VanPhong FindOfficeById(int? id)
        {
            return md.VanPhongs.Find(id);
        }
    }
}