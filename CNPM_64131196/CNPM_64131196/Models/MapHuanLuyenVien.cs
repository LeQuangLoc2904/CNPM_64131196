using CNPM_64131196.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CNPM_64131196.Models
{
    public class MapHuanLuyenVien : DbConfig
    {
        public MapHuanLuyenVien()
        {
            db = new Congnghephanmem_64131196Entities();
        }
        public HuanLuyenVien getByTaiKhoan(string taiKhoan)
        {
            return db.HuanLuyenVien.Where(n => n.TaiKhoan == taiKhoan).FirstOrDefault();
        } 

        public List<HuanLuyenVien> getAll()
        {
            return db.HuanLuyenVien.ToList();
        }
    }
}