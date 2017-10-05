namespace SisConv.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _05102017 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PrimeiroAcesso",
                c => new
                    {
                        PrimeiroAcessoId = c.Guid(nullable: false, identity: true),
                        primeiroAcesso = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PrimeiroAcessoId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PrimeiroAcesso");
        }
    }
}
