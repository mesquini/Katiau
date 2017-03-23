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
            if (Session["ADM"] != null)
            {
                Response.Redirect("~/Adm2/Index");
            }

            if (Session["User"] != null)
            {
                Response.Redirect("~/Home/Index", false);
            }

            if (Request.HttpMethod == "POST")
            {
                String Email = Request.Form["email"].ToString();
                String Senha = Request.Form["senha"].ToString();
                String SenhaEncriptada = FormsAuthentication.HashPasswordForStoringInConfigFile(Senha, "SHA1");

                if(Email.Equals("admin@gmail.com") && Senha.Equals("Senai1234"))
                {
                    Usuario U = new Usuario(Email, SenhaEncriptada);
                    Session["ADM"] = U;
                    Response.Redirect("~/Adm2/Index", false);
                }
                if (Usuario.Autenticar(Email, SenhaEncriptada))
                {
                    Usuario U = new Usuario(Email, SenhaEncriptada);
                    Session["User"] = U;
                    Response.Redirect("~/Home/Index", false);
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