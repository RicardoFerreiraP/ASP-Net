using Ecommerce.DAL;
using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ecommerce.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult CadastrarUsuario()
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
        public ActionResult Login(Usuario usuario)
        {
            var user = UsuarioDAO.Login(usuario);

            if(user != null)
            {
                Session["Usuario"] = user;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Erro", "Usuario");
            }
        }

        [HttpPost]
        public ActionResult CadastrarUsuario(Usuario usuario)
        {
            if(ModelState.IsValid)
            {
                if(UsuarioDAO.CadastrarUsuario(usuario))
                {
                    return RedirectToAction("Sucesso", "Usuario");
                }
                else
                {
                    ModelState.AddModelError("", "Esse e-mail já está cadastrado em nosso sistema!");
                    return View(usuario);
                }
            }
            else
            {
                return View(usuario);
            }
        }

        public ActionResult Sair()
        {
            Session["Usuario"] = null;
            return RedirectToAction("Login", "Usuario");
        }

    }
}