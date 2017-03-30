using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebSite.Controllers
{
    public class CadastroController : Controller
    {
        // GET: Cadastro
        public ActionResult Salvar(String Email, String Senha)
        {

            return View();
        }
    }
}