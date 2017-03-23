using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebSite.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            if (Session["ADM"] != null)
            {
                Response.Redirect(~/)
            }

            if (Session["User"] != null)
            {
                Response.Redirect("~/Home/Index", false);
            }

            if (Request.HttpMethod == "POST")
            {
                String Email = Request.Form["Email"].ToString();
                String Senha = Request.Form["Senha"].ToString();
                String SenhaEncriptada = FormsAuthentication.HashPasswordForStoringInConfigFile(Senha, "SHA1");

                if (Usuario.Autenticar(Email, SenhaEncriptada))
                {
                    Usuario U = new Usuario(Email, SenhaEncriptada);
                    Session["Usuario"] = U;
                    Response.Redirect("~/Post/Listar", false);
                }
                else
                {
                    ViewBag.Mensagem = "Usuário e/ou senha inválido(s)";
                }
            }

            return View();
        }
    }
}