namespace SisConv.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alteracao_convocado : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Convocados", "FatorSanguineo", c => c.String(nullable: false, maxLength: 2, unicode: false));
            AddColumn("dbo.Convocados", "Doador", c => c.String(nullable: false, maxLength: 1, unicode: false));
            AddColumn("dbo.Convocados", "Estado", c => c.String(nullable: false, maxLength: 2, unicode: false));
            AddColumn("dbo.Convocados", "Recados", c => c.String(nullable: false, maxLength: 20, unicode: false));
            AddColumn("dbo.Convocados", "Nacionalidade", c => c.String(nullable: false, maxLength: 100, unicode: false));
            AddColumn("dbo.Convocados", "GrauInstrucao", c => c.String(nullable: false, maxLength: 100, unicode: false));
            AddColumn("dbo.Convocados", "InstituicaoEnsino", c => c.String(nullable: false, maxLength: 100, unicode: false));
            AddColumn("dbo.Convocados", "TelefoneIES", c => c.String(nullable: false, maxLength: 100, unicode: false));
            AddColumn("dbo.Convocados", "Curso", c => c.String(maxLength: 8000, unicode: false));
            AddColumn("dbo.Convocados", "HorarioAulaIES", c => c.String(nullable: false, maxLength: 100, unicode: false));
            AddColumn("dbo.Convocados", "PeriodoAtual", c => c.String(nullable: false, maxLength: 100, unicode: false));
            AddColumn("dbo.Convocados", "ColacaoGrau", c => c.String(nullable: false, maxLength: 100, unicode: false));
            AddColumn("dbo.Convocados", "Agencia", c => c.String(nullable: false, maxLength: 100, unicode: false));
            AddColumn("dbo.Convocados", "NomeAgencia", c => c.String(nullable: false, maxLength: 100, unicode: false));
            AddColumn("dbo.Convocados", "ContaCorrente", c => c.String(nullable: false, maxLength: 100, unicode: false));
            AlterColumn("dbo.Convocados", "Documento", c => c.String(nullable: false, maxLength: 25, unicode: false));
            AlterColumn("dbo.Convocados", "EstadoCivil", c => c.String(nullable: false, maxLength: 8000, unicode: false));
            AlterColumn("dbo.Convocados", "DataNascimento", c => c.String(nullable: false, maxLength: 8000, unicode: false));
            DropColumn("dbo.Convocados", "Nascimento");
            DropColumn("dbo.Convocados", "Uf");
            DropColumn("dbo.Convocados", "OrgaoEmissor");
            DropColumn("dbo.Convocados", "Filhos");
            DropColumn("dbo.Convocados", "Deficiente");
            DropColumn("dbo.Convocados", "Deficiencia");
            DropColumn("dbo.Convocados", "CondicaoEspecial");
            DropColumn("dbo.Convocados", "Afro");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Convocados", "Afro", c => c.Boolean(nullable: false));
            AddColumn("dbo.Convocados", "CondicaoEspecial", c => c.String(nullable: false, maxLength: 100, unicode: false));
            AddColumn("dbo.Convocados", "Deficiencia", c => c.String(nullable: false, maxLength: 100, unicode: false));
            AddColumn("dbo.Convocados", "Deficiente", c => c.Boolean(nullable: false));
            AddColumn("dbo.Convocados", "Filhos", c => c.Int(nullable: false));
            AddColumn("dbo.Convocados", "OrgaoEmissor", c => c.String(nullable: false, maxLength: 100, unicode: false));
            AddColumn("dbo.Convocados", "Uf", c => c.String(nullable: false, maxLength: 2, unicode: false));
            AddColumn("dbo.Convocados", "Nascimento", c => c.String(nullable: false, maxLength: 8000, unicode: false));
            AlterColumn("dbo.Convocados", "DataNascimento", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Convocados", "EstadoCivil", c => c.Int(nullable: false));
            AlterColumn("dbo.Convocados", "Documento", c => c.String(nullable: false, maxLength: 50, unicode: false));
            DropColumn("dbo.Convocados", "ContaCorrente");
            DropColumn("dbo.Convocados", "NomeAgencia");
            DropColumn("dbo.Convocados", "Agencia");
            DropColumn("dbo.Convocados", "ColacaoGrau");
            DropColumn("dbo.Convocados", "PeriodoAtual");
            DropColumn("dbo.Convocados", "HorarioAulaIES");
            DropColumn("dbo.Convocados", "Curso");
            DropColumn("dbo.Convocados", "TelefoneIES");
            DropColumn("dbo.Convocados", "InstituicaoEnsino");
            DropColumn("dbo.Convocados", "GrauInstrucao");
            DropColumn("dbo.Convocados", "Nacionalidade");
            DropColumn("dbo.Convocados", "Recados");
            DropColumn("dbo.Convocados", "Estado");
            DropColumn("dbo.Convocados", "Doador");
            DropColumn("dbo.Convocados", "FatorSanguineo");
        }
    }
}
