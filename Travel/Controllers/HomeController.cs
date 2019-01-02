using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Travel.Models.Entities;
using Travel.Models.DAO;
using Travel.Models.DTO;
using PagedList;
using System.Configuration;
using Common;

namespace Travel.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(int? id)
        {
            int? type = id;
            MenuDAO dao = new MenuDAO();
            BigModel bigmodel = new BigModel();
            bigmodel = ChuyenlayDuLieu(id);
            //switch (type)
            //{
            //    case 1:
                    
            //        break;
            //    case 2:
            //        bigmodel = ChuyenlayDuLieu();
            //        break;
            //    case 3:
            //        bigmodel = ChuyenlayDuLieu();
            //        break;
            //    case 4:
            //        bigmodel = ChuyenlayDuLieu();
            //        break;
            //    case 5:
            //        bigmodel = ChuyenlayDuLieu();
            //        break;
            //    case 6:
            //        bigmodel = ChuyenlayDuLieu();
            //        break;
            //    case 7:
            //        bigmodel = ChuyenlayDuLieu();
            //        break;
            //}
            ViewBag.type = type;
            if (id != null)
            {
                ViewBag.id = dao.FindMenuById(id).idMenu;
                ViewBag.Name = dao.FindMenuById(id).TenMenu;
                ViewBag.ViewName = dao.FindMenuById(id).TenView;
            }
            ViewData["modelKhongLo"] = bigmodel;
            return View(bigmodel);
        }

        public BigModel ChuyenlayDuLieu(int? id)
        {
            MenuContentDAO ct = new MenuContentDAO();
            EmployeeDAO em = new EmployeeDAO();
            TourDAO t = new TourDAO();
            MenuDAO mn = new MenuDAO();
            BigModel bm = new BigModel();
            BankDAO b = new BankDAO();
            bm.Noidung = "Video";
            bm.Video = "https://www.youtube.com/embed/uCDqjBHL7uk";
            bm.ListContent = ct.ListContent();
            bm.ListContentId = ct.ListContent(id);
            bm.NVHT = em.ListEmployee();
            bm.ListMenu = mn.ListMenu();
            bm.ListTour = t.ListTour();
            bm.ListBank = b.ListBank();
            return bm;
        }
        public ActionResult Search()
        {
            return View();
        }
        public ActionResult MenuSearch(FormCollection fc)
        {
            TourDAO dao = new TourDAO();
            IQueryable<TourDTO> t;
            string ten = fc["searchString"];
            t = dao.TimTour(ten, "0", "0");
            return PartialView("Search", t);
        }
        public ActionResult SearchAction(FormCollection fc)
        {
            TourDAO dao = new TourDAO();
            IQueryable<TourDTO> t;
            string ten = fc["searchString"];
            string ngaydi = fc["ngaydi"];
            string gia = fc["gia"];
            t = dao.TimTour(ten, ngaydi, gia);
            return PartialView("Search", t);
        }
        public ActionResult TourHot()
        {
            TourDAO dao = new TourDAO();
            IQueryable<TourDTO> t = dao.ListTourHot();
            return PartialView(t);
        }
        public PartialViewResult Menu()
        {
            MenuDAO lstMenu = new MenuDAO();
            IQueryable<MenuDTO> mn = lstMenu.ListMenu();
            return PartialView(mn);
        }
        public PartialViewResult MenuFooter()
        {
            MenuDAO lstMenu = new MenuDAO();
            IQueryable<MenuDTO> mn = lstMenu.ListMenu();
            return PartialView(mn);
        }
        public ActionResult LeftMenu()
        {
            BigModel bigmodel = new BigModel();
            bigmodel = ChuyenlayDuLieu(1);
            return PartialView(bigmodel);
        }
        public ActionResult MenuMobile()
        {
            MenuDAO lstMenu = new MenuDAO();
            IQueryable<MenuDTO> mn = lstMenu.ListMenu();
            return PartialView(mn);
        }
        public PartialViewResult VanPhong()
        {
            OfficeDAO dao = new OfficeDAO();
            IQueryable<VanPhong> vp = dao.ListOffice();
            return PartialView(vp);
        }
        public ActionResult DetailTour(int id)
        {
            TourDAO dao = new TourDAO();
            TourDTO t = dao.Tour(id);
            return PartialView(t);
        }
        public ActionResult DetailContent(int id, string view)
        {
            MenuContentDAO dao = new MenuContentDAO();
            NDMenu ct = dao.FindContentById(id);
            return PartialView(view, ct);
        }
        public ActionResult DetailNews(int id)
        {
            MenuContentDAO dao = new MenuContentDAO();
            NDMenu h = dao.FindContentById(id);
            return PartialView(h);
        }
        public ActionResult DetailCar(int id)
        {
            MenuContentDAO dao = new MenuContentDAO();
            NDMenu h = dao.FindContentById(id);
            return PartialView(h);
        }
        public ActionResult DatTour(int id)
        {
            TourDAO dao = new TourDAO();
            TourDTO t = dao.Tour(id);
            OfficeDAO of = new OfficeDAO();
            ViewBag.ListOffice = of.ListOffice();
            return PartialView(t);
        }
        public ActionResult BookTourAction(FormCollection fc)
        {
            //BigModel bigmodel = ChuyenlayDuLieu();
            BookTourDAO dao = new BookTourDAO();
            BookTourDTO t = new BookTourDTO();
            TourDAO tourDAO = new TourDAO();
            t.HoTen = fc["fullname"];
            t.DiaChi = fc["address"];
            t.DienThoai = fc["phone"];
            t.Email = fc["email"];
            t.DiemDon = fc["diemdon"];
            t.GhiChu = fc["notes"];
            if(fc["adults"] != "")
            {
                t.SoNL = Convert.ToInt32(fc["adults"]);
            }
            else
            {
                t.SoNL = 0;
            }
            if(fc["children"] != "")
            {
                t.SoTE = Convert.ToInt32(fc["children"]);
            }
            else
            {
                t.SoTE = 0;
            }
            if(fc["baby"] != "")
            {
                t.SoEB = Convert.ToInt32(fc["baby"]);
            }
            else
            {
                t.SoEB = 0;
            }
            t.HinhThucTT = fc["payment"];
            t.NgayDatTour = DateTime.Now;
            t.idTour = Convert.ToInt32(fc["tour_id"]);
            Tour tour = tourDAO.FindTourById(t.idTour);
            t.TongTien = t.SoNL * tour.GiaNL + t.SoTE * tour.GiaTE + t.SoEB * tour.GiaEB;
            dao.DatTour(t);

            string payment = "";
            string adults = "";
            string children = "";
            string baby = "";
            if(t.HinhThucTT == "CK")
            {
                payment = "Chuyển khoản";
            }
            if(t.HinhThucTT == "VP")
            {
                payment = "Thanh toán tại văn phòng";
            }
            if(t.SoNL > 0)
            {
                adults = t.SoNL.ToString() + " người lớn";
            }
            if(t.SoTE > 0)
            {
                children = t.SoTE.ToString() + " trẻ em";
            }
            if(t.SoEB > 0)
            {
                baby = t.SoEB.ToString() + " em bé";
            }
            string content = System.IO.File.ReadAllText(Server.MapPath("~/assets/template/neworder.html"));
            content = content.Replace("{{TourName}}", tour.TenTour);
            content = content.Replace("{{Days}}", tour.ThoiGian);
            content = content.Replace("{{DepartureDay}}", tour.NgayKhoiHanh.ToString());
            content = content.Replace("{{Departure}}", tour.NoiKhoiHanh);
            content = content.Replace("{{Vehicle}}", tour.PhuongTien);
            content = content.Replace("{{Schedule}}", tour.LichTrinh);
            content = content.Replace("{{Adults}}", adults);
            content = content.Replace("{{Childrens}}", children);
            content = content.Replace("{{Babys}}", baby);
            content = content.Replace("{{Payment}}", payment);
            content = content.Replace("{{CustomerName}}", fc["fullname"]);
            content = content.Replace("{{Address}}", fc["address"]);
            content = content.Replace("{{Phone}}", fc["phone"]);
            content = content.Replace("{{Email}}", fc["email"]);
            content = content.Replace("{{Pickup}}", fc["diemdon"]);
            content = content.Replace("{{Note}}", fc["notes"]);
            content = content.Replace("{{Total}}", t.TongTien.ToString());
            var toEmail = ConfigurationManager.AppSettings["ToEmailAddress"].ToString();

            new MailHelper().SendMail(fc["email"], "Đơn hàng đặt tour", content);
            new MailHelper().SendMail(toEmail, "Đơn hàng đặt tour mới", content);
            return Redirect("/Home/ThanhCong");
        }
        public ActionResult LoaiTour()
        {
            return PartialView();
        }
        public PartialViewResult ThanhCong()
        {
            return PartialView();
        }
    }
}