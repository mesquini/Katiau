using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Website.Models;

namespace WebSite.Controllers
{
    public class PostsController : Controller
    {
        // GET: Posts
        public ActionResult Padrao()
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
                        ViewBag.MsgErro = "Usuário e/ou Senha incorretos!";
                        break;

                }
            }

            if (Session["User"] != null)
            {
                ViewBag.Logado = Session["User"];
                Usuario User = (Usuario)Session["User"];
                ViewBag.ImagemU = User.ImagemPerfil;
                ViewBag.NickU = User.Nick;
                ViewBag.NomeU = User.Nome;
                ViewBag.SobrenomeU = User.Sobrenome;
                if (User.Adm)
                {
                    ViewBag.NivelAcesso = User.Adm;
                }
            }
            return View();
        }

        public ActionResult Noticias()
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
                        ViewBag.MsgErro = "Usuário e/ou Senha incorretos!";
                        break;

                }
            }

            if (Session["User"] != null)
            {
                ViewBag.Logado = Session["User"];
                Usuario User = (Usuario)Session["User"];
                ViewBag.ImagemU = User.ImagemPerfil;
                ViewBag.NickU = User.Nick;
                ViewBag.NomeU = User.Nome;
                ViewBag.SobrenomeU = User.Sobrenome;
                if (User.Adm)
                {
                    ViewBag.NivelAcesso = User.Adm;
                }
            }
            return View();
        }

        public ActionResult NovoPost()
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
                        ViewBag.MsgErro = "Usuário e/ou Senha incorretos!";
                        break;

                }
            }

            if (Session["User"] != null)
            {
                ViewBag.Logado = Session["User"];
                Usuario User = (Usuario)Session["User"];
                ViewBag.ImagemU = User.ImagemPerfil;
                ViewBag.NickU = User.Nick;
                ViewBag.NomeU = User.Nome;
                ViewBag.SobrenomeU = User.Sobrenome;
                if (User.Adm)
                {
                    ViewBag.NivelAcesso = User.Adm;
                }
            }
            return View();
        }

        public ActionResult Posts()
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
                        ViewBag.MsgErro = "Usuário e/ou Senha incorretos!";
                        break;

                }
            }

            if (Session["User"] != null)
            {
                ViewBag.Logado = Session["User"];
                Usuario User = (Usuario)Session["User"];
                ViewBag.ImagemU = User.ImagemPerfil;
                ViewBag.NickU = User.Nick;
                ViewBag.NomeU = User.Nome;
                ViewBag.SobrenomeU = User.Sobrenome;
                if (User.Adm)
                {
                    ViewBag.NivelAcesso = User.Adm;
                }
            }
            return View();
        }
    }
}