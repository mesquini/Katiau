﻿using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Security;
using Website.Models;
using WebSite.Models;

namespace WebSite.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
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
                        Response.Redirect("/Cadastro/Index", false);

                        break;

                    default:

                        break;

                }
            }
            List<Usuario> User = Usuario.ListarU();
            ViewBag.User = User;

            List<Pacote> Prod = Pacote.ListarP();
            ViewBag.Prod = Prod;

            List<DLC> DLCs = DLC.ListarDLC();
            ViewBag.DLCs = DLCs;

            return View();
        }
        
            

        public ActionResult Sair()
        {
            Session.Abandon();
            Session.Clear();

            return RedirectToAction("Autenticar");
        }

        
    }
}