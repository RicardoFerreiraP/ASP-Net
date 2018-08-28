namespace Ecommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterTableUsuarios : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Usuario", newName: "Usuarios");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Usuarios", newName: "Usuario");
        }
    }
}
