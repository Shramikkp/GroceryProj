using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GroceryPR.Models;

namespace GroceryPR.Areas.Admin.Controllers
{
    public class UserTblsController : Controller
    {
        private GroceryDBEntities db = new GroceryDBEntities();

        // GET: Admin/UserTbls
        public ActionResult Index()
        {
            var userTbls = db.UserTbls.Include(u => u.CityTbl).Include(u => u.CountryTbl).Include(u => u.StateTbl);
            return View(userTbls.ToList());
        }
        
    }
}
