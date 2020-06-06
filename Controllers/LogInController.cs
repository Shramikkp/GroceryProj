using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using GroceryPR.Models;

namespace GroceryPR.Controllers
{
    public class LogInController : Controller
    {
        GroceryDBEntities entity = new GroceryDBEntities();
        // GET: LogIn
        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(AdminModel response)
        {
            if (ModelState.IsValid)
            {
                var admin = entity.AdminTbls.FirstOrDefault(model => model.UserName == response.UserName && model.Password == response.Password);
                if (admin != null && admin.IsActive)
                {
                    Session["Id"] = admin.Id;
                    Session["Name"] = string.Concat(admin.FirstName, " ", admin.LastName);
                    Session["UserName"] = admin.UserName;
                    FormsAuthentication.SetAuthCookie(admin.UserName, false);
                    return RedirectToAction("Index", "Home", new { area = "Admin" });
                }
                else {
                    ModelState.AddModelError(string.Empty, "Invalid user name and password.");
                }
            }
            return View();
        }

        
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("LogIn", "LogIn");
        }
    }
}