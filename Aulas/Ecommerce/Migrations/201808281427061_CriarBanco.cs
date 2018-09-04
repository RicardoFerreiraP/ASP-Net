namespace Ecommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CriarBanco : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categoria",
                c => new
                    {
                        CategoriaId = c.Int(nullable: false, identity: true),
                        NomeCategoria = c.String(nullable: false, maxLength: 50),
                        DescricaoCategoria = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.CategoriaId);
            
            CreateTable(
                "dbo.ItemVendas",
                c => new
                    {
                        idItemVenda = c.Int(nullable: false, identity: true),
                        quantidade = c.Int(nullable: false),
                        precoItemVenda = c.Double(nullable: false),
                        dataItemVenda = c.DateTime(nullable: false),
                        carrinhoId = c.String(),
                        produtoItemVenda_ProdutoId = c.Int(),
                        usuario_UsuarioId = c.Int(),
                    })
                .PrimaryKey(t => t.idItemVenda)
                .ForeignKey("dbo.Produtos", t => t.produtoItemVenda_ProdutoId)
                .ForeignKey("dbo.Usuarios", t => t.usuario_UsuarioId)
                .Index(t => t.produtoItemVenda_ProdutoId)
                .Index(t => t.usuario_UsuarioId);
            
            CreateTable(
                "dbo.Produtos",
                c => new
                    {
                        ProdutoId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 50),
                        Descricao = c.String(nullable: false, maxLength: 150),
                        Preco = c.Double(nullable: false),
                        Imagem = c.String(),
                        Categoria_CategoriaId = c.Int(),
                    })
                .PrimaryKey(t => t.ProdutoId)
                .ForeignKey("dbo.Categoria", t => t.Categoria_CategoriaId)
                .Index(t => t.Categoria_CategoriaId);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        UsuarioId = c.Int(nullable: false, identity: true),
                        NomeUsuario = c.String(nullable: false, maxLength: 150),
                        EnderecoUsuario = c.String(nullable: false),
                        TelefoneUsuario = c.String(nullable: false),
                        EmailUsuario = c.String(nullable: false),
                        SenhaUsuario = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UsuarioId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ItemVendas", "usuario_UsuarioId", "dbo.Usuarios");
            DropForeignKey("dbo.ItemVendas", "produtoItemVenda_ProdutoId", "dbo.Produtos");
            DropForeignKey("dbo.Produtos", "Categoria_CategoriaId", "dbo.Categoria");
            DropIndex("dbo.Produtos", new[] { "Categoria_CategoriaId" });
            DropIndex("dbo.ItemVendas", new[] { "usuario_UsuarioId" });
            DropIndex("dbo.ItemVendas", new[] { "produtoItemVenda_ProdutoId" });
            DropTable("dbo.Usuarios");
            DropTable("dbo.Produtos");
            DropTable("dbo.ItemVendas");
            DropTable("dbo.Categoria");
        }
    }
}
