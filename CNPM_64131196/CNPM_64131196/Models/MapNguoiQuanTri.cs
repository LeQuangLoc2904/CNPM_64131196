using CNPM_64131196.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CNPM_64131196.Models
{
    public class MapNguoiQuanTri : DbConfig
    {
        public MapNguoiQuanTri() {
            db = new Congnghephanmem_64131196Entities();
        }

        public NguoiQuanTri getByTaiKhoan(string taiKhoan)
        {
            return db.NguoiQuanTri.Where(n => n.TaiKhoan == taiKhoan).FirstOrDefault();
        }
    }
}