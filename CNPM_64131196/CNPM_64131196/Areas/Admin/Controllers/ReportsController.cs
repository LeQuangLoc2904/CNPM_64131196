using System;
using System.Linq;
using System.Web.Mvc;
using CNPM_64131196.Models;      
using System.Collections.Generic;

namespace CNPM_64131196.Areas.Admin.Controllers
{
    public class ReportsController : Controller
    {
        private Congnghephanmem_64131196Entities db = new Congnghephanmem_64131196Entities();

        // GET: Reports/MonthlyRevenue
        public ActionResult MonthlyRevenue(int year = 2025)
        {
            var allKhachHang = db.KhachHang.ToList();

            var withPayment = allKhachHang
                .Where(k => k.NgayThanhToanLanCuoi.HasValue)
                .ToList();

            var doanhThuTheoThang = withPayment
                .Where(k => k.NgayThanhToanLanCuoi.Value.Year == year)
                .GroupBy(k => k.NgayThanhToanLanCuoi.Value.Month)
                .Select(g => new {
                    Month = g.Key,
                    TotalRevenue = g.Sum(x => x.ThanhTienLanCuoi)
                })
                .ToList();

            var months = Enumerable.Range(1, 12);
            var revenueData = months
                .Select(m => doanhThuTheoThang
                    .FirstOrDefault(r => r.Month == m)?.TotalRevenue ?? 0)
                .ToArray();
            var labels = months
                .Select(m => new DateTime(year, m, 1).ToString("MMM"))
                .ToArray();

            ViewBag.Labels = labels;
            ViewBag.RevenueData = revenueData;
            ViewBag.ReportYear = year;

            return View();
        }


    }
}
