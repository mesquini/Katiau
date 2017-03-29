using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Website.Models;

namespace WebSite.Controllers
{
    public class Adm2Controller : Controller
    {
        public ActionResult Listar()
        {
            if (Session["User"] == null)
            {
                Response.Redirect("/Adm2/Index", false);
            }

            List<Usuario> User = Usuario.Listar();
            ViewBag.User = User;

            if (TempData["Mensagem"] != null)
            {
                ViewBag.Mensagem = TempData["Mensagem"].ToString();
            }

            return View();
        }
    }
}