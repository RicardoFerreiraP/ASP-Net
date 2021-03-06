﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Ecommerce.Models
{
    public class Context : DbContext
    {
        public Context() : base("DbEcommerce") { }

        //mapear as classes que vão virar tabela no banco de dados

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<ItemVenda> ItemVendas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}