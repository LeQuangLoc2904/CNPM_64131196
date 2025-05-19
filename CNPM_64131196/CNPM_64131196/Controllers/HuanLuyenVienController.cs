using CNPM_64131196.helper;
using CNPM_64131196.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CNPM_64131196.Controllers
{
    public class HuanLuyenVienController : Controller
    {
        // GET: HuanLuyenVien
        public ActionResult Index()
        {
            MapHuanLuyenVien mapHLV = new MapHuanLuyenVien();
            List<HuanLuyenVien> dsHLV = mapHLV.getAll();

            ViewBag.dsHLV = dsHLV;
            return View();
        }
     
        public ActionResult LichLamViec(int id)
        {
            List<String> quotes = new List<String>()
            {
            "Kỷ luật là nền tảng mà tất cả thành công được xây dựng. Thiếu kỷ luật chắc chắn sẽ dẫn đến sự thất bại (Jim Rohn)",
            "Khi bạn nghiêm khắc với bản thân, cuộc sống tự nhiên sẽ dễ dàng. Khi bạn dễ dàng với bản thân, cuộc sống tự nhiên sẽ khó khăn (Zig Ziglar)",
            "Cái giá của sự vượt trội là kỷ luật. Cái giá của sự tầm thường là thất vọng (William Arthur Ward)",
            "Ta không cần phải thông minh hơn những người khác. Ta phải có kỷ luật hơn những người khác. (Warren Buffett)",
            "Chúng ta phải lựa chọn: nỗi đau của sự kỷ luật hay nỗi đau của sự hối hận (Jim Rohn)"
            };

            int randomNumber = new Random().Next(0, quotes.Count);

            MapLichLamViec mapLichLamViec = new MapLichLamViec();
            ViewBag.lichLamViec = mapLichLamViec.getLichLamViecCuaPT(id);
            ViewBag.quote = quotes[randomNumber];

            return View();
        }

        [HttpPost]
        public ActionResult DangKyLichTap(int idPTrainer, int idLichTap)
        {
            var code = new { Success = false, msg = "", code = -1};    
            
            KhachHang khachHang = (KhachHang)Session["user"];

            MapLichLamViec mapLichLamViec = new MapLichLamViec();
            LichLamViecPT lichLamViecPT = mapLichLamViec.getLichLamViecById(idLichTap);

            DateTime ngayTap = DateHelper.getNextDateByDayOfWeek((DayOfWeek)lichLamViecPT.Thu - 1);
            DateTime ngayHienTai = DateTime.Today;

            // nếu ngày tập là ngày hiện tại
            if (ngayTap.Date == ngayHienTai.Date)
            {
                TimeSpan thoiGianHienTai = DateTime.Now.TimeOfDay;

                if (thoiGianHienTai >= lichLamViecPT.GioBatDau) // nếu tg hiện tại vượt lố thời điểm bắt đầu
                {
                    code = new { Success = false, msg = "Thời gian hiện tại đã vượt quá khung giờ tập của lịch, vui lòng chọn lịch khác!", code = -1 };
                    return Json(code);
                }
            }

            DatLichPT lichChinhThuc = new DatLichPT();
            lichChinhThuc.NgayDatLich = DateTime.Today;
            lichChinhThuc.MaPT = idPTrainer;
            lichChinhThuc.MaKH = khachHang.ID;
            lichChinhThuc.NgayTap = ngayTap;
            lichChinhThuc.GioBatDau = lichLamViecPT.GioBatDau;
            lichChinhThuc.GioKetThuc = lichLamViecPT.GioKetThuc;

            new MapDatLichPT().them(lichChinhThuc);
            code = new { Success = true, msg = "Đăng ký thành công", code = 1 };

            return Json(code);
        }
    }
}