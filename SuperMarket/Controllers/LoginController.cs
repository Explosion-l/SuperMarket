using SuperMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperMarket.Controllers
{
    public class LoginController : Controller
    {
        private SuperMarketEntities db = new SuperMarketEntities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        //实现登录功能
        [HttpPost]
        public ActionResult Index(string username,string password)
        {
            if (string.IsNullOrEmpty(username))
            {
                ViewBag.notice = "用户名不能为空";
                return View();
            }
            if (string.IsNullOrEmpty(password))
            {
                ViewBag.notice = "密码不能为空";
                return View();
            }
            //查询用户名是否正确
            Users user = db.Users.FirstOrDefault(p => p.UserName == username);
            if(user == null)
            {
                ViewBag.notice = "用户不存在";
                return View();
            }
            else if(user.PassWord != password)
            {
                ViewBag.notice = "密码错误";
                return View();
            }
            else
            {
                return RedirectToAction("Admin/index");
            }
        }
    }
}