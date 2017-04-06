using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Website.Models;
using WebSite.Models;

namespace WebSite.Controllers
{
    public class Adm2Controller : Controller
    {


       public ActionResult Listar()
        {
            if (Session["User"] == null)
            {
                Response.Redirect("/Home/Index", false);
            }

            List<Usuario> User = Usuario.ListarU();
            ViewBag.User = User;

            List<Pacote> Prod = Pacote.ListarP();
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

                Int32 IDCategoria = Convert.ToInt32(Request.Form["Categoria"]);
                Categoria C = new Categoria(IDCategoria);

                String Titulo = Request.Form["Titulo"];
                String Texto = Request.Form["Texto"];

                Post NovoPost = new Post();
                NovoPost.Usuario = U;
                NovoPost.Categoria = C;
                NovoPost.Titulo = Titulo;
                NovoPost.Texto = Texto;

                if (NovoPost.Salvar())
                {
                    ViewBag.Mensagem = "Post criado com sucesso!";
                }
                else
                {
                    ViewBag.Mensagem = "Houve um erro ao criar o Post. Verifique os dados e tente novamente.";
                }
            }

            List<Categoria> Categorias = Categoria.Lista();
            ViewBag.Categorias = Categorias;

            return View();
        }

        public ActionResult Alterar(String ID)

        {
            if (Session["User"] == null)
            {
                Response.Redirect("/Home/Index", false);
            }

            if (Request.HttpMethod == "POST")
            {
                Int32 IDCategoria = Convert.ToInt32(Request.Form["Categoria"]);
                Categoria C = new Categoria(IDCategoria);

                String Titulo = Request.Form["Titulo"];
                String Texto = Request.Form["Texto"];

                Post NovoPost = new Post(Convert.ToInt32(ID));
                NovoPost.Categoria = C;
                NovoPost.Titulo = Titulo;
                NovoPost.Texto = Texto;

                if (NovoPost.Alterar())
                {
                    ViewBag.Mensagem = "Post alterado com sucesso!";
                }
                else
                {
                    ViewBag.Mensagem = "Houve um erro ao criar o Post. Verifique os dados e tente novamente.";
                }
            }

            List<Categoria> Categorias = Categoria.Lista();
            ViewBag.Categorias = Categorias;

            Categoria P = new Categoria(Convert.ToInt32(ID));
            ViewBag.Post = P;

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

            Pacote P = new Pacote(Convert.ToString(ID));
            ViewBag.Prod = P;

            DLC DLCs = new DLC(Convert.ToInt32(ID));
            ViewBag.DLCs = DLCs;

            return View();
        }

        public ActionResult Apagar(String ID)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("/Home/Index", false);
            }

            Categoria P = new Categoria(Convert.ToInt32(ID));

            if (P.Remover())
            {
                TempData["Mensagem"] = "Post removido com sucesso!";
            }
            else
            {
                TempData["Mensagem"] = "Não foi possível remover o Post. Verifique os dados e tente novamente";
            }

            return RedirectToAction("Listar");
        }
    }
}