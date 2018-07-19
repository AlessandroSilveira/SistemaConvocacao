namespace SisConv.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addConvocadoId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PrimeiroAcesso", "ConvocadoId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PrimeiroAcesso", "ConvocadoId");
        }
    }
}
