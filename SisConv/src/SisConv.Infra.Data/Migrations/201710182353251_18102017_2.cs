namespace SisConv.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _18102017_2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admin",
                c => new
                    {
                        AdminId = c.Guid(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100, unicode: false),
                        Email = c.String(nullable: false, maxLength: 100, unicode: false),
                        Empresa = c.String(nullable: false, maxLength: 50, unicode: false),
                        Cnpj = c.String(nullable: false, maxLength: 15, unicode: false),
                        Telefone = c.String(nullable: false, maxLength: 11, unicode: false),
                        Imagem = c.String(nullable: false, maxLength: 100, unicode: false),
                        Ativo = c.Boolean(nullable: false),
                        Senha = c.String(maxLength: 8000, unicode: false),
                    })
                .PrimaryKey(t => t.AdminId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Admin");
        }
    }
}
