using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace GroceryPR.Areas.Admin.CustomFilter
{  
    public class LogInFilter : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.RequestContext.RouteData.Values["Id"] != null)
            {
                filterContext.HttpContext.Session["Id"] = filterContext.RequestContext.RouteData.Values["Id"];
            }

            if (filterContext.HttpContext.Session["Id"] == null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { Controller = "LogIn", Action = "LogIn", Area = "" }));
            }

        }
    }
}