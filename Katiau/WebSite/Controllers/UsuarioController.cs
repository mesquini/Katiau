using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Website.Models;
using WebSite.Models;

namespace WebSite.Controllers
{
    public class UsuarioController : Controller
    {
        public ActionResult Listar()
        {
            if (Session["User"] == null)
            {
                Response.Redirect("/Home/Index", false);
            }


            List<Usuario> User = Usuario.ListarU();
            ViewBag.User = User;

            List<Produto> Prod = Produto.ListarP();
            ViewBag.Prod = Prod;

            List<DLC> DLCs = DLC.ListarDLC(); 
            ViewBag.DLCs = DLCs;

            if (TempData["Mensagem"] != null)
            {
                ViewBag.Mensagem = TempData["Mensagem"].ToString();
            }

            return View();
        }
        public ActionResult Novo()
        {
            if (Session["User"] == null)
            {
                Response.Redirect("/Home/Index", false);
            }

            if (Request.HttpMethod == "POST")
            {
                Usuario U = (Usuario)Session["User"];

                Int32 IDUser = Convert.ToInt32(Request.Form["Usuario"]);
                Usuario Users = new Usuario(IDUser);

                String Email = Request.Form["Email"];
                String Nick = Request.Form["Nick"];
                String Nome = Request.Form["Nome"];
                String Sobrenome = Request.Form["Sobrenome"];
                String Senha = Request.Form["Senha"];
                String Nascimento = Request.Form["Nascimento"];
                String Bio = Request.Form["Bio"];
                String Imagem = Request.Form["ImagemPerfil"];

                Usuario NovoUser = new Usuario(Convert.ToInt32(IDUser));

                NovoUser.Email = Email;
                NovoUser.Nick = Nick;
                NovoUser.Nome = Nome;
                NovoUser.Sobrenome = Sobrenome;
                NovoUser.Senha = Senha;
                NovoUser.Nick = Nick;
                NovoUser.Nascimento = Nascimento;
                NovoUser.ImagemPerfil = Imagem;

                if (NovoUser.Novo())
                {
                    ViewBag.Mensagem = "Post criado com sucesso!";
                }
                else
                {
                    ViewBag.Mensagem = "Houve um erro ao criar o Post. Verifique os dados e tente novamente.";
                }
            }

            List<Usuario> User = Usuario.ListarU();
            ViewBag.User = User;

            return View();
        }

       
        public ActionResult Ver(String ID)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("/Home/Index", false);
            }

            Usuario U = new Usuario(Convert.ToInt32(ID));
            ViewBag.User = U;

            return View();
        }

        public ActionResult Apagar(String ID)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("/Home/Index", false);
            }

            Usuario U = new Usuario(Convert.ToInt32(ID));


            if (U.Apagar())
            {
                TempData["Mensagem"] = "Usuario removido com sucesso!";
            }
            else
            {
                TempData["Mensagem"] = "Não foi possível remover o Usuario. Verifique os dados e tente novamente";
            }

            return RedirectToAction("Listar");
        }
    }
    }
    
