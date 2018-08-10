using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Ecommerce.DAL
{
    public class CategoriaDAO
    {
        private static Context context = new Context();

        public static List<Categoria> RetornarCategorias()
        {
            return context.Categorias.ToList();
        }

        public static bool CadastrarCategoria(Categoria categoria)
        {
            if (BuscarCategoriaPorNome(categoria) == null)
            {
                context.Categorias.Add(categoria);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public static Categoria BuscarCategoriaPorNome(Categoria categoria)
        {
            return context.Categorias.FirstOrDefault(x => x.NomeCategoria.Equals(categoria.NomeCategoria));
        }

        public static Categoria BuscarCategoriaPorId(int? id)
        {
            return context.Categorias.Find(id);
        }
        public static void RemoverCategoria(int id)
        {
            context.Categorias.Remove(BuscarCategoriaPorId(id));
            context.SaveChanges();
        }

        public static void AlterarCategoria(Categoria categoria)
        {
            if (categoria != null)
            {
                context.Entry(categoria).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

    }
}