using System;
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
                ViewBag.Logado = Session["User"];
                Usuario us = (Usuario)Session["User"];
                ViewBag.SobrenomeU = us.Sobrenome;
                ViewBag.NomeU = us.Nome;
                ViewBag.NickU = us.Nick;
                ViewBag.EmailU = us.Email;
                ViewBag.BioU = us.Bio;
                ViewBag.ImagemU = us.ImagemPerfil;

                return View();
            }

            Response.Redirect("~/Menu/Home", false);
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
                    int ID = NovoPerfil.ID;

                    foreach (string fileName in Request.Files)
                    {
                        HttpPostedFileBase postedFile = Request.Files[fileName];
                        int contentLength = postedFile.ContentLength;
                        string contentType = postedFile.ContentType;
                        string nome = postedFile.FileName;

                        if (contentType.IndexOf("jpeg") > 0)
                        {
                            postedFile.SaveAs(HttpRuntime.AppDomainAppPath + "\\images\\img_users\\" + "imagemPerfil" + ID + ".jpg");
                            //postedFile.SaveAs(@"C:\Users\16128604\Source\Repos\lpw-2017-3infb-g4\Katiau\WebSite\images\img_users\" + "imagemPerfil" + ID + ".jpg");
                        }
                       // else
                          //  postedFile.SaveAs(@"C:\Users\16128604\Source\Repos\lpw-2017-3infb-g4\Katiau\WebSite\images\" + Request.Form["Desc"] + ".txt");

                    }

                    NovoPerfil.ImagemPerfil = "imagemPerfil" + ID +".jpg";

                    if (NovoPerfil.NovaBio())
                    {
                        ViewBag.Mensagem = "Perfil alterado com sucesso!";
                        ViewBag.BioU = Bio;
                        ViewBag.ImagemU = NovoPerfil.ImagemPerfil;
                        Response.Redirect("~/Perfil/Index", false);
                       }
                    else
                    {
                        ViewBag.Mensagem = "Houve um erro ao alterar o Perfil. Verifique os dados e tente novamente.";
                    }
                }
                return View();
            }
            Response.Redirect("~/Menu/Home", false);
            return View();
        }

    }
}
