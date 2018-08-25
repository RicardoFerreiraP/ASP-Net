using Ecommerce.DAL;
using Ecommerce.Models;
using Ecommerce.Utils;
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
            if (id != null)
            {
                return View(ProdutoDAO.BuscarProdutoPorCategoria(id));
                
            }
            else
            {
                return View(ProdutoDAO.RetornarProdutos());
            }
            
        }

        public ActionResult DetalhesProduto(int id)
        {
            return View(ProdutoDAO.BuscarProdutoPorId(id));
        }

        public ActionResult AdicionarAoCarrinho(int id)
        {
            Produto produto = ProdutoDAO.BuscarProdutoPorId(id);
            ItemVenda itemVenda = new ItemVenda
            {
                produtoItemVenda = produto,
                quantidade = 1,
                precoItemVenda = produto.Preco,
                dataItemVenda = DateTime.Now,
                carrinhoId = Sessao.RetornarCarrinhoId()
            };
            ItemVendaDAO.CadastrarItem(itemVenda);

            return RedirectToAction("CarrinhoCompras", "Home");
        }

        public ActionResult CarrinhoCompras()
        {
            return View(ItemVendaDAO.BuscarItensPorCarrinhoId(Sessao.RetornarCarrinhoId()));
        }

        public ActionResult DiminuirItem(int id)
        {
            ItemVenda itemVenda = ItemVendaDAO.BuscarItemVendaPorId(id);
            ItemVendaDAO.DiminuirQtd(itemVenda);
            return RedirectToAction("CarrinhoCompras");
        }

        public ActionResult AumentarItem(int id)
        {
            ItemVenda itemVenda = ItemVendaDAO.BuscarItemVendaPorId(id);
            ItemVendaDAO.AumentarQtd(itemVenda);
            return RedirectToAction("CarrinhoCompras");
        }

        public ActionResult RemoverItem(int id)
        {
            ItemVenda itemVenda = ItemVendaDAO.BuscarItemVendaPorId(id);
            ItemVendaDAO.RemoverItem(itemVenda);
            return RedirectToAction("CarrinhoCompras");
        }
    }
}