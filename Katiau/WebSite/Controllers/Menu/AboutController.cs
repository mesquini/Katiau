using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Website.Models;

namespace WebSite.Views
{
    public class AboutController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            if (Request.HttpMethod == "POST")
            {
                String Email = Request.Form["email"].ToString();
                String Senha = Request.Form["senha"].ToString();
                String SenhaEncriptada = FormsAuthentication.HashPasswordForStoringInConfigFile(Senha, "SHA1");

                switch (Usuario.Autenticar(Email, SenhaEncriptada))
                {
                    case "Administrador":

                        Usuario ADM = new Usuario(Email, SenhaEncriptada);
                        Session["User"] = ADM;
                        Response.Redirect("/Adm2/Listar", false);

                        break;

                    case "Usuario":

                        Usuario U = new Usuario(Email, SenhaEncriptada);
                        Session["User"] = U;
                        Response.Redirect("/Perfil/Index", false);

                        break;

                    default:

                        break;

                }
            }

            if (Session["User"] != null)
            {
                ViewBag.Logado = Session["User"];
            }

            return View();
        }
        public void Sair()
        {
            Session.Abandon();
            Session.Clear();

            Response.Redirect("/Home/Index", false);
        }
    }
}