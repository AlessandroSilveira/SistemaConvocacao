namespace SisConv.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _11122017_2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Processos", "TextoDeAceitacaoDaConvocacao", c => c.String(maxLength: 8000, unicode: false));
            AddColumn("dbo.Processos", "TextoInicialTelaConvocado", c => c.String(maxLength: 8000, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Processos", "TextoInicialTelaConvocado");
            DropColumn("dbo.Processos", "TextoDeAceitacaoDaConvocacao");
        }
    }
}
