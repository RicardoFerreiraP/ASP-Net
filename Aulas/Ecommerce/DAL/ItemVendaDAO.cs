using Ecommerce.Models;
using Ecommerce.Utils;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Ecommerce.DAL
{
    public class ItemVendaDAO
    {
        private static Context context = SingletonContext.GetInstance();

        public static void CadastrarItem(ItemVenda itemvenda)
        {
            string carrinhoId = Sessao.RetornarCarrinhoId();
            Produto produto = itemvenda.produtoItemVenda;

            ItemVenda itemVendaDb = context.ItemVendas.FirstOrDefault(x => x.produtoItemVenda.ProdutoId == produto.ProdutoId && x.carrinhoId == carrinhoId);

            if(itemVendaDb == null)
            {
                context.ItemVendas.Add(itemvenda);
                context.SaveChanges();
            }
            else
            {
                AumentarQtd(itemVendaDb);
            }
        }

        public static List<ItemVenda> BuscarItensPorCarrinhoId(string carrinhoId)
        {
            return context.ItemVendas.Include("produtoItemVenda").Where(x => x.carrinhoId.Equals(carrinhoId)).ToList();
        }

        public static void AumentarQtd(ItemVenda itemVenda)
        {
            ++itemVenda.quantidade;
            context.SaveChanges();
        }

        public static void DiminuirQtd(ItemVenda itemVenda)
        {
            if(itemVenda.quantidade > 1)
            {
                --itemVenda.quantidade;
                context.SaveChanges();
            }
        }

        public static void RemoverItem(ItemVenda itemVenda)
        {
            if(itemVenda.quantidade == 1)
            {
                context.ItemVendas.Remove(itemVenda);
                context.SaveChanges();
            }
            else
            {
                DiminuirQtd(itemVenda);
            }
            
        }

        public static ItemVenda BuscarItemVendaPorId(int id)
        {
            ItemVenda itemVenda = context.ItemVendas.Find(id);
            return itemVenda;
        }

        public static int QtdNoCarrinho()
        {
            string carrinhoID = Sessao.RetornarCarrinhoId();
            int qtd = 0;
            List<ItemVenda> listItemVenda = context.ItemVendas.Include("produtoItemVenda").Where(x => x.carrinhoId == carrinhoID).ToList();
            foreach (ItemVenda itemVenda in listItemVenda)
            {
                qtd = qtd + itemVenda.quantidade;
            }
            return qtd;
        }
    }

}