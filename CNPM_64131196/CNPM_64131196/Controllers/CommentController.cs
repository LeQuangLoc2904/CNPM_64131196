using CNPM_64131196.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CNPM_64131196.Controllers
{
    public class CommentController : Controller
    {
        // GET: Comment
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(int idPt, string rating, string comment)
        {
            var code = new { Success = false, msg = "", code = -1 };
            KhachHang user = (KhachHang)Session["user"];

            Comments new_comment = new Comments();
            new_comment.MaKH = user.ID;
            new_comment.MaPT = idPt;
            new_comment.NhanXet = comment;
            new_comment.Diem = Convert.ToInt32(rating);
            new_comment.NgayDanhGia = DateTime.Now;

            Comments check = new MapComment().add(new_comment);
            if (check != null)
            {
                code = new { Success = true, msg = "Bình luận thành công", code = 1 };
            }

            return Json(code);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var code = new { Success = false, msg = "", code = -1 };
            MapComment mapComment = new MapComment();
            Comments old_cmt = mapComment.remove(id);

            if (old_cmt != null)
            {
                code = new { Success = true, msg = "Xóa thành công", code = 1 };
            }

            return Json(code);
        }

        [HttpPost]
        public ActionResult Update(string newComment, int id)
        {
            var code = new { Success = false, msg = "Chỉnh sửa thất bại", code = -1 };
            MapComment mapComment = new MapComment();

            bool ok = mapComment.update(newComment, id);
            if (ok)
            {
                code = new { Success = true, msg = "Sửa thành công", code = 1 };
            }

            return Json(code);
        }

        public ActionResult Partial_Comments(int id)
        {
            MapComment mapComment = new MapComment();
            List<Comments> comments = mapComment.getComments(id).OrderByDescending(n => n.NgayDanhGia).ToList();
            ViewBag.lst_comment = comments;

            return PartialView();
        }
    }
}