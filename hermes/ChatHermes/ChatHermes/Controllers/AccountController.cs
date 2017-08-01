using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChatHermes.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
       
        //[HttpPost]
        //public ActionResult Login(Models.LoginModel user)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (user.CanEnter(user.UN, user.PW))
        //        {
        //            return RedirectToAction("Index", "Home");
        //        }
        //        else
        //        {
        //            ModelState.AddModelError("", "Login data is incorrect!");
        //        }
        //    }
        //    return View(user);
        //}

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult Reset()
        {
            return View();
        }

        public ActionResult Logout()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}