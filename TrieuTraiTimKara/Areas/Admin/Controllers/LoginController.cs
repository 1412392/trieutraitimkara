using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.DAO;
using TrieuTraiTimKara.Common;
using TrieuTraiTimKara.Areas.Admin.Models;

namespace TrieuTraiTimKara.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        [SessionAuthorize]
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)//kiểm tra model valid
            {
                var dao = new UserDao();
                int result = dao.Login(model.Username, Encryptor.MD5Hash(model.Password));

                if (result==1)
                {

                    var user = dao.findByUsername(model.Username);
                    var usersession = new UserLogin();
                    usersession.UserName = user.email;
                    usersession.UserID = user.id;


                    Session.Add(CommonConstants.USER_SESSION, usersession);
                    return RedirectToAction("Index", "Home");//trả về Action Index của Home Controller Admin

                }
                else if(result==-1)
                {
                    ModelState.AddModelError("","Tài khoản không tồn tại");
                }
                else if(result==0)
                {
                    ModelState.AddModelError("", "Tài khoản đang bị khóa");
                }
                else if (result == 2)
                {
                    ModelState.AddModelError("", "Mật khẩu không đúng. Vui lòng nhập lại.");
                }


            }
            return View("Index");//return view index (kh có view login cùng tên)
        }

    }
}