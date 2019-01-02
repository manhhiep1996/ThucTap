using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Travel.Models.DTO;
using Travel.Models.Entities;
using System.IO;

namespace Travel.Models.DAO
{
    public class MenuDAO
    {
        MyModel md;
        public MenuDAO()
        {
            md = new MyModel();
        }
        public IQueryable<MenuDTO> ListMenu()
        {
            var rs = (from mn in md.Menus
                      join m in md.Menus
                      on mn.idMenuCha equals m.idMenu
                      where mn.TrangThai == 1
                      select new MenuDTO() {
                          idMenu = mn.idMenu,
                          TenMenu = mn.TenMenu,
                          NoiDung = mn.NoiDung,
                          TenView = mn.TenView,
                          idMenuCha = mn.idMenuCha,
                          TenMenuCha = m.TenMenu,
                      });
            return rs;
        }
        
        public void ThemMenu(Menu mn)
        {
            Menu m = new Menu();
            m.TenMenu = mn.TenMenu;
            m.NoiDung = mn.NoiDung;
            m.TenView = Path.GetFileNameWithoutExtension(mn.TenView);
            m.idMenuCha = mn.idMenuCha;
            m.TrangThai = 1;
            md.Menus.Add(m);
            md.SaveChanges();

        }
        public void SuaMenu(Menu mn)
        {
            Menu m = md.Menus.Find(mn.idMenu);
            if (m != null)
            {
                m.TenMenu = mn.TenMenu;
                m.NoiDung = mn.NoiDung;
                if(mn.TenView != null)
                {
                    m.TenView = Path.GetFileNameWithoutExtension(mn.TenView);
                }
                m.idMenuCha = mn.idMenuCha;
                md.SaveChanges();
            }
        }
        public void XoaMenu(Menu mn)
        {
            Menu m = md.Menus.Find(mn.idMenu);
            if (m != null)
            {
                m.TrangThai = 0;
                md.SaveChanges();
            }
        }
        public Menu FindMenuById(int? id)
        {
            return md.Menus.Find(id);
        }
    }
}