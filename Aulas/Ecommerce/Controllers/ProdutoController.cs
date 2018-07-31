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
        Context context = new Context();
        // GET: Produto
        public ActionResult Index()
        {
            ViewBag.Data = DateTime.Now;
            ViewBag.Produtos = context.Produtos.ToList();
            return View();
        }

        public ActionResult CadastrarProduto()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CadastrarProduto(string txtNome, string txtDescricao, string txtPreco, string txtCategoria)
        {
            Produto produto = new Produto
            {
                Nome = txtNome,
                Descricao = txtDescricao,
                Preco = Convert.ToDouble(txtPreco),
                Categoria = txtCategoria
            };

            context.Produtos.Add(produto);
            context.SaveChanges();

            return RedirectToAction("Index", "Produto");
        }

        public ActionResult RemoverProduto(int id)
        {
            Produto produto = context.Produtos.Find(id);
            context.Produtos.Remove(produto);
            context.SaveChanges();
            return RedirectToAction("Index", "Produto");
        }

        public ActionResult AlterarProduto(int id)
        {
            ViewBag.Produto = context.Produtos.Find(id);
            context.SaveChanges();
            return View();
        }

        [HttpPost]
        public ActionResult AlterarProduto(string txtNome, string txtDescricao, string txtPreco, string txtCategoria, int txtId)
        {
            Produto produto = context.Produtos.Find(txtId);
            {
                produto.ProdutoId = txtId;
                produto.Nome = txtNome;
                produto.Descricao = txtDescricao;
                produto.Categoria = txtCategoria;
                produto.Preco = Convert.ToDouble(txtPreco);

                context.Entry(produto).State = EntityState.Modified;
                context.SaveChanges();

                return RedirectToAction("Index", "Produto");

            }
        }
    }
}