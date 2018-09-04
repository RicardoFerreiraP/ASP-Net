using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ecommerce.Models
{
    public class Venda
    {
        public int vendaId { get; set; }

        public List<ItemVenda> itemVenda { get; set; }

        public Usuario usuario{ get; set; }

        public int quantidade { get; set; }

        public double precoVenda { get; set; }

        public DateTime dataVenda { get; set; }

    }
}