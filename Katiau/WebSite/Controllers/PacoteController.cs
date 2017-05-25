using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Website.Models;
using WebSite.Models;

namespace WebSite.Controllers
{
    public class PacoteController : Controller
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

                //Int32 IDProduto = Convert.ToInt32(Request.Form["Produto"]);
                //Produto Prods = new Produto(IDProduto);

                String Nome = Request.Form["NomeProduto"];
                Int32 CategoriaID = Int32.Parse ("3");
                Int32 Versao = Int32.Parse("1");
                String Imagem = Request.Form["ImagemProduto"];
                String Descricao = Request.Form["DescricaoProduto"];
                Double Preco = Double.Parse(Request.Form["PrecoProduto"]);

                Produto NovoProduto = new Produto();

                NovoProduto.Nome = Nome;
                NovoProduto.CategoriaID = CategoriaID;
                NovoProduto.Versao = Versao;
                NovoProduto.Imagem = Imagem;
                NovoProduto.Descricao = Descricao;
                NovoProduto.Preco = Preco;

                if (NovoProduto.NovoProd())
                {
                    ViewBag.Mensagem = "Pacote criada com sucesso!";
                }
                else
                {
                    ViewBag.Mensagem = "Houve um erro ao criar um pacote. Verifique os dados e tente novamente.";
                }
            }

            List<Produto> Produtos = Produto.ListarP();
            ViewBag.Produtos = Produtos;

            return View();
        }


        public ActionResult Ver(String ID)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("/Home/Index", false);
            }

            Produto Prod = new Produto(Convert.ToInt32(ID));
            ViewBag.Prod = Prod;

            return View();
        }

        public ActionResult Apagar(String ID)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("/Home/Index", false);
            }

            Produto Prod = new Produto(Convert.ToInt32(ID));


            if (Prod.Apagar())
            {
                TempData["Mensagem"] = "Usuario removido com sucesso!";
            }
            else
            {
                TempData["Mensagem"] = "Não foi possível remover o Usuario. Verifique os dados e tente novamente";
            }

            return RedirectToAction("Listar");
        }
        public ActionResult Alterar(String ID)

        {
            if (Session["User"] == null)
            {
                Response.Redirect("/Home/Index", false);
            }

            if (Request.HttpMethod == "POST")
            {
                String Nome = Request.Form["NomeProduto"];
                Int32 CategoriaID = Int32.Parse("2");
                Int32 Versao = Int32.Parse("1");
                String Imagem = Request.Form["ImagemProduto"];
                String Descricao = Request.Form["DescricaoProduto"];
                Double Preco = Double.Parse(Request.Form["PrecoProduto"]);

                Produto NovoProduto = new Produto();

                NovoProduto.Nome = Nome;
                NovoProduto.CategoriaID = CategoriaID;
                NovoProduto.Versao = Versao;
                NovoProduto.Imagem = Imagem;
                NovoProduto.Descricao = Descricao;
                NovoProduto.Preco = Preco;


                if (NovoProduto.AlterarProd())
                {
                    ViewBag.Mensagem = "Pacote alterado com sucesso!";
                }
                else
                {
                    ViewBag.Mensagem = "Houve um erro ao criar o Pacote. Verifique os dados e tente novamente.";
                }
            }



            return View();
        }
    }
}

