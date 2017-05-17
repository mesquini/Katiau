﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security;
using Website.Models;

namespace WebSite.Controllers
{
    public class PerfilController : Controller
    {
        // GET: Perfil
        public ActionResult Index()
        {
            if (Session["User"] != null)
            {
                Usuario us = (Usuario)Session["User"];
                ViewBag.SobrenomeU = us.Sobrenome;
                ViewBag.NomeU = us.Nome;
                ViewBag.NickU = us.Nick;
                ViewBag.EmailU = us.Email;
                ViewBag.BioU = us.Bio;
                ViewBag.ImagemU = us.ImagemPerfil;

                 return View();
            }
            Response.Redirect("/Home/Index", false);
            return View();
        }
        public ActionResult Edita_Perfil()
        {
            if (Session["User"] != null)
            {
                Usuario us = (Usuario)Session["User"];
                ViewBag.SobrenomeU = us.Sobrenome;
                ViewBag.NomeU = us.Nome;
                ViewBag.NickU = us.Nick;
                ViewBag.EmailU = us.Email;
                ViewBag.BioU = us.Bio;
                ViewBag.ImagemU = us.ImagemPerfil;



                if (Request.HttpMethod == "POST")
                {
                    Usuario U = (Usuario)Session["User"];
                    

                    String Bio = Request.Form["BioU"];
                    String Nick = Request.Form["NickU"];
                    
                    Usuario NovoPerfil = new Usuario();

                    NovoPerfil = (Usuario)Session["User"];
                    NovoPerfil.Bio = Bio;
                    NovoPerfil.Nick = Nick;

                    
                    if (NovoPerfil.NovaBio())
                    {
                        ViewBag.Mensagem = "Perfil alterado com sucesso!";
                        ViewBag.BioU = Bio;
                        Response.Redirect("/Perfil/Index", false);
                       }
                    else
                    {
                        ViewBag.Mensagem = "Houve um erro ao alterar o Perfil. Verifique os dados e tente novamente.";
                    }
                }
                return View();
            }
            Response.Redirect("/Home/Index", false);
            return View();
        }

    }
}
