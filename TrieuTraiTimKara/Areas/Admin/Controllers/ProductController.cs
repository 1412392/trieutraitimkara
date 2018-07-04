using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.DAO;
using Model.EF;
using System.Globalization;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        // GET: Admin/Product (list san pham)
        public ActionResult Index(int page = 1, int pageSize = 10)
        {

            var ProductDao = new ProductDao();
            var model = ProductDao.getAllProduct(page, pageSize);
            return View(model);
        }
        //Get: Admin/product/addproduct (đưa tới giao diện add)
        [HttpGet]
        public ActionResult AddProduct()
        {

            setViewBag();

            return View("AddProduct");
        }

        //Post: Admin/Product/AddProduct
        [HttpPost]
        public ActionResult AddProduct(Product product)//tham số truyền vào dựa vào bên View (@model...)
        {
            if (ModelState.IsValid)
            {
                ProductDao pro = new ProductDao();
                product.MetaTitle = GetMetaTitle(product.Name);

                long id = pro.Insert(product);
                if (id > 0)
                {


                    SetAlert("Thêm sản phẩm thành công", "success");
                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    ModelState.AddModelError("", "Có lỗi xảy ra. Thêm thất bại");
                }
            }

            setViewBag();
            return View("AddProduct");

        }

        [HttpGet]
        //get: admin/product/editproduct/id
        public ActionResult EditProduct(int id)
        {

            var productmodel = new ProductDao();

            var productold = productmodel.getByID(id);

            //set list category cho dropdown
            setViewBag();

            return View(productold);//truyền model tới view đó

        }

        [HttpPost]
        public ActionResult EditProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                ProductDao pro = new ProductDao();

                bool statusUpdate = pro.Update(product);
                if (statusUpdate)
                {
                    SetAlert("Cập nhật sản phẩm thành công", "success");
                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    ModelState.AddModelError("", "Có lỗi xảy ra. Cập nhật thất bại");
                }
            }
            setViewBag();
            return View("Index");
        }

        [HttpPost]
        public JsonResult DeleteProduct(int id)
        {
            var productModel = new ProductDao();
            bool resultDelete = productModel.Delete(id);

            return Json(
                    new
                    {
                        status = resultDelete,
                    });


        }

        public void setViewBag(long? selectedID = null)
        {
            var categorydao = new CategoryDao();
            //Viewbag để bingding dữ liệu từ model sang views
            //Chọn thằng nào có CategoryID
            ViewBag.CategoryID = new SelectList(categorydao.GetAllCategory(), "ID", "Name", selectedID);

        }

        public  string GetMetaTitle(string inputText)
        {
            string stFormD = inputText.Normalize(System.Text.NormalizationForm.FormD);
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            string str = "";
            for (int i = 0; i <= stFormD.Length - 1; i++)
            {
                UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(stFormD[i]);
                if (uc == UnicodeCategory.NonSpacingMark == false)
                {
                    if (stFormD[i] == 'đ')
                        str = "d";
                    else if (stFormD[i] == 'Đ')
                        str = "D";
                    else if (stFormD[i] == '\r' | stFormD[i] == '\n')
                        str = "";
                    else if (stFormD[i] == ' ')
                        str = "-";
                    else
                        str = stFormD[i].ToString();

                    sb.Append(str);
                }

            }
            return sb.ToString();
        }
    }
}