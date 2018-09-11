namespace Ecommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterTableUsuario : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Usuarios", "cep", c => c.String());
            AddColumn("dbo.Usuarios", "logradouro", c => c.String());
            AddColumn("dbo.Usuarios", "bairro", c => c.String());
            AddColumn("dbo.Usuarios", "localidade", c => c.String());
            AddColumn("dbo.Usuarios", "uf", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Usuarios", "uf");
            DropColumn("dbo.Usuarios", "localidade");
            DropColumn("dbo.Usuarios", "bairro");
            DropColumn("dbo.Usuarios", "logradouro");
            DropColumn("dbo.Usuarios", "cep");
        }
    }
}
