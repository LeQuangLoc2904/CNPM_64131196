//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CNPM_64131196.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Comments
    {
        public int ID { get; set; }
        public Nullable<int> MaPT { get; set; }
        public Nullable<int> MaKH { get; set; }
        public Nullable<int> Diem { get; set; }
        public string NhanXet { get; set; }
        public Nullable<System.DateTime> NgayDanhGia { get; set; }
    
        public virtual KhachHang KhachHang { get; set; }
        public virtual HuanLuyenVien HuanLuyenVien { get; set; }
    }
}
