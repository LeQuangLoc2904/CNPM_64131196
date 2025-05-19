using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CNPM_64131196.Models;

namespace CNPM_64131196.Areas.Admin.Controllers
{
    public class KhachHangsController : Controller
    {
        private Congnghephanmem_64131196Entities db = new Congnghephanmem_64131196Entities();

        // GET: Admin/KhachHangs
        public ActionResult Index()
        {
            var khachHang = db.KhachHang.Include(k => k.GoiTap).Include(k => k.VaiTro);
            return View(khachHang.ToList());
        }

        // GET: Admin/KhachHangs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhachHang khachHang = db.KhachHang.Find(id);
            if (khachHang == null)
            {
                return HttpNotFound();
            }
            return View(khachHang);
        }

        // GET: Admin/KhachHangs/Create
        public ActionResult Create()
        {
            ViewBag.MaGoiTap = new SelectList(db.GoiTap, "ID", "Ten");
            ViewBag.MaVaiTro = new SelectList(db.VaiTro, "ID", "Ten");
            return View();
        }

        // POST: Admin/KhachHangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Ten,GioiTinh,SoDienThoai,AnhDaiDien,NgayDangKyLanDau,NgayBatDauGoiTap,NgayKetThucGoiTap,TinhTrangThanhToan,MaVaiTro,MaGoiTap,TaiKhoan,MatKhau")] KhachHang khachHang)
        {
            if (ModelState.IsValid)
            {
                db.KhachHang.Add(khachHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaGoiTap = new SelectList(db.GoiTap, "ID", "Ten", khachHang.MaGoiTap);
            ViewBag.MaVaiTro = new SelectList(db.VaiTro, "ID", "Ten", khachHang.MaVaiTro);
            return View(khachHang);
        }

        // GET: Admin/KhachHangs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhachHang khachHang = db.KhachHang.Find(id);
            if (khachHang == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaGoiTap = new SelectList(db.GoiTap, "ID", "Ten", khachHang.MaGoiTap);
            ViewBag.MaVaiTro = new SelectList(db.VaiTro, "ID", "Ten", khachHang.MaVaiTro);
            return View(khachHang);
        }

        // POST: Admin/KhachHangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Ten,GioiTinh,SoDienThoai,AnhDaiDien,NgayDangKyLanDau,NgayBatDauGoiTap,NgayKetThucGoiTap,TinhTrangThanhToan,MaVaiTro,MaGoiTap,TaiKhoan,MatKhau")] KhachHang khachHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(khachHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaGoiTap = new SelectList(db.GoiTap, "ID", "Ten", khachHang.MaGoiTap);
            ViewBag.MaVaiTro = new SelectList(db.VaiTro, "ID", "Ten", khachHang.MaVaiTro);
            return View(khachHang);
        }

        // GET: Admin/KhachHangs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhachHang khachHang = db.KhachHang.Find(id);
            if (khachHang == null)
            {
                return HttpNotFound();
            }
            return View(khachHang);
        }

        // POST: Admin/KhachHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KhachHang khachHang = db.KhachHang.Find(id);
            db.KhachHang.Remove(khachHang);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
