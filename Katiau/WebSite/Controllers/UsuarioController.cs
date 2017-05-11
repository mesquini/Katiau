using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Security;
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

                String Email = Request.Form["EmailU"];
                String Nick = Request.Form["NickU"];
                String Nome = Request.Form["NomeU"];
                String Sobrenome = Request.Form["SobrenomeU"];
                String Senha = Request.Form["SenhaU"];
                String Nascimento = Request.Form["NascimentoU"];
                String Imagem = Request.Form["ImagemU"];
                Boolean NivelAcesso = Boolean.Parse(Request.Form["NivelAcesso"]);

                Usuario NovoUser = new Usuario();

                NovoUser.Email = Email;
                NovoUser.Nick = Nick;
                NovoUser.Nome = Nome;
                NovoUser.Sobrenome = Sobrenome;
                NovoUser.Senha = FormsAuthentication.HashPasswordForStoringInConfigFile(Senha, "SHA1");
                NovoUser.Nick = Nick;
                NovoUser.Nascimento = Nascimento;
                NovoUser.ImagemPerfil = Imagem;
                NovoUser.Adm = NivelAcesso;

                if (NovoUser.Novo())
                {
                    ViewBag.Mensagem = "Usuário criado com sucesso!";
                }
                else
                {
                    ViewBag.Mensagem = "Houve um erro ao criar o Usuário. Verifique os dados e tente novamente.";
                }
            }

            List<Usuario> User = Usuario.ListarU();
            ViewBag.User = User;

            return View();
        }

        public ActionResult Cadastrar()
        {
            if (Request.HttpMethod == "POST")
            {
                String Email = Request.Form["EmailU"];
                String Nick = Request.Form["NickU"];
                String Nome = Request.Form["NomeU"];
                String Sobrenome = Request.Form["SobrenomeU"];
                String Senha = Request.Form["SenhaU"];
                String Nascimento = Request.Form["NascimentoU"];
                String Imagem = Request.Form["ImagemU"];

                Usuario NovoUser = new Usuario();

                NovoUser.Email = Email;
                NovoUser.Nick = Nick;
                NovoUser.Nome = Nome;
                NovoUser.Sobrenome = Sobrenome;
                NovoUser.Senha = FormsAuthentication.HashPasswordForStoringInConfigFile(Senha, "SHA1"); ;
                NovoUser.Nick = Nick;
                NovoUser.Nascimento = Nascimento;
                NovoUser.ImagemPerfil = Imagem;

                if (NovoUser.Novo())
                {
                    ViewBag.Mensagem = "Usuário criado com sucesso!";
                    Response.Redirect("~/Perfil/Index");
                }
                else
                {
                    ViewBag.Mensagem = "Falha ao cadastrar, verifique os campos e tente novamente.";
                }

            }
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
    
