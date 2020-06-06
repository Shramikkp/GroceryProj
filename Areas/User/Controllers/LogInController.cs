using GroceryPR.EncryptionAndDecryption;
using GroceryPR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GroceryPR.Areas.User.Controllers
{
    public class LogInController : ApiController
    {
        private GroceryDBEntities db = new GroceryDBEntities();
        [HttpPost]
        public HttpResponseMessage Login(UserTbl model)
        {
            if (ModelState.IsValid)
            {
                var encryptedPasswordString=EncryptDecryptPassword.EncryptPlainTextToCipherText(model.Password);
                var user = db.UserTbls.FirstOrDefault(item => item.UserName == model.UserName && item.Password == encryptedPasswordString);
                if (user != null)
                {
                    user.Token = Guid.NewGuid();
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, new
                    {
                        Token = user.Token,
                        Name = string.Concat(user.FirstName, " ", user.LastName)
                    });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid Username and password");
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);                
            }
        }
    }
}
