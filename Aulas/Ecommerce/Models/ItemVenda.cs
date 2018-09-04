using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Ecommerce.Models
{
    [Table("ItemVendas")]
    public class ItemVenda
    {
        [Key]
        public int idItemVenda { get; set; }

        public Produto produtoItemVenda { get; set; }

        public int quantidade { get; set; }

        public double precoItemVenda { get; set; }

        public DateTime dataItemVenda { get; set; }

        public string carrinhoId { get; set; }

        public Usuario usuario { get; set; }
    }
}