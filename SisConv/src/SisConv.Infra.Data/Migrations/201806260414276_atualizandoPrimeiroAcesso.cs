namespace SisConv.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class atualizandoPrimeiroAcesso : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PrimeiroAcesso", "Email", c => c.String(nullable: false, maxLength: 8000, unicode: false));
            DropColumn("dbo.PrimeiroAcesso", "primeiroAcesso");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PrimeiroAcesso", "primeiroAcesso", c => c.Boolean(nullable: false));
            DropColumn("dbo.PrimeiroAcesso", "Email");
        }
    }
}
