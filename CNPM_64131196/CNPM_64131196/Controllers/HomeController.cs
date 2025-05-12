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
            List<String> quotes = new List<String>()
            {
            "Kỷ luật là nền tảng mà tất cả thành công được xây dựng. Thiếu kỷ luật chắc chắn sẽ dẫn đến sự thất bại (Jim Rohn)",
            "Khi bạn nghiêm khắc với bản thân, cuộc sống tự nhiên sẽ dễ dàng. Khi bạn dễ dàng với bản thân, cuộc sống tự nhiên sẽ khó khăn (Zig Ziglar)",
            "Cái giá của sự vượt trội là kỷ luật. Cái giá của sự tầm thường là thất vọng (William Arthur Ward)",
            "Ta không cần phải thông minh hơn những người khác. Ta phải có kỷ luật hơn những người khác. (Warren Buffett)",
            "Chúng ta phải lựa chọn: nỗi đau của sự kỷ luật hay nỗi đau của sự hối hận (Jim Rohn)"
            };

            int randomNumber1 = new Random().Next(0, quotes.Count), randomNumber2;
          
            do
            {
                randomNumber2 = new Random().Next(0, quotes.Count);
            } while (randomNumber2 == randomNumber1);

            ViewBag.quote1 = quotes[randomNumber1];
            ViewBag.quote2 = quotes[randomNumber2];

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
                return RedirectToAction("Index", "Home", new { area = "Trainer" });
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