using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Website.Models;

namespace WebSite.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            if (Session["User"] != null)
            {
                Response.Redirect("/Adm2/Listar", false);
            }

            if (Request.HttpMethod == "POST")
            {
                String Email = Request.Form["email"].ToString();
                String Senha = Request.Form["senha"].ToString();
                String SenhaEncriptada = FormsAuthentication.HashPasswordForStoringInConfigFile(Senha, "SHA1");

                switch (Usuario.Autenticar(Email,SenhaEncriptada))
                {
                    case "Administrador":

                        Usuario ADM = new Usuario(Email, SenhaEncriptada);
                        Session["User"] = ADM;
                        Response.Redirect("/Adm2/Listar", false);

                        break;

                    case "Usuário":

                        Usuario U = new Usuario(Email, SenhaEncriptada);
                        Session["User"] = U;
                        Response.Redirect("/Cadastro/Index", false);

                        break;

                    default:

                        break;

                }
            }

            return View();
        }
        public ActionResult Listar()
        {
            List<Usuario> user = Usuario.Listar();
            ViewBag.User = User;

            return View();
        }
    }
}