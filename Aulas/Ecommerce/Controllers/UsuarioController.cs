using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Ecommerce.DAL;
using Ecommerce.Models;
using Newtonsoft.Json;

namespace Ecommerce.Controllers
{
    public class UsuarioController : Controller
    {
        private Context db = new Context();
        
        public ActionResult Index()
        {
            return View(UsuarioDAO.RetornarUsuarios());
        }
        
        public ActionResult Create()
        {
            if(TempData["Mensagem"] != null)
            {
                ModelState.AddModelError("", TempData["Mensagem"].ToString());
            }
            return View((Usuario)TempData["Usuario"]);
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Erro()
        {
            return View();
        }

        public ActionResult Sucesso()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "UsuarioId,NomeUsuario,EnderecoUsuario,TelefoneUsuario,EmailUsuario,SenhaUsuario,ConfirmarSenha,cep,logradouro,bairro,localidade,uf")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                if(UsuarioDAO.CadastrarUsuario(usuario))
                {
                    return RedirectToAction("Index", "Usuario");
                }
                ModelState.AddModelError("", "Esse usuário já existe!");
                return View(usuario);
            }
            return View(usuario);
        }

        [HttpPost]
        public ActionResult Login([Bind(Include = "EmailUsuario,SenhaUsuario")]Usuario usuario)
        {
            usuario = UsuarioDAO.Login(usuario);

            if(usuario != null)
            {
                FormsAuthentication.SetAuthCookie(usuario.EmailUsuario, true);
                return RedirectToAction("Index", "Produto");
            }
            ModelState.AddModelError("", "E-mail ou senha inválidos!");
            return View(usuario);
        }

        public ActionResult Sair()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Usuario");
        }

        public ActionResult PesquisarCep(Usuario usuario)
        {
            try
            {
                string url = "https://viacep.com.br/ws/" + usuario.cep + "/json/";

                WebClient client = new WebClient();
                string json = client.DownloadString(url);

                byte[] bytes = Encoding.Default.GetBytes(json);

                json = Encoding.UTF8.GetString(bytes);

                usuario = JsonConvert.DeserializeObject<Usuario>(json);

                TempData["Usuario"] = usuario;
            }
            catch (Exception)
            {

                TempData["Mensagem"] = "CEP inválido!";
            }

            return RedirectToAction("Create", "Usuario");
        }

    }
}
