using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VetManager.Models;

namespace VetManager.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NewUser()
        {
            return View();
        }

        [HttpPost]
        public JsonResult NewUser(Users user)
        {
            //VetManagerEntities vetManagerDB = new VetManagerEntities();
            var vetManagerDB = new Models.VetManagerEntities();

            var NewUser = new Models.Users()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Senha    = user.Senha,
                BirthDate = user.BirthDate,
                Email = user.Email
            };

            vetManagerDB.Users.Add(NewUser);

            try
            {
                vetManagerDB.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var entityValidationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in entityValidationErrors.ValidationErrors)
                    {
                        Response.Write("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                    }
                }
            }

            

            return Json(NewUser);
        }

        [HttpPost]
        public JsonResult GetDados(Logon user)
        {
            VetManagerEntities vetManagerDB = new VetManagerEntities();
            Users usuarios = vetManagerDB.Users.SingleOrDefault(x => x.UserName == user.UserName);

            var resultado = new
            {
                FirstName = usuarios.FirstName,
                LastName = usuarios.LastName,
                UserName = usuarios.UserName,
                BirthDate = usuarios.BirthDate.ToShortDateString(),
                Email = usuarios.Email
            };
            return Json(resultado);
        }
    }
}