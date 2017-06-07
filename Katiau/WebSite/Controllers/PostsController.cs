using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Website.Models;
using WebSite.Models;

namespace WebSite.Controllers
{
    public class PostsController : Controller
    {
        // GET: Posts
        public ActionResult Padrao()
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
                        Response.Redirect("/Perfil/Index", false);

                        break;

                    default:
                        ViewBag.MsgErro = "Usuário e/ou Senha incorretos!";
                        break;

                }
            }

            if (Session["User"] != null)
            {
                ViewBag.Logado = Session["User"];
                Usuario User = (Usuario)Session["User"];
                ViewBag.ImagemU = User.ImagemPerfil;
                ViewBag.NickU = User.Nick;
                ViewBag.NomeU = User.Nome;
                ViewBag.SobrenomeU = User.Sobrenome;
                if (User.Adm)
                {
                    ViewBag.NivelAcesso = User.Adm;
                }
            }
            return View();
        }

        public ActionResult Noticias()
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
                        Response.Redirect("/Perfil/Index", false);

                        break;

                    default:
                        ViewBag.MsgErro = "Usuário e/ou Senha incorretos!";
                        break;

                }
            }

            if (Session["User"] != null)
            {
                ViewBag.Logado = Session["User"];
                Usuario User = (Usuario)Session["User"];
                ViewBag.ImagemU = User.ImagemPerfil;
                ViewBag.NickU = User.Nick;
                ViewBag.NomeU = User.Nome;
                ViewBag.SobrenomeU = User.Sobrenome;
                if (User.Adm)
                {
                    ViewBag.NivelAcesso = User.Adm;
                }
            }
            return View();
        }

        public ActionResult NovoPost()
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
                        Response.Redirect("/Perfil/Index", false);

                        break;

                    default:
                        ViewBag.MsgErro = "Usuário e/ou Senha incorretos!";
                        break;

                }
            }

            if (Session["User"] != null)
            {
                ViewBag.Logado = Session["User"];
                Usuario User = (Usuario)Session["User"];
                ViewBag.ImagemU = User.ImagemPerfil;
                ViewBag.NickU = User.Nick;
                ViewBag.NomeU = User.Nome;
                ViewBag.SobrenomeU = User.Sobrenome;
                if (User.Adm)
                {
                    ViewBag.NivelAcesso = User.Adm;
                }
            }
            return View();
        }

        public Boolean CriarPost()
        {
            if (Session["User"] == null)
            {
                Response.Redirect("~/Posts/Posts");
            }
            Boolean Resultado = false;

            if (Request.HttpMethod == "POST")
            {
                Usuario user = (Usuario)Session["User"];
                Post novo = new Post();

                novo.Texto = Request.Form["Texto"].ToString();
                novo.Titulo = Request.Form["Titulo"].ToString();
                novo.Autor = user.ID;

                if (novo.Salvar(user.ID))
                {
                    Post post = new Post(user.ID);

                    foreach (string fileName in Request.Files)
                    {
                        HttpPostedFileBase postedFile = Request.Files[fileName];
                        int contentLength = postedFile.ContentLength;
                        string contentType = postedFile.ContentType;
                        string nome = postedFile.FileName;

                        if (contentType.IndexOf("jpeg") > 0)
                        {
                            postedFile.SaveAs(HttpRuntime.AppDomainAppPath + "\\images\\img_posts\\" + "imagemPost" + post.ID + ".jpg");
                           // postedFile.SaveAs(@"C:\Users\16128604\Source\Repos\lpw-2017-3infb-g4\Katiau\WebSite\images\img_posts\" + "imagemPost" + post.ID + ".jpg");
                        }
                    }
                    post.Imagem = "imagemPost" + post.ID + ".jpg";

                   if (post.Alterar(post.ID))
                    {
                        Resultado = true;
                        Response.Redirect("/Posts/Posts");
                    }
                }
                
               return Resultado;
            }
            return Resultado;
        }

        public ActionResult Posts()
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
                        Response.Redirect("/Perfil/Index", false);

                        break;

                    default:
                        ViewBag.MsgErro = "Usuário e/ou Senha incorretos!";
                        break;

                }
            }

            if (Session["User"] != null)
            {
                ViewBag.Logado = Session["User"];
                Usuario User = (Usuario)Session["User"];
                ViewBag.ImagemU = User.ImagemPerfil;
                ViewBag.NickU = User.Nick;
                ViewBag.NomeU = User.Nome;
                ViewBag.SobrenomeU = User.Sobrenome;
                if (User.Adm)
                {
                    ViewBag.NivelAcesso = User.Adm;
                }
                               
            }
            List<Post> Posts = Post.Listar();
            ViewBag.Posts = Posts;
            return View();
        }
        public ActionResult Listar()
        {
            if (Session["User"] != null)
            {
                ViewBag.Logado = Session["User"];
                Usuario Users = (Usuario)Session["User"];
                if (!Users.Adm)
                {
                    Response.Redirect("/Menu/Home", false);
                }

                List<Usuario> User = Usuario.ListarU();
                ViewBag.User = User;

                List<Produto> Prod = Produto.ListarP();
                ViewBag.Prod = Prod;

                List<DLC> DLCs = DLC.ListarDLC();
                ViewBag.DLCs = DLCs;

                List<Post> Posts = Post.Listar();
                ViewBag.Posts = Posts;


                if (TempData["Mensagem"] != null)
                {
                    ViewBag.Mensagem = TempData["Mensagem"].ToString();
                }
            }
            return View();
        }
        public ActionResult Apagar(String ID)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("/Menu/Home", false);
            }

            Post P = new Post(Convert.ToInt32(ID));


            if (P.Apagar())
            {
                TempData["Mensagem"] = "Post removido com sucesso!";
            }
            else
            {
                TempData["Mensagem"] = "Não foi possível remover o Post. Verifique os dados e tente novamente";
            }

            return RedirectToAction("Listar","Posts");
        }
    }
}