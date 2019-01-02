using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Travel.Models.DAO;
using Travel.Models.Entities;
using Travel.Models.DTO;
using PagedList;

namespace Travel.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult LoginAction(Models.Account account)
        {
            if (ModelState.IsValid)
            {
                UserDAO dao = new UserDAO();
                bool check = dao.Login(account.TenTK, account.MatKhau);
                if (check)
                {
                    Session["UserName"] = account.TenTK;
                    return RedirectToAction("Admin", "Admin");
                }
                else
                {
                    ModelState.AddModelError("", "Tài khoản hoặc mật khẩu không đúng!");
                }
            }
            return RedirectToAction("Login", "Admin");
        }
        public ActionResult Logout()
        {
            Session["UserName"] = null;
            return View("Login");
        }
        public void SetViewBag()
        {
            MenuDAO MenuDAO = new MenuDAO();
            ViewBag.idMenu = new SelectList(MenuDAO.ListMenu(), "idMenu", "TenMenu");
        }
        public ActionResult Admin()
        {
            if (Session["UserName"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                return View();
            }
        }
        public ActionResult QuanLiTour(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 10;
            if (Session["UserName"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                TourDAO dao = new TourDAO();
                IQueryable<TourDTO> t = dao.AllTour();
                return View(t.OrderByDescending(n => n.idTour).ToPagedList(pageNumber, pageSize));
            }
        }
        public ActionResult Search(FormCollection fc, int? page)
        {
            if (Session["UserName"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                int pageNumber = (page ?? 1);
                int pageSize = 10;
                TourDAO dao = new TourDAO();
                IQueryable<TourDTO> t;

                string ten = fc["searchString"];
                string ngaydi = fc["ngaydi"];
                string gia = fc["gia"];
                t = dao.TimTour(ten, ngaydi, gia);
                return PartialView("QuanLiTour", t.OrderByDescending(n => n.idTour).ToPagedList(pageNumber, pageSize));
            }
        }
        public ActionResult ThemTour()
        {
            if (Session["UserName"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                SetViewBag();
                return View();
            }
        }
        [ValidateInput(false)]
        public ActionResult AddTour(Tour nt)
        {
            if (Session["UserName"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                TourDAO dao = new TourDAO();
                dao.ThemTour(nt);
                return RedirectToAction("QuanLiTour");
            }
        }
        public ActionResult SuaTour(int id)
        {
            if (Session["UserName"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                TourDAO dao = new TourDAO();
                Tour t = dao.FindTourById(id);
                SetViewBag();
                return View(t);
            }
            
        }
        [ValidateInput(false)]
        public ActionResult EditTour(Tour ut)
        {
            TourDAO dao = new TourDAO();
            dao.SuaTour(ut);
            return RedirectToAction("QuanLiTour");
        }
        public ActionResult XoaTour(int id)
        {
            TourDAO dao = new TourDAO();
            Tour t = dao.FindTourById(id);
            dao.XoaTour(t);
            return RedirectToAction("QuanLiTour");
        }
        public ActionResult Null()
        {
            return View();
        }

        //Menu
        public void SetViewBagMenu()
        {
            var MenuDAO = new MenuDAO();
            ViewBag.idMenuCha = new SelectList(MenuDAO.ListMenu(), "idMenu", "TenMenu");
        }
        public ActionResult QuanLiMenu(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 10;
            if (Session["UserName"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                MenuDAO dao = new MenuDAO();
                IQueryable<MenuDTO> m = dao.ListMenu();
                SetViewBagMenu();
                return View(m.OrderByDescending(n => n.idMenu).ToPagedList(pageNumber, pageSize));
            }
        }

        public ActionResult ThemMenu()
        {
            if (Session["UserName"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                SetViewBagMenu();
                return View();
            }
        }
        [ValidateInput(false)]
        public ActionResult AddMenu(Menu mn)
        {
            if (Session["UserName"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                MenuDAO dao = new MenuDAO();
                dao.ThemMenu(mn);
                return RedirectToAction("QuanLiMenu");
            }
        }
        public ActionResult SuaMenu(int id)
        {
            if (Session["UserName"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                MenuDAO dao = new MenuDAO();
                Menu m = dao.FindMenuById(id);
                SetViewBagMenu();
                return View(m);
            }
        }
        [ValidateInput(false)]
        public ActionResult EditMenu(Menu mn)
        {
            MenuDAO dao = new MenuDAO();
            dao.SuaMenu(mn);
            return RedirectToAction("QuanLiMenu");
        }
        public ActionResult XoaMenu(int id)
        {
            MenuDAO dao = new MenuDAO();
            Menu m = dao.FindMenuById(id);
            dao.XoaMenu(m);
            return RedirectToAction("QuanLiMenu");
        }

        //// content

        public ActionResult QuanLiNdMenu(int? page, string view)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 10;
            if (Session["UserName"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                MenuContentDAO dao = new MenuContentDAO();
                IQueryable<MenuContentDTO> m = dao.ListContent();
                SetViewBag();
                return PartialView(view, m.OrderBy(n => n.idND).ToPagedList(pageNumber, pageSize));
            }
        }
        public ActionResult ThemNdMenu(string view)
        {
            if (Session["UserName"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                Session["view"] = Request.UrlReferrer.ToString();
                SetViewBag();
                return View(view);
            }
        }
        public ActionResult SuaNdMenu(int id, string view)
        {
            if (Session["UserName"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                Session["view"] = Request.UrlReferrer.ToString();
                MenuContentDAO dao = new MenuContentDAO();
                NDMenu m = dao.FindContentById(id);
                SetViewBag();
                return View(view, m);
            }
        }
        [ValidateInput(false)]
        public ActionResult AddContent(NDMenu ct)
        {
            MenuContentDAO  dao = new MenuContentDAO();
            dao.AddContent(ct);
            return Redirect(Session["view"].ToString());
        }
        [ValidateInput(false)]
        public ActionResult EditContent(NDMenu ct)
        {
            MenuContentDAO dao = new MenuContentDAO();
            dao.EditContent(ct);
            return Redirect(Session["view"].ToString());
        }
        public ActionResult DeleteContent(int id)
        {
            MenuContentDAO dao = new MenuContentDAO();
            dao.DeleteContent(id);
            return Redirect(Request.UrlReferrer.ToString());
        }

        // nhan vien

        public ActionResult QuanLiNhanVien()
        {
            if (Session["UserName"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                EmployeeDAO dao = new EmployeeDAO();
                IQueryable<NhanVienHoTro> v = dao.ListEmployee();
                return View(v);
            }
        }

        public ActionResult ThemNhanVien()
        {
            if (Session["UserName"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                return View();
            }
        }
        public ActionResult AddEmployee(NhanVienHoTro nv)
        {
            if (Session["UserName"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                EmployeeDAO dao = new EmployeeDAO();
                dao.AddEmployee(nv);
                return RedirectToAction("QuanLiNhanVien");
            }
        }
        public ActionResult SuaNhanVien(int id)
        {
            if (Session["UserName"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                EmployeeDAO dao = new EmployeeDAO();
                NhanVienHoTro v = dao.FindEmployeeById(id);
                return View(v);
            }

        }
        public ActionResult EditEmployee(NhanVienHoTro nv)
        {
            EmployeeDAO dao = new EmployeeDAO();
            dao.ChangeEmployee(nv);
            return RedirectToAction("QuanLiNhanVien");
        }
        public ActionResult XoaNhanVien(int id)
        {
            EmployeeDAO dao = new EmployeeDAO();
            NhanVienHoTro v = dao.FindEmployeeById(id);
            dao.DeleteEmployee(v);
            return RedirectToAction("QuanLiNhanVien");
        }

        //van phong
        public ActionResult QuanLiVanPhong()
        {
            if (Session["UserName"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                OfficeDAO dao = new OfficeDAO();
                IQueryable<VanPhong> v = dao.ListOffice();
                return View(v);
            }
        }

        public ActionResult ThemVanPhong()
        {
            if (Session["UserName"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                return View();
            }
        }
        public ActionResult AddOffice(VanPhong vp)
        {
            if (Session["UserName"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                OfficeDAO dao = new OfficeDAO();
                dao.AddOffice(vp);
                return RedirectToAction("QuanLiVanPhong");
            }
        }
        public ActionResult SuaVanPhong(int id)
        {
            if (Session["UserName"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                OfficeDAO dao = new OfficeDAO();
                VanPhong v = dao.FindOfficeById(id);
                return View(v);
            }

        }
        public ActionResult EditOffice(VanPhong vp)
        {
            OfficeDAO dao = new OfficeDAO();
            dao.ChangeOffice(vp);
            return RedirectToAction("QuanLiVanPhong");
        }
        public ActionResult XoaVanPhong(int id)
        {
            OfficeDAO dao = new OfficeDAO();
            VanPhong v = dao.FindOfficeById(id);
            dao.DeleteOffice(v);
            return RedirectToAction("QuanLiVanPhong");
        }

        // tai khoan ngan hang


        public ActionResult TaiKhoanNganHang()
        {
            if (Session["UserName"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                BankDAO dao = new BankDAO();
                IQueryable<TaiKhoanNH> b = dao.ListBank();
                return View(b);
            }
        }

        public ActionResult ThemTaiKhoan()
        {
            if (Session["UserName"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                return View();
            }
        }
        public ActionResult AddBankAccount(TaiKhoanNH tk)
        {
            if (Session["UserName"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                BankDAO dao = new BankDAO();
                dao.AddBank(tk);
                return RedirectToAction("TaiKhoanNganHang");
            }
        }
        public ActionResult SuaTaiKhoan(string id)
        {
            if (Session["UserName"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                BankDAO dao = new BankDAO();
                TaiKhoanNH b = dao.FindBankById(id);
                return View(b);
            }

        }
        public ActionResult EditBankAccount(TaiKhoanNH ng)
        {
            BankDAO dao = new BankDAO();
            dao.ChangeBank(ng);
            return RedirectToAction("TaiKhoanNganHang");
        }
        public ActionResult XoaTaiKHoan(string id)
        {
            BankDAO dao = new BankDAO();
            TaiKhoanNH b = dao.FindBankById(id);
            dao.DeleteBank(b);
            return RedirectToAction("TaiKhoanNganHang");
        }

        ////dat tour
        public ActionResult QuanLiDatTour(int id)
        {
            if (Session["UserName"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                BookTourDAO dao = new BookTourDAO();
                TourDAO tour = new TourDAO();
                IQueryable<BookTourDTO> m = dao.ListBookTour(id);
                ViewBag.id = tour.FindTourById(id).idTour;
                ViewBag.name = tour.FindTourById(id).TenTour;
                return View(m);
            }
        }
        public ActionResult ChiTietDatTour(int idtour, int idkh)
        {
            if (Session["UserName"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                OfficeDAO office = new OfficeDAO();
                ViewBag.idVP = new SelectList(office.ListOffice(), "idVP", "TenVP");
                BankDAO bank = new BankDAO();
                ViewBag.MaTK = new SelectList(bank.ListBank(), "MaTK", "MaTK");
                Session["view"] = Request.UrlReferrer.ToString();
                BookTourDAO dao = new BookTourDAO();
                BookTourDTO m = dao.Detail(idkh, idtour);
                if(m.idVP != null)
                {
                    ViewBag.TenVP = office.FindOfficeById(m.idVP).TenVP;
                }
                return PartialView(m);
            }
        }
        public ActionResult EditBookTour(BookTourDTO bt)
        {
            BookTourDAO dao = new BookTourDAO();
            dao.EditBookTour(bt);
            return Redirect(Session["view"].ToString());
        }
        public ActionResult Payment(int idkh, int idtour)
        {
            BookTourDAO dao = new BookTourDAO();
            dao.Payment(idkh, idtour);
            return Redirect(Session["view"].ToString());
        }
        public ActionResult DSKH(int id)
        {
            ViewBag.id = id;
            CustomerDAO dao = new CustomerDAO();
            IQueryable<DSKH> m = dao.ListCustomer(id);
            return PartialView(m);
        }
        public ActionResult ThemDSKH(int id)
        {
            if (Session["UserName"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                CustomerDAO cus = new CustomerDAO();
                ViewBag.idKHCha = new SelectList(cus.ListNameCustomer(id), "idKH", "HoTen");
                Session["view"] = Request.UrlReferrer.ToString();
                ViewBag.id = id;
                return View();
            }
        }
        public ActionResult AddCustomer(DSKH c, FormCollection fc)
        {
            CustomerDAO dao = new CustomerDAO();
            int id = Convert.ToInt32(fc["tour_id"]);
            dao.AddCustomer(c, id);
            return Redirect(Session["view"].ToString());
        }
        public ActionResult SuaDSKH(int id)
        {
            CustomerDAO cus = new CustomerDAO();
            DSKH c = cus.FindCustomerById(id);
            ViewBag.idKHCha = new SelectList(cus.ListNameCustomer(c.idTour), "idKH", "HoTen");
            Session["view"] = Request.UrlReferrer.ToString();
            return View(c);
        }
        public ActionResult EditCustomer(DSKH lc)
        {
            CustomerDAO dao = new CustomerDAO();
            dao.EditCustomer(lc);
            return Redirect(Session["view"].ToString());
        }
        public ActionResult DeleteCustomer(int id)
        {
            CustomerDAO dao = new CustomerDAO();
            dao.DeleteCutomer(id);
            return Redirect(Request.UrlReferrer.ToString());
        }
    }
}