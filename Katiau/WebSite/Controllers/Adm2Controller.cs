using System.Collections.Generic;
using System.Web.Mvc;
using Website.Models;

namespace WebSite.Controllers
{
    public class Adm2Controller : Controller
    {


       public ActionResult Listar()
        {
            if (Session["User"] == null)
            {
                Response.Redirect("/Home/Listar", false);
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