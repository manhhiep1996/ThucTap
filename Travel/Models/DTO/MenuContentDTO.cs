using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Travel.Models.DTO
{
    public class MenuContentDTO
    {
        public int idND { get; set; }

        public string TenND { get; set; }

        public string Anh { get; set; }
        [AllowHtml]
        public string MoTa { get; set; }

        public int? Gia { get; set; }
        
        public string NhanHieu { get; set; }

        public string DiaChi { get; set; }
        [AllowHtml]
        public string NoiDung { get; set; }

        public int? idMenu { get; set; }

        public string TenMenu { get; set; }

        public string TenMenuCha { get; set; }

    }
}