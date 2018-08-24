namespace Ecommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddcarrinhoIdItemVenda : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ItemVendas", "carrinhoId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ItemVendas", "carrinhoId");
        }
    }
}
