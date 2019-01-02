using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Travel.Models.Entities;

namespace Travel.Models.DAO
{
    public class UserDAO
    {
        MyModel md;
        public UserDAO()
        {
            md = new MyModel();
        }
        public bool Login(string username, string password)
        {
            var rs = md.TaiKhoans.Count(x => x.TenTK == username && x.MatKhau == password);
            if (rs > 0)
                return true;
            else
                return false;
        }
    }
}