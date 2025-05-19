using CNPM_64131196.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CNPM_64131196.Controllers
{
    public class LichTapController : Controller
    {
        // GET: LichTap
        public ActionResult Index(int idKH)
        {
            ViewBag.idKH = idKH;
            return View();
        }

        public ActionResult PartTial_LichCuaKhach(int idKH)
        {
            MapDatLichPT mapDatLichPT = new MapDatLichPT();
            List<DatLichPT> lst_lichKhach = mapDatLichPT.getLichKhachById(idKH);

            ViewBag.list_lichkhach = lst_lichKhach.OrderBy(n=>n.NgayTap).ThenBy(n=> n.GioBatDau).ToList();

            return PartialView();
        }

        [HttpPost]
        public ActionResult XoaLich(int id)
        {
            var code = new { Success = false, msg = "Xóa thất bại", code = -1};
            MapDatLichPT mapDatLichPT = new MapDatLichPT();
            DatLichPT lich = mapDatLichPT.deleteLichById(id);
            
            if (lich != null)
            {
                code = new { Success = true, msg = "Xóa thành công", code = 1 };
            }

            return Json(code);
        }
    }
}