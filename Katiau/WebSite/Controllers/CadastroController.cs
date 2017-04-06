using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website.Models;

namespace WebSite.Controllers
{
    public class CadastroController : Controller
    {
        // GET: Cadastro
        public ActionResult Salvar(String Email, String Senha)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("/Cadastro/Index", false);
            }
            if(Session["ADM"] == null)
            {
                Response.Redirect("/Cadastro/Index", false);
            }

            if (Request.HttpMethod == "POST")
            {
                Usuario U = (Usuario)Session["User"];

                String mail = Request.Form["email"];
                String senha = Request.Form["senha"];
                String nome = Request.Form["nome"];

                Post NovoPost = new Post();
                NovoPost.Usuario = U;
               // NovoPost.Categoria = C;
               // NovoPost.Titulo = Titulo;
               // NovoPost.Texto = Texto;

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
    }
}