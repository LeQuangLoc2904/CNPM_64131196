using CNPM_64131196.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CNPM_64131196.Models
{
    public class MapDatLichPT : DbConfig
    {
        public MapDatLichPT() {
            db = new Congnghephanmem_64131196Entities();
        }

        public void them(DatLichPT lichChinhThuc)
        {
            db.DatLichPT.Add(lichChinhThuc);
            db.SaveChanges();
        }

        public bool isTrainingScheduleExists(int idPT, DateTime ngayTap)
        {
            return db.DatLichPT.Any(n => n.NgayTap == ngayTap && n.HuanLuyenVien.ID == idPT);
        }

        public List<DatLichPT> getLichKhachById(int id)
        {
            return db.DatLichPT.Where(n => n.KhachHang.ID == id).ToList();
        }

        public DatLichPT getById(int id)
        {
            return db.DatLichPT.Find(id);
        }

        public DatLichPT deleteLichById(int id)
        {
            DatLichPT lich = getById(id);
            lich = db.DatLichPT.Remove(lich);
            db.SaveChanges();

            return lich;

        }

    }
}