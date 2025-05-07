using CNPM_64131196.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CNPM_64131196.Models
{
    public class MapKhachHang : DbConfig
    {
        public MapKhachHang()
        {
            db = new Congnghephanmem_64131196Entities();
        }
        public KhachHang getByTaiKhoan(string taiKhoan)
        {
            return db.KhachHang.Where(n=> n.TaiKhoan == taiKhoan).FirstOrDefault();
        }
    }
}