using Models.DAO;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TrieuTraiTimKara.Areas.Admin.Controllers
{
    public class MediaController : Controller
    {
        MediaDao mediaDao = new MediaDao();
        // GET: Admin/Media
        [SessionAuthorize]
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var lstMedia = mediaDao.GetAllMedia(page, pageSize);
            if (lstMedia == null)
            {
                lstMedia = new List<Media>();
            }
            return View(lstMedia);
        }
        [SessionAuthorize]
        public ActionResult AddMedia(int id = 0)
        {
            Media acc = new Media();
            acc = mediaDao.GetMediaByID(id);
            if (acc == null)
            {
                acc = new Media();
            }
            setViewBag();
            return View(acc);
        }

        public void setViewBag(long? selectedID = null)
        {
            var categorydao = new CategoryDao();
            //Viewbag để bingding dữ liệu từ model sang views
            //Chọn thằng nào có CategoryID
            ViewBag.CategoryID = new SelectList(categorydao.GetAllCategory(1,100), "id", "name", selectedID);

        }
        //[SessionAuthorize]
        //[HttpPost]
        //public ActionResult AddMedia(Media acc)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        bool result = false;


        //        if (acc.id > 0)//đang update
        //        {

        //            result = accDao.Update(acc);
        //        }
        //        else//đang insert
        //        {

        //            result = accDao.Insert(acc);
        //        }

        //        if (result)
        //        {
        //            // SetAlert("Cập nhật sản phẩm thành công", "success");
        //            return RedirectToAction("Index", "Account");
        //        }
        //        else
        //        {
        //            ModelState.AddModelError("", "Có lỗi xảy ra. Thêm thất bại");
        //        }


        //    }

        //    return View();

        //}
    }
}