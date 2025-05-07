using CNPM_64131196.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CNPM_64131196.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }      

        public ActionResult DangNhap()
        {
            return View();
        }

        [HttpPost]      
        public ActionResult DangNhap(string taiKhoan, string matKhau)
        {
            MapDB mapDB = new MapDB();
            bool ok = mapDB.dangnhap(taiKhoan, matKhau);
            
            if (!ok)
            {
                ViewBag.thongbao = mapDB.message;
                ViewBag.color = "text-danger";
                ViewBag.taikhoan = taiKhoan;
                return View();
            }

            KhachHang kh = new MapKhachHang().getByTaiKhoan(taiKhoan);
            if (kh != null)
            {
                Session["user"] = kh;
                return RedirectToAction("Index");
            }

            HuanLuyenVien hlv = new MapHuanLuyenVien().getByTaiKhoan(taiKhoan);
            if (hlv != null)
            {
                Session["user"] = hlv;
                return RedirectToAction("Index", "Home", new { area = "HuanLuyenVien" });
            }

            NguoiQuanTri nqt = new MapNguoiQuanTri().getByTaiKhoan(taiKhoan);
            Session["user"] = nqt;

            return RedirectToAction("Index", "Home", new { area = "Admin" });           
        }

        public ActionResult DangXuat()
        {
            Session["user"] = null;
            return RedirectToAction("Index");
        }
    }
}