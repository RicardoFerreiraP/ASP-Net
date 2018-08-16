using Ecommerce.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ecommerce.Controllers
{
    public class HomeController : Controller
    {
        static ProdutoDAO produtoDAO = new ProdutoDAO();
        static CategoriaDAO categoriaDAO = new CategoriaDAO();
        // GET: Home
        public ActionResult Index(int? id)
        {
            ViewBag.Categoria = CategoriaDAO.RetornarCategorias();
            if(id == null)
            {
                return View(ProdutoDAO.RetornarProdutos());
            }
            return View(ProdutoDAO.BuscarProdutoPorCategoria(id));
        }

        public ActionResult DetalhesProduto(int id)
        {
            return View(ProdutoDAO.BuscarProdutoPorId(id));
        }
    }
}