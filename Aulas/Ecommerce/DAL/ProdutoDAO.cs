using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Ecommerce.DAL
{
    public class ProdutoDAO
    {
        private static Context context = SingletonContext.GetInstance();

        public static List<Produto> RetornarProdutos()
        {
            return context.Produtos.Include("Categoria").ToList();
        }

        public static bool CadastrarProduto(Produto produto)
        {
            if(BuscarProdutoPorNome(produto) == null)
            {
                context.Produtos.Add(produto);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public static Produto BuscarProdutoPorNome(Produto produto)
        {
            return context.Produtos.FirstOrDefault(x => x.Nome.Equals(produto.Nome));
        }

        public static Produto BuscarProdutoPorId(int id)
        {
            return context.Produtos.Find(id);
        }

        public static void RemoverProduto(int id)
        {
            context.Produtos.Remove(BuscarProdutoPorId(id));
            context.SaveChanges();
        }

        public static void AlterarProduto(Produto produto)
        {
            if(produto != null)
            {
                context.Entry(produto).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public static List<Produto> BuscarProdutoPorCategoria(int? id)
        {
            return context.Produtos.Include("Categoria").Where(x => x.Categoria.CategoriaId == id).ToList();
        }
    }
}