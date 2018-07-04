using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TrieuTraiTimKara.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Home
        [SessionAuthorize]
        public ActionResult Index()
        {
            return View();
        }
    }
}