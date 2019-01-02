using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Travel.Models.Entities;

namespace Travel.Models.DAO
{
    public class EmployeeDAO
    {
        MyModel md;
        public EmployeeDAO()
        {
            md = new MyModel();
        }
        public IQueryable<NhanVienHoTro> ListEmployee()
        {
            var rs = (from n in md.NhanVienHoTroes
                      where n.TrangThai == 1
                      select n);
            return rs;
        }
        public void AddEmployee(NhanVienHoTro nv)
        {
            NhanVienHoTro n = new NhanVienHoTro();
            n.TenNV = nv.TenNV;
            n.SDT = nv.SDT;
            n.ViTri = nv.ViTri;
            n.Anh = "/Content/Picture/" + nv.Anh;
            n.ChucDanh = nv.ChucDanh;
            n.TrangThai = 1;
            md.NhanVienHoTroes.Add(n);
            md.SaveChanges();

        }
        public void ChangeEmployee(NhanVienHoTro nv)
        {
            NhanVienHoTro n = md.NhanVienHoTroes.Find(nv.idNV);
            if (n != null)
            {
                n.TenNV = nv.TenNV;
                n.SDT = nv.SDT;
                n.ViTri = nv.ViTri;
                n.ChucDanh = nv.ChucDanh;
                if(nv.Anh != null)
                {
                    n.Anh = "/Content/Picture/" + nv.Anh;
                }
                md.SaveChanges();
            }
        }
        public void DeleteEmployee(NhanVienHoTro nv)
        {
            NhanVienHoTro n = md.NhanVienHoTroes.Find(nv.idNV);
            if (n != null)
            {
                n.TrangThai = 0;
                md.SaveChanges();
            }
        }
        public NhanVienHoTro FindEmployeeById(int id)
        {
            return md.NhanVienHoTroes.Find(id);
        }
    }
}