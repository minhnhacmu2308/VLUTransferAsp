using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VLUTransfer.Daos;
using VLUTransfer.Models;

namespace VLUTransfer.Controllers
{
    public class PostController : Controller
    {
        PostDao postDao = new PostDao();
        RegisterDao registerDao = new RegisterDao();
        // GET: Post
        public ActionResult Index(int page)
        {
            ViewBag.List = postDao.GetList(page, 5);
            ViewBag.tag = page;
            ViewBag.pageSize = postDao.GetNumber();
            return View();
        }

        public ActionResult Detail(int id,string mess)
        {
            ViewBag.Detail = postDao.GetDetail(id);
            ViewBag.message = mess;
            return View();
        }

        public ActionResult AddPost(string mess)
        {
            ViewBag.message = mess;
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult PostAdd(Post post, HttpPostedFileBase file)
        {
            User user = (User) Session["USER"];
            DateTime now = DateTime.Now;
            post.status = 0;
            post.userId = user.userId;
            post.createdAt = now.ToString();
            string reName = DateTime.Now.Ticks.ToString() + file.FileName;
            file.SaveAs(Server.MapPath("~/Content/images/" + reName));
            post.image = reName;
            postDao.add(post);
            var message = "1";
            return RedirectToAction("AddPost", new { mess = message });
        }

        [HttpPost]
        public ActionResult Search(FormCollection form)
        {
            string name = form["title"];
            return RedirectToAction("Search", new { page = 0, name = name });
        }

        [HttpGet]
        public ActionResult Search(int page, string name)
        {
            if (page == 0)
            {
                page = 1;
            }

            ViewBag.List = postDao.SearchByName(page, 5,name);
            ViewBag.tag = page;
            ViewBag.name = name;
            ViewBag.pageSize = postDao.GetNumberRoomByName(name);
            return View();
        }

        [HttpPost]
        public ActionResult RegisterPost(FormCollection form)
        {
            int postId = Int32.Parse(form["postId"]);
            User user = (User)Session["USER"];
            if (user == null)
            {
                return RedirectToAction("Detail", new { id = postId, mess = "1" });
            }
            else
            {
                Register register = registerDao.checkExist(user.userId, postId);
                if(register == null)
                {
                    Register obj = new Register
                    {
                        postId = postId,
                        userId = user.userId,
                        dateRegister = DateTime.Now.ToString(),
                        status = 0
                    };
                    registerDao.Add(obj);
                    return RedirectToAction("Detail", new { id = postId, mess = "2" });
                }
                else
                {
                    return RedirectToAction("Detail", new { id = postId, mess = "3" });
                }
               
            }
        }
    }
}