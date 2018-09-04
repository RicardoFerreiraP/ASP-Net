using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Ecommerce.DAL;
using Ecommerce.Models;

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
            return View();
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
        public ActionResult Create([Bind(Include = "UsuarioId,NomeUsuario,EnderecoUsuario,TelefoneUsuario,EmailUsuario,SenhaUsuario,ConfirmarSenha")] Usuario usuario)
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

    }
}
