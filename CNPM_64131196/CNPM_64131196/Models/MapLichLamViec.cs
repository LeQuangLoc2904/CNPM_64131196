using CNPM_64131196.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CNPM_64131196.Models
{
    public class MapLichLamViec : DbConfig
    {
        public MapLichLamViec() { 
            db = new Congnghephanmem_64131196Entities();
        }

        public List<LichLamViecPT> getLichLamViecById(int id)
        {
            return db.LichLamViecPT.Where(n => n.HuanLuyenVien.ID == id).ToList();
        }
    }
}