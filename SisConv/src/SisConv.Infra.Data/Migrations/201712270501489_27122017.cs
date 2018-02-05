namespace SisConv.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _27122017 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Convocacoes", "StatusConvocacao", c => c.String(maxLength: 150, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Convocacoes", "StatusConvocacao");
        }
    }
}
