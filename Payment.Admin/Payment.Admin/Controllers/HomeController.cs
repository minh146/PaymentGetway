using Payment.Admin.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Payment.Admin.Controllers
{
    public class HomeController : Controller
    {
        private PaymentEntities paymentEntities = null;
        public HomeController()
        {
            paymentEntities = new PaymentEntities();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            var result = paymentEntities.banks.Select(x => x.bank_name).ToList();
            ViewBag.Message = result;

            return View();
        }
        [HttpGet]
        public ActionResult CreateUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateUser(user user)
        {
            if(ModelState.IsValid)
            {              
                paymentEntities.users.Add(user);
                paymentEntities.SaveChanges();
                var id = user.id;
                if (id > 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", StaticResources.Resources.InsertCategoryFailed);
                }
            }

            return View(user);
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}