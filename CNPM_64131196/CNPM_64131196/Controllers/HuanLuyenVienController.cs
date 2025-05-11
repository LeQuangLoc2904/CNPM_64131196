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
    }
}