using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Travel.Models.DTO
{
    public class MenuDTO
    {
        public int idMenu { get; set; }

        public string TenMenu { get; set; }
        [AllowHtml]
        public string NoiDung { get; set; }

        public string TenView { get; set; }

        public int? idMenuCha { get; set; }

        public string TenMenuCha { get; set; }
    }
}