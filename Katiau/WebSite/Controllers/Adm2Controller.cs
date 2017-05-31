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
            if (Session["User"] != null)
            {
                ViewBag.Logado = Session["User"];
                Usuario Users = (Usuario)Session["User"];
                if (!Users.Adm)
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

            Produto P = new Produto(Convert.ToInt32(ID));
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


            if (P.Apagar())
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