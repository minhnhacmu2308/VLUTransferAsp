using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VLUTransfer.Daos;

namespace ForumCoderASP.Controllers.Admin
{
    public class AdminHomeController : Controller
    {
        PostDao postDao = new PostDao();
        UserDao userDao = new UserDao();
        // GET: AdminHome
        public ActionResult Index()
        {
            string result = (string)Session["Admin"];
            if (string.IsNullOrEmpty(result))
            {              
                return RedirectToAction("Index", "AdminLogin");
            }
            else
            {
                ViewBag.DD = postDao.getHome(0).Count;
                ViewBag.HD = postDao.getHome(1).Count;
                ViewBag.BC = postDao.getHome(2).Count;
                ViewBag.UXT = userDao.getHome(0).Count;
                ViewBag.UHD = userDao.getHome(1).Count;
                ViewBag.UBC = userDao.getHome(2).Count;
                return View();
            }
              
        }
    }
}