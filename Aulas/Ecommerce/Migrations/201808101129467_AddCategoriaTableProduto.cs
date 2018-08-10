namespace Ecommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCategoriaTableProduto : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Produtos", "Categoria_CategoriaId", c => c.Int());
            CreateIndex("dbo.Produtos", "Categoria_CategoriaId");
            AddForeignKey("dbo.Produtos", "Categoria_CategoriaId", "dbo.Categoria", "CategoriaId");
            DropColumn("dbo.Produtos", "Categoria");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Produtos", "Categoria", c => c.String(nullable: false));
            DropForeignKey("dbo.Produtos", "Categoria_CategoriaId", "dbo.Categoria");
            DropIndex("dbo.Produtos", new[] { "Categoria_CategoriaId" });
            DropColumn("dbo.Produtos", "Categoria_CategoriaId");
        }
    }
}
