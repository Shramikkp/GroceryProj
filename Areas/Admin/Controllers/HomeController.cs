using GroceryPR.Areas.Admin.CustomFilter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GroceryPR.Areas.Admin.Controllers
{
    [LogInFilter]
    public class HomeController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {            
            return View();
        }
    }
}