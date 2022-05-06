using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VLUTransfer.Daos;
using VLUTransfer.Models;

namespace ForumCoderASP.Controllers
{
    public class AuthenticationController : Controller
    {
        UserDao userDao = new UserDao();

        // GET: Authentication
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user, FormCollection form)
        {
            if (string.IsNullOrEmpty(user.email) || string.IsNullOrEmpty(user.password) || string.IsNullOrEmpty(form["rePassword"]) || string.IsNullOrEmpty(user.fullName))
            {
                ViewBag.message = "1";
                return View();
            }
            else if (user.password != form["rePassword"])
            {
                ViewBag.message = "2";
                return View();
            }
            else
            {
                bool checkEmail = userDao.checkEmailExist(user.email);
                if (checkEmail)
                {
                    ViewBag.message = "3";
                    return View();
                }
                else
                {
                    string passwordMd5 = userDao.md5(user.password);
                    user.status = 0;
                    user.password = passwordMd5;
                    userDao.register(user);
                    return RedirectToAction("Login");
                }
            }

        }
        [HttpPost]
        public ActionResult Login(FormCollection form)
        {
            var email = form["email"];
            var password = form["password"];
            string passwordMd5 = userDao.md5(password);
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                ViewBag.message = "1";
                return View();
            }
            else
            {
                User checkLogin = userDao.checkLogin(email, passwordMd5);
                if (checkLogin != null)
                {
                    if(checkLogin.status == 0)
                    {
                        ViewBag.message = "2";
                        return View();
                    }
                    else
                    {
                        var userInformation = userDao.getUserByEmail(email);
                        Session.Add("User", userInformation);
                        return RedirectToAction("Index", "Home");
                    }
                   
                }
                else
                {
                    ViewBag.message = "3";
                    return View();
                }
            }

        }

        public ActionResult GetProfile(int id,string message)
        {
            User user = userDao.getUserById(id);
            ViewBag.user = user;
            ViewBag.message = message;
            return View();
        }

        public ActionResult UpdateProfile(User user)
        {
            userDao.updateProfile(user);          
           return RedirectToAction("GetProfile", new { id = user.userId, message = "1"}) ;
        }

        public ActionResult Logout()
        {
            Session.Remove("User");
            return Redirect("/");
        }

    }
}