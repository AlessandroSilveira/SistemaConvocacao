using System.Data.Entity.Migrations;

namespace SisConv.Infra.Data.Migrations
{
    public partial class atualizandoPrimeiroAcesso : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PrimeiroAcesso", "Email", c => c.String(false, 8000, unicode: false));
            DropColumn("dbo.PrimeiroAcesso", "primeiroAcesso");
        }

        public override void Down()
        {
            AddColumn("dbo.PrimeiroAcesso", "primeiroAcesso", c => c.Boolean(false));
            DropColumn("dbo.PrimeiroAcesso", "Email");
        }
    }
}