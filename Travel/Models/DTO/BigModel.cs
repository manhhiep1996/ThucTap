using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Travel.Models.DTO;
using Travel.Models.Entities;

namespace Travel.Models.DTO
{
    public class BigModel
    {
        public string Noidung { get; set; }
        public string Video { get; set; }
        public IQueryable<NhanVienHoTro> NVHT { get; set; }
        public IQueryable<MenuContentDTO> ListContent { get; set; }
        public IQueryable<MenuContentDTO> ListContentId { get; set; }
        public IQueryable<MenuDTO> ListMenu { get; set; }
        public IQueryable<TourDTO> ListTour { get; set; }
        public IQueryable<TourDTO> ListTourHot { get; set; }
        public IQueryable<TourDTO> ListTourB { get; set; }
        public IQueryable<TourDTO> ListTourT { get; set; }
        public IQueryable<TourDTO> ListTourN { get; set; }
        public IQueryable<TourDTO> ListTourD { get; set; }
        public IQueryable<TaiKhoanNH> ListBank { get; set; }
    }
}