namespace SisConv.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _15122017 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Convocacoes", "Desistente", c => c.String(maxLength: 1, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Convocacoes", "Desistente", c => c.Boolean(nullable: false));
        }
    }
}
