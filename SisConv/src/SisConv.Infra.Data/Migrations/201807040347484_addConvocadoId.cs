using System.Data.Entity.Migrations;

namespace SisConv.Infra.Data.Migrations
{
    public partial class addConvocadoId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PrimeiroAcesso", "ConvocadoId", c => c.Guid(false));
        }

        public override void Down()
        {
            DropColumn("dbo.PrimeiroAcesso", "ConvocadoId");
        }
    }
}