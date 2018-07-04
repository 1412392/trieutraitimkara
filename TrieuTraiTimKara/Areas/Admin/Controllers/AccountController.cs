using Models.DAO;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrieuTraiTimKara.Common;

namespace TrieuTraiTimKara.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        // GET: Admin/Account
        AccountDao accDao = new AccountDao();

        [SessionAuthorize]
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var lstAcc = accDao.GetAllAccount(page, pageSize);
            if (lstAcc == null)
            {
                lstAcc = new List<Account>();
            }
            return View(lstAcc);
        }

        [SessionAuthorize]
        public ActionResult AddAccount(int id = 0)
        {
            Account acc = new Account();
            acc = accDao.GetAccountByID(id);
            if (acc == null)
            {
                acc = new Account();
            }

            return View(acc);
        }


        //thêm/cập nhật Account
        [SessionAuthorize]
        [HttpPost]
        public ActionResult AddAccount(Account acc)
        {
            if (ModelState.IsValid)
            {
                bool result = false;


                if (acc.id > 0)//đang update
                {
                    Account currentAccount = accDao.GetAccountByID(acc.id);
                    if (acc.password.Trim() != currentAccount.password.Trim())//đã đổi password
                    {
                        acc.password = Encryptor.MD5Hash(acc.password);
                    }
                    result = accDao.Update(acc);
                }
                else//đang insert
                {
                    var lstAcc = accDao.GetAllAccount(1, 10000);
                    foreach (var item in lstAcc)
                    {
                        if (item.email == acc.email)
                        {
                            ModelState.AddModelError("", "Email đã tồn tại!");
                            return View();
                        }
                    }

                    acc.password = Encryptor.MD5Hash(acc.password);
                    result = accDao.Insert(acc);
                }

                if (result)
                {
                    // SetAlert("Cập nhật sản phẩm thành công", "success");
                    return RedirectToAction("Index", "Account");
                }
                else
                {
                    ModelState.AddModelError("", "Có lỗi xảy ra. Thêm thất bại");
                }


            }

            return View();

        }
        [SessionAuthorize]
        [HttpPost]
        public JsonResult delete(int id)
        {

            bool resultDelete = accDao.Delete(id);

            return Json(
                    new
                    {
                        status = resultDelete,
                    });


        }
    }
}