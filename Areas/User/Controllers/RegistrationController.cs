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
    public class RegistrationController : ApiController
    {
        private GroceryDBEntities db = new GroceryDBEntities();
        [HttpPost]
        public HttpResponseMessage Registration(UserModel model)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }
            else
            {
                var encryptedPassword=EncryptDecryptPassword.EncryptPlainTextToCipherText(model.Password);

                db.UserTbls.Add(new UserTbl() {
                    CityId = model.CityId,
                    FirstName= model.FirstName,
                    LastName= model.LastName,
                    Email= model.Email,
                    MobileNumber= model.MobileNumber,
                    FlatNumber= model.FlatNumber,
                    CountryId=model.CountryId,
                    StateId= model.StateId,
                    SocityName= model.SocityName,
                    DateModified= DateTime.Now,
                    DateAdded=DateTime.Now,
                    WhatsAppNumber=model.WhatsAppNumber,
                    WingName=model.WingName,
                    Landmark=model.Landmark,
                    Password= encryptedPassword,
                    UserName= model.UserName,
                    Token= model.Token
                });
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK);
            }
        }
    }
}
