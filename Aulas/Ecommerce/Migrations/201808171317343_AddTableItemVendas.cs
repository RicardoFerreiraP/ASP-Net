namespace Ecommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableItemVendas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ItemVendas",
                c => new
                    {
                        idItemVenda = c.Int(nullable: false, identity: true),
                        quantidade = c.Int(nullable: false),
                        precoItemVenda = c.Double(nullable: false),
                        dataItemVenda = c.DateTime(nullable: false),
                        produtoItemVenda_ProdutoId = c.Int(),
                    })
                .PrimaryKey(t => t.idItemVenda)
                .ForeignKey("dbo.Produtos", t => t.produtoItemVenda_ProdutoId)
                .Index(t => t.produtoItemVenda_ProdutoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ItemVendas", "produtoItemVenda_ProdutoId", "dbo.Produtos");
            DropIndex("dbo.ItemVendas", new[] { "produtoItemVenda_ProdutoId" });
            DropTable("dbo.ItemVendas");
        }
    }
}
