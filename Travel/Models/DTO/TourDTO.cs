using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Travel.Models.DTO
{
    public class TourDTO
    {
        
        public int idTour { get; set; }

        public string TenTour { get; set; }
        
        public string PhuongTien { get; set; }
        
        public string ThoiGian { get; set; }
        
        public string NgayKhoiHanh { get; set; }
        
        public string NoiKhoiHanh { get; set; }

        public int? Gia { get; set; }

        public string Anh { get; set; }
        
        public string LichTrinh { get; set; }
        
        public string HinhThuc { get; set; }

        public int? LuotDatTour { get; set; }
        [AllowHtml]
        public string GioiThieuTour { get; set; }
        [AllowHtml]
        public string LichTrinhCT { get; set; }

        public int? idMenu { get; set; }

        public int? GiaNL { get; set; }

        public int? GiaTE { get; set; }

        public int? GiaEB { get; set; }

        public string TenMenu { get; set; }
        [AllowHtml]
        public string NoiDung { get; set; }
        [AllowHtml]
        public string TieuDe { get; set; }

        public int? KhuyenMai { get; set; }
        
        public int? TourHot { get; set; }

        public int? SoNguoi { get; set; }
    }
}