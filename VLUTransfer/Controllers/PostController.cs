using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VLUTransfer.Daos;

namespace VLUTransfer.Controllers
{
    public class PostController : Controller
    {
        PostDao postDao = new PostDao();
        // GET: Post
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Detail(int id)
        {
            ViewBag.Detail = postDao.GetDetail(id);
            return View();
        }

        public ActionResult AddPost(string mess)
        {
            ViewBag.Msg = mess;
            return View();
        }
    }
}