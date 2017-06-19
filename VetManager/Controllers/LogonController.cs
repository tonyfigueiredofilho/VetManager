using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VetManager.Models;

namespace VetManager.Controllers
{
    public class LogonController : Controller
    {
        // GET: Logon
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Entrar(Logon model)
        {
            VetManagerEntities vetManagerDB = new VetManagerEntities();
            Users usuarios = vetManagerDB.Users.SingleOrDefault(x => x.UserName == model.UserName && x.Senha == model.Senha);

            //Primeira validação
            if (model == null || string.IsNullOrEmpty(model.UserName) || string.IsNullOrEmpty(model.Senha))
            {
                Response.StatusCode = 400;
                Response.Write("Necessário informar nome do usuário e senha");
                return null;
            }

            //Segunda validação
            if (usuarios == null)
            {
                Response.StatusCode = 401;
                Response.Write("Login ou Senha inválidos.");
                return null;
            }

            //Retorno para o HTML
            return Json(usuarios);
        }

    }
}