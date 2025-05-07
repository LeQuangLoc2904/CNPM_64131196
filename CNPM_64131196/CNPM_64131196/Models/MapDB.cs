using CNPM_64131196.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CNPM_64131196.Models
{
    public class MapDB : DbConfig
    {
        public MapDB()
        {
            db = new Congnghephanmem_64131196Entities();
        }

        public bool dangnhap(string taiKhoan, string matKhau)
        {
            if (String.IsNullOrEmpty(taiKhoan) || String.IsNullOrEmpty(matKhau)) {
                message = "*Thông tin cần điền đầy đủ";
                return false;
            }

            KhachHang kh = db.KhachHang.Where(n => n.TaiKhoan == taiKhoan && n.MatKhau == matKhau).FirstOrDefault();
            if (kh != null) return true;

            HuanLuyenVien hlv = db.HuanLuyenVien.Where(n => n.TaiKhoan == taiKhoan && n.MatKhau == matKhau).FirstOrDefault();
            if (hlv != null) return true;

            NguoiQuanTri nqt = db.NguoiQuanTri.Where(n => n.TaiKhoan == taiKhoan && n.MatKhau == matKhau).FirstOrDefault();
            if (nqt != null) return true;

            message = "*Thông tin tài khoản không tồn tại";           

            return false;
        }


    }
}