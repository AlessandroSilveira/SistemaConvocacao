namespace SisConv.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _14112017 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Convocados", "Sexo", c => c.String(nullable: false, maxLength: 8000, unicode: false));
            AlterColumn("dbo.Convocados", "Nascimento", c => c.String(nullable: false, maxLength: 8000, unicode: false));
            AlterColumn("dbo.Convocados", "Pontuacao", c => c.String(nullable: false, maxLength: 8000, unicode: false));
            AlterColumn("dbo.Convocados", "Posicao", c => c.String(nullable: false, maxLength: 8000, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Convocados", "Posicao", c => c.Int(nullable: false));
            AlterColumn("dbo.Convocados", "Pontuacao", c => c.Int(nullable: false));
            AlterColumn("dbo.Convocados", "Nascimento", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Convocados", "Sexo", c => c.Boolean(nullable: false));
        }
    }
}
