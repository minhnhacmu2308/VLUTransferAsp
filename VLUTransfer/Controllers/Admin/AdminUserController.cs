using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VLUTransfer.Daos;
using VLUTransfer.Models;

namespace VLUTransfer.Controllers.Admin
{
    public class AdminUserController : Controller
    {
        // GET: AdminUser
        UserDao userDao = new UserDao();
        // GET: AdminUser
        public ActionResult Index(string msg)
        {
            ViewBag.Msg = msg;
            ViewBag.List = userDao.getAll();
            return View();
        }

        public ActionResult Update(User user)
        {
            userDao.update(user);
            return RedirectToAction("Index", new { msg = "1" });
        }
    }
}