using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Website.Models;
using WebSite.Models;

namespace WebSite.Controllers
{
    public class DLCsController : Controller
    {
        // GET: DLCs
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

                Int32 ID = Convert.ToInt32(Request.Form["DLC"]);
                DLC C = new DLC(ID);
            
                String Nome = Request.Form["NomeProduto"];
                String Categoria = Request.Form["NomeCategoria"];
                String Imagem = Request.Form["ImagemProduto"];
                String Descricao = Request.Form["DescricaoProduto"];
                Double Preco = Double.Parse(Request.Form["PrecoProduto"]);

                DLC NovoDLC = new DLC(Convert.ToInt32(ID));
                NovoDLC.Nome = Nome;
                NovoDLC.Categoria = Categoria;
                NovoDLC.Imagem = Imagem;
                NovoDLC.Descricao = Descricao;
                NovoDLC.Preco = Preco;

                if (NovoDLC.Novo())
                {
                    ViewBag.Mensagem = "Nova DLC criado com sucesso!";
                }
                else
                {
                    ViewBag.Mensagem = "Houve um erro ao criar uma Nova DLC. Verifique os dados e tente novamente.";
                }
            }

            List<DLC> DLCs = DLC.ListarDLC();
            ViewBag.DLCs = DLCs;

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
                Int32 IDCategoria = Convert.ToInt32(Request.Form["Produto.CategoriaID"]);
                Categoria C = new Categoria(IDCategoria);

                String Nome = Request.Form["NomeProduto"];
                String Categoria = Request.Form["NomeCategoria"];
                String Imagem = Request.Form["ImagemProduto"];
                String Descricao = Request.Form["DescricaoProduto"];
                Double Preco = Double.Parse( Request.Form["PrecoProduto"]);

                DLC NovoDLC = new DLC(Convert.ToInt32(ID));
                NovoDLC.Nome = Nome;
                NovoDLC.Categoria = Categoria;
                NovoDLC.Imagem = Imagem;
                NovoDLC.Descricao = Descricao;
                NovoDLC.Preco = Preco;
                    

                if (NovoDLC.Alterar())
                {
                    ViewBag.Mensagem = "DLC alterado com sucesso!";
                }
                else
                {
                    ViewBag.Mensagem = "Houve um erro ao criar o DLC. Verifique os dados e tente novamente.";
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

            DLC dlc = new DLC(Convert.ToInt32(ID));


            if (dlc.Apagar())
            {
                TempData["Mensagem"] = "DLC removido com sucesso!";
            }
            else
            {
                TempData["Mensagem"] = "Não foi possível remover o DLC. Verifique os dados e tente novamente";
            }

            return RedirectToAction("Listar");
        }
    }
}
