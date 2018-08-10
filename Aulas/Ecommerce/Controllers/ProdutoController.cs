using Ecommerce.DAL;
using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ecommerce.Controllers
{
    public class ProdutoController : Controller
    {
        // GET: Produto
        public ActionResult Index()
        {
            ViewBag.Data = DateTime.Now;
            return View(ProdutoDAO.RetornarProdutos());
        }

        public ActionResult CadastrarProduto()
        {
            ViewBag.Categorias = new SelectList(CategoriaDAO.RetornarCategorias(), "CategoriaId", "NomeCategoria");
            return View();
        }

        [HttpPost]
        public ActionResult CadastrarProduto(Produto produto, int? Categorias)
        {
            ViewBag.Categorias = new SelectList(CategoriaDAO.RetornarCategorias(), "CategoriaId", "NomeCategoria");
            if (ModelState.IsValid)
            {
                if (Categorias != null )
                {
                    produto.Categoria = CategoriaDAO.BuscarCategoriaPorId(Categorias);
                    if (ProdutoDAO.CadastrarProduto(produto))
                    {
                        return RedirectToAction("Index", "Produto");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Não é possível adicionar um produto com o mesmo nome!");
                        return View(produto);
                    } 
                }
                else
                {
                    ModelState.AddModelError("", "Por favor, selecione uma categoria!");
                    return View(produto);
                }
            }
            else
            {
                return View(produto);
            }
        }

        public ActionResult RemoverProduto(int id)
        {
            ProdutoDAO.RemoverProduto(id);
            return RedirectToAction("Index", "Produto");
        }

        public ActionResult AlterarProduto(int id)
        {
            return View(ProdutoDAO.BuscarProdutoPorId(id));
        }

        [HttpPost]
        public ActionResult AlterarProduto(Produto produtoAlterado)
        {
            Produto produtoOriginal = ProdutoDAO.BuscarProdutoPorId(produtoAlterado.ProdutoId);

            produtoOriginal.Nome = produtoAlterado.Nome;
            produtoOriginal.Descricao = produtoAlterado.Descricao;
            produtoOriginal.Categoria = produtoAlterado.Categoria;
            produtoOriginal.Preco = produtoAlterado.Preco;

            ProdutoDAO.AlterarProduto(produtoOriginal);
            return RedirectToAction("Index", "Produto");
        }
    }
}