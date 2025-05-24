using CNPM_64131196.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CNPM_64131196.Models
{
    public class MapComment : DbConfig
    {
        public MapComment() {
            db = new Congnghephanmem_64131196Entities();
        }

        public List<Comments> getComments(int id)
        {
            return db.Comments.Where(n => n.HuanLuyenVien.ID == id).ToList();
        }

        public Comments add(Comments comment)
        {
            Comments new_comment = db.Comments.Add(comment);
            db.SaveChanges();

            return new_comment;
        }

        public Comments remove(int id)
        {           
            Comments old_cmt = db.Comments.Remove(db.Comments.Find(id));
            db.SaveChanges();

            return old_cmt;
        }

        public bool update(string newComment, int id)
        {
            try
            {
                Comments cmt = db.Comments.Find(id);
                cmt.NhanXet = newComment;
                db.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}