using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YeniShoppingProject.Models;
using YeniShoppingProject.Viewmodel;

namespace YeniShoppingProject.Controllers
{
    public class LoginController : Controller
    {
        ShoppingNewEntities1 db = new ShoppingNewEntities1();
        MyModel vm = new MyModel();
        public static User usrlogin;

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }



        [HttpGet]
        public ActionResult UserLog()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UserLog(User usr)
        {
            usrlogin = db.Users.Where(e => e.user_email == usr.user_email).FirstOrDefault();
            Session["usr_password"] = usr.user_password;


            if (usrlogin != null)
            {
                if (usrlogin.user_password == usr.user_password)
                {
                    Session["usr_email"] = usrlogin.user_email;
                    Session["id"] = usrlogin.user_id.ToString();
                    Session["ad"] = usrlogin.user_fullname;

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("Index");
                }

            }
            else
            {
                return RedirectToAction("Index");
            }

        }

        public ActionResult Logout()
        {
            Session["id"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}