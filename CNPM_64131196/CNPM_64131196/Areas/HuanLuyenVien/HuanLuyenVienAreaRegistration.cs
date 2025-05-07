using System.Web.Mvc;

namespace CNPM_64131196.Areas.HuanLuyenVien
{
    public class HuanLuyenVienAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "HuanLuyenVien";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "HuanLuyenVien_default",
                "HuanLuyenVien/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}