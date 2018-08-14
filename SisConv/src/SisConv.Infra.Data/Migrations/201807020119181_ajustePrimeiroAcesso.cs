using System.Data.Entity.Migrations;

namespace SisConv.Infra.Data.Migrations
{
    public partial class ajustePrimeiroAcesso : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PrimeiroAcesso", "Data", c => c.DateTime(false));
            AlterColumn("dbo.PrimeiroAcesso", "Email", c => c.String(false, 200, unicode: false));
        }

        public override void Down()
        {
            AlterColumn("dbo.PrimeiroAcesso", "Email", c => c.String(false, 8000, unicode: false));
            DropColumn("dbo.PrimeiroAcesso", "Data");
        }
    }
}