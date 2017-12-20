namespace SisConv.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20122017 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Convocados", "Naturalidade", c => c.String(nullable: false, maxLength: 100, unicode: false));
            AddColumn("dbo.Convocados", "Pai", c => c.String(nullable: false, maxLength: 100, unicode: false));
            AddColumn("dbo.Convocados", "OrgaoEmissor", c => c.String(nullable: false, maxLength: 100, unicode: false));
            AddColumn("dbo.Convocados", "EstadoCivil", c => c.Int(nullable: false));
            AddColumn("dbo.Convocados", "DataNascimento", c => c.DateTime(nullable: false));
            AddColumn("dbo.Convocados", "Filhos", c => c.Int(nullable: false));
            AddColumn("dbo.Convocados", "Deficiente", c => c.Boolean(nullable: false));
            AddColumn("dbo.Convocados", "Deficiencia", c => c.String(nullable: false, maxLength: 100, unicode: false));
            AddColumn("dbo.Convocados", "CondicaoEspecial", c => c.String(nullable: false, maxLength: 100, unicode: false));
            AddColumn("dbo.Convocados", "Afro", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Convocados", "Afro");
            DropColumn("dbo.Convocados", "CondicaoEspecial");
            DropColumn("dbo.Convocados", "Deficiencia");
            DropColumn("dbo.Convocados", "Deficiente");
            DropColumn("dbo.Convocados", "Filhos");
            DropColumn("dbo.Convocados", "DataNascimento");
            DropColumn("dbo.Convocados", "EstadoCivil");
            DropColumn("dbo.Convocados", "OrgaoEmissor");
            DropColumn("dbo.Convocados", "Pai");
            DropColumn("dbo.Convocados", "Naturalidade");
        }
    }
}
