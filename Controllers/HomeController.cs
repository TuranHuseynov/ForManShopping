using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YeniShoppingProject.Models;
using YeniShoppingProject.Viewmodel;

namespace YeniShoppingProject.Controllers
{
    public class HomeController : Controller
    {

        MyModel vm = new MyModel();
        ShoppingNewEntities1 db = new ShoppingNewEntities1();


        public ActionResult Index()
        {

            vm._sekiller = db.Photos.ToList();
            vm._mallars = db.Mallars.ToList();
            vm._allcompanies = db.Companies.ToList();
            vm._categories = db.Categories.ToList();
            vm._brands = db.Brands.ToList();


            return View(vm);
        }

        public ActionResult Haqqimizda()
        {
            return View("Haqqimizda");
        }


        public ActionResult BLogMehsul(int id)
        {
            //vm._mallars = db.Mallars.Where(d => d.product_id == id).ToList();
            vm.sekiller = db.Photos.Where(m => m.photo_id == id).ToList();
            return View(vm);
        }


        [HttpPost]
        public ActionResult BLogMehsul(FormCollection frm)
        {

            int iduser = Convert.ToInt32(Session["id"]);



            Order ztr = new Order();
            ztr.order_user_id = iduser;
            ztr.order_status_id = 1;
            ztr.order_product = frm["zakaz_mehsulu"];
            ztr.order_time = DateTime.Now;
            ztr.order_adress = frm["zakaz_adres"];

            db.Orders.Add(ztr);
            db.SaveChanges();


            return RedirectToAction("Index");
        }



        public PartialViewResult ShowCat(int id)
        {
            var catid = db.Categories.Find(id);

            List<Mallar> products = db.Mallars.Where(x => x.product_category_id == id).ToList();
            return PartialView("PartialViews/_CategoryItems", products);
        }




        public ActionResult IstekMesaj()
        {
            vm._messages = db.MessageWants.ToList();

            return View(vm);
        }



        [HttpPost]
        public ActionResult IstekMesaj(FormCollection frm)
        {

            int id = Convert.ToInt32(Session["id"]);

            MessageWant ismes = new MessageWant();
            ismes.wantmessage_user_id = id;
            ismes.wantmessage_text = frm["istek_mesaj"];

            db.MessageWants.Add(ismes);
            db.SaveChanges();

            return View();
        }




        public ActionResult Qeydiyyat()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Qeydiyyat(FormCollection frm)
        {
            User yeniuser = new User();
            yeniuser.user_fullname = frm["user_ad_soyad"];
            yeniuser.user_email = frm["user_email"];
            yeniuser.user_phone = frm["user_telefon"];
            yeniuser.user_password = frm["user_password"];
            db.Users.Add(yeniuser);
            db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }


        public ActionResult Sebetler()
        {
            var iduser = Convert.ToInt32(Session["id"]);
            vm._boxesss = db.OthBxoes.Where(d => d.otbox_user_id == iduser).ToList();
            return View(vm);
        }

        [HttpPost]
        public ActionResult Sebetler(int mehsulid)
        {
            var iduser = Convert.ToInt32(Session["id"]);
            var mehsul = db.Photos.Where(d => d.photo_id == mehsulid).First().photo_id;
            //var mehsul = db.Sekils.Where(d => d.sekil_id == idmehsul).First().sekil_id;

            db.OthBxoes.Add(new OthBxo
            {
                otbox_user_id = iduser,
                otbox_photo_id = mehsul
            });


            db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }








    }
}