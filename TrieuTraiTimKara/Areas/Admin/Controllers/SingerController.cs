using Models.DAO;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TrieuTraiTimKara.Areas.Admin.Controllers
{
    public class SingerController : Controller
    {
        // GET: Admin/Singer
        SingerDao singerDao = new SingerDao();

        [SessionAuthorize]
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var lstCate = singerDao.GetAllSinger(page, pageSize);
            if (lstCate == null)
            {
                lstCate = new List<Singer>();
            }
            return View(lstCate);
        }

        [SessionAuthorize]
        public ActionResult AddSinger(int id = 0)
        {
            Singer cate = new Singer();
            cate = singerDao.GetSingerByID(id);
            if (cate == null)
            {
                cate = new Singer();
            }

            return View(cate);
        }


        //thêm/cập nhật singer
        [SessionAuthorize]
        [HttpPost]
        public ActionResult AddSinger(Singer cate)
        {
            if (ModelState.IsValid)
            {
                bool result = false;
                if (cate.id > 0)
                {
                    result = singerDao.Update(cate);
                }
                else
                {
                    result = singerDao.Insert(cate);
                }

                if (result)
                {
                    // SetAlert("Cập nhật sản phẩm thành công", "success");
                    return RedirectToAction("Index", "Singer");
                }
                else
                {
                    ModelState.AddModelError("", "Có lỗi xảy ra. Thêm thất bại");
                }


            }

            return View();

        }

        [HttpPost]
        public JsonResult delete(int id)
        {

            bool resultDelete = singerDao.Delete(id);

            return Json(
                    new
                    {
                        status = resultDelete,
                    });


        }

        [SessionAuthorize]
        public ActionResult SearchSinger(string q)
        {
            string xx = "";

            var lstsinger = singerDao.GetAllSingerByKeyword(q, 0, 5);
            if (lstsinger != null)
            {
                lstsinger = lstsinger.ToList();
            }
            else
            {
                lstsinger = new List<Singer>();
            }

            foreach (var item in lstsinger)
            {
                xx = xx + item.id.ToString() + "|" + item.name + "\n";
            }
            if (string.IsNullOrEmpty(xx))
            {
                xx = "0|Không tìm thấy - Enter để thêm|" + q + "\n";
            }
            return Content(xx.Trim());
        }
    }
}