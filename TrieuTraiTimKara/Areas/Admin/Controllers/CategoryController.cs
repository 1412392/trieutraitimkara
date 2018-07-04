using Models.DAO;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TrieuTraiTimKara.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Admin/Category
        CategoryDao cateDao = new CategoryDao();

        [SessionAuthorize]
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var lstCate = cateDao.GetAllCategory(page, pageSize);
            if (lstCate == null)
            {
                lstCate = new List<Category>();
            }
            return View(lstCate);
        }

        [SessionAuthorize]
        public ActionResult AddCategory(int id = 0)
        {
            Category cate = new Category();
            cate = cateDao.GetCategoryByID(id);
            if (cate == null)
            {
                cate = new Category();
            }

            return View(cate);
        }


        //thêm/cập nhật category
        [SessionAuthorize]
        [HttpPost]
        public ActionResult AddCategory(Category cate)
        {
            if (ModelState.IsValid)
            {
                bool result = false;
                if (cate.id > 0)
                {
                    result = cateDao.Update(cate);
                }
                else
                {
                    result = cateDao.Insert(cate);
                }

                if (result)
                {
                    // SetAlert("Cập nhật sản phẩm thành công", "success");
                    return RedirectToAction("Index", "Category");
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

            bool resultDelete = cateDao.Delete(id);

            return Json(
                    new
                    {
                        status = resultDelete,
                    });


        }
    }

}
