using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Travel.Models.Entities;
using Travel.Models.DTO;

namespace Travel.Models.DAO
{
    public class MenuContentDAO
    {
        MyModel md;
        public MenuContentDAO()
        {
            md = new MyModel();
        }
        public IQueryable<MenuContentDTO> ListContent()
        {
            var rs = (from ct in md.NDMenus
                      join m in md.Menus
                      on ct.idMenu equals m.idMenu
                      join m1 in md.Menus
                      on m.idMenuCha equals m1.idMenu
                      where ct.TrangThai == 1
                      orderby ct.idND descending
                      select new MenuContentDTO()
                      {
                          idND = ct.idND,
                          TenND = ct.TenND,
                          Anh = ct.Anh,
                          MoTa = ct.MoTa,
                          Gia = ct.Gia,
                          NhanHieu = ct.NhanHieu,
                          DiaChi = ct.DiaChi,
                          NoiDung = ct.NoiDung,
                          idMenu = ct.idMenu,
                          TenMenu = m.TenMenu,
                          TenMenuCha = m1.TenMenu,
                      });
            return rs;
        }
        public IQueryable<MenuContentDTO> ListContent(int? id)
        {
            var rs = (from ct in md.NDMenus
                      join m in md.Menus
                      on ct.idMenu equals m.idMenu
                      where ct.TrangThai == 1 && ct.idMenu == id
                      orderby ct.idND descending
                      select new MenuContentDTO()
                      {
                          idND = ct.idND,
                          TenND = ct.TenND,
                          Anh = ct.Anh,
                          MoTa = ct.MoTa,
                          Gia = ct.Gia,
                          NhanHieu = ct.NhanHieu,
                          DiaChi = ct.DiaChi,
                          NoiDung = ct.NoiDung,
                          idMenu = ct.idMenu,
                          TenMenu = m.TenMenu,
                      });
            return rs;
        }
        public void AddContent(NDMenu ct)
        {
            NDMenu c = new NDMenu();
            c.TenND = ct.TenND;
            c.Anh = "/Content/Picture/Content/" + ct.Anh;
            c.MoTa = ct.MoTa;
            c.Gia = ct.Gia;
            c.NhanHieu = ct.NhanHieu;
            c.DiaChi = ct.DiaChi;
            c.NoiDung = ct.NoiDung;
            c.idMenu = ct.idMenu;
            c.TrangThai = 1;
            md.NDMenus.Add(c);
            md.SaveChanges();

        }
        public void EditContent(NDMenu ct)
        {
            NDMenu c = md.NDMenus.Find(ct.idND);
            if (c != null)
            {
                c.TenND = ct.TenND;
                if (ct.Anh != null)
                {
                    c.Anh = "/Content/Picture/Content/" + ct.Anh;
                }
                c.MoTa = ct.MoTa;
                c.Gia = ct.Gia;
                c.NhanHieu = ct.NhanHieu;
                c.DiaChi = ct.DiaChi;
                c.NoiDung = ct.NoiDung;
                c.idMenu = ct.idMenu;
                md.SaveChanges();
            }
        }
        public void DeleteContent(int id)
        {
            NDMenu c = md.NDMenus.Find(id);
            if (c != null)
            {
                c.TrangThai = 0;
                md.SaveChanges();
            }
        }
        public NDMenu FindContentById(int id)
        {
            return md.NDMenus.Find(id);
        }
    }
}