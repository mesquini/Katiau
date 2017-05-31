using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website.Models;
using WebSite.Models;

namespace WebSite.Controllers
{
    public class StoreController : Controller
    {
        // GET: Store
        public ActionResult Index()
        {
            return View();
        }


        // GET: DLCs
        public ActionResult TuViewIsso()
        {
            if (Session["User"] != null)
            {
                ViewBag.Logado = Session["User"];
                Usuario Users = (Usuario)Session["User"];
                if (!Users.Adm)
                {
                    Response.Redirect("/Home/Index", false);
                }

                List<DLC> DLCs = DLC.ListarDLC();
                ViewBag.DLCs = DLCs;


                if (TempData["Mensagem"] != null)
                {
                    ViewBag.Mensagem = TempData["Mensagem"].ToString();
                }
            }
            return View();
        }
    }
}