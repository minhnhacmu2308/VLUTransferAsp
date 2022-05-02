using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ForumCoderASP.Controllers.Admin
{
    public class AdminHomeController : Controller
    {
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
                return View();
            }
              
        }
    }
}