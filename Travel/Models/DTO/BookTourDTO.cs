using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Travel.Models.DTO
{
    public class BookTourDTO
    {
        public int idTour { get; set; }

        public int idKH { get; set; }

        public string HoTen { get; set; }
        
        public string DiaChi { get; set; }
        
        public string DienThoai { get; set; }
        
        public string Email { get; set; }
        
        public string DiemDon { get; set; }
        [AllowHtml]
        public string GhiChu { get; set; }

        public int? SoNL { get; set; }

        public int? SoTE { get; set; }

        public int? SoEB { get; set; }
        
        public int? TongTien { get; set; }

        public string HinhThucTT { get; set; }

        public string TenTour { get; set; }

        public int? XacNhanTT { get; set; }
        
        public DateTime? NgayDatTour { get; set; }

        public DateTime? NgayTT { get; set; }

        public int? idVP { get; set; }

        public string TenVP { get; set; }

        public string MaTK { get; set; }
    }
}