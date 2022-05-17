using Payment.Admin.Common;
using Payment.Admin.DAO;
using Payment.Admin.EF;
using Payment.Admin.Models.Login;
using Payment.Admin.ViewModel.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Payment.Admin.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(AccountModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UseDAO();
                //var result = dao.Login(model.UserName, Encryptor.MD5Hash(model.Password), true);
                var result = dao.Login(model.UserName,model.Password);
                if (result == 1)
                {
                    //var user = dao.GetById(model.UserName);
                    //var userSession = new UserLogin();
                    //userSession.UserName = user.UserName;
                    //userSession.UserID = user.ID;
                    //userSession.GroupID = user.GroupID;
                    //var listCredentials = dao.GetListCredential(model.UserName);

                    //Session.Add(CommonConstants.SESSION_CREDENTIALS, listCredentials);
                    //Session.Add(CommonConstants.USER_SESSION, userSession);
                    return RedirectToAction("Index", "Home");
                }
                //else if (result == 0)
                //{
                //    ModelState.AddModelError("", "Tài khoản không tồn tại.");
                //}
                //else if (result == -1)
                //{
                //    ModelState.AddModelError("", "Tài khoản đang bị khoá.");
                //}
                //else if (result == -2)
                //{
                //    ModelState.AddModelError("", "Mật khẩu không đúng.");
                //}
                //else if (result == -3)
                //{
                //    ModelState.AddModelError("", "Tài khoản của bạn không có quyền đăng nhập.");
                //}
                //else
                //{
                //    ModelState.AddModelError("", "đăng nhập không đúng.");
                //}
            }
            else
            {
                ModelState.AddModelError("", "Tài khoản của bạn không có quyền đăng nhập.");
            }    
            return View("Index");
        }
    }
}