using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VLUTransfer.Daos;
using VLUTransfer.Models;

namespace VLUTransfer.Controllers.Admin
{
    public class AdminPostController : Controller
    {
        PostDao postDao = new PostDao();
        // GET: AdminUser
        public ActionResult Index(string msg)
        {
            ViewBag.Msg = msg;
            ViewBag.List = postDao.getAll();
            return View();
        }

        public ActionResult Update(Post post)
        {
            postDao.update(post);
            return RedirectToAction("Index", new { msg = "1" });
        }
    }
}