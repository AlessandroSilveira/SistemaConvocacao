namespace SisConv.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _23112017_4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cargos", "ConvocacaoId", "dbo.Convocacoes");
            DropIndex("dbo.Cargos", new[] { "ConvocacaoId" });
            DropIndex("dbo.Convocacoes", new[] { "ClienteId" });
            CreateTable(
                "dbo.Processos",
                c => new
                    {
                        ProcessoId = c.Guid(nullable: false, identity: true),
                        ClienteId = c.Guid(nullable: false),
                        Nome = c.String(nullable: false, maxLength: 100, unicode: false),
                        DataCriacao = c.DateTime(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ProcessoId)
                .Index(t => t.ClienteId);
            
            AddColumn("dbo.Cargos", "ProcessoId", c => c.Guid(nullable: false));
            AddColumn("dbo.Convocacoes", "ProcessoId", c => c.Guid(nullable: false));
            AddColumn("dbo.Convocacoes", "PessoaId", c => c.Guid(nullable: false));
            AddColumn("dbo.Convocacoes", "DataEntregaDocumentos", c => c.DateTime(nullable: false));
            AddColumn("dbo.Convocacoes", "HorarioEntregaDocumento", c => c.String(nullable: false, maxLength: 8000, unicode: false));
            AddColumn("dbo.Convocacoes", "EnderecoEntregaDocumento", c => c.String(nullable: false, maxLength: 150, unicode: false));
            AddColumn("dbo.Convocacoes", "EnviouEmail", c => c.Boolean(nullable: false));
            AddColumn("dbo.Convocacoes", "Desistente", c => c.Boolean(nullable: false));
            AddColumn("dbo.Convocados", "ProcessoId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Cargos", "ProcessoId");
            AddForeignKey("dbo.Cargos", "ProcessoId", "dbo.Processos", "ProcessoId");
            DropColumn("dbo.Cargos", "ConvocacaoId");
            DropColumn("dbo.Convocacoes", "ClienteId");
            DropColumn("dbo.Convocacoes", "Nome");
            DropColumn("dbo.Convocacoes", "DataCriacao");
            DropColumn("dbo.Convocados", "ConvocacaoId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Convocados", "ConvocacaoId", c => c.Guid(nullable: false));
            AddColumn("dbo.Convocacoes", "DataCriacao", c => c.DateTime(nullable: false));
            AddColumn("dbo.Convocacoes", "Nome", c => c.String(nullable: false, maxLength: 100, unicode: false));
            AddColumn("dbo.Convocacoes", "ClienteId", c => c.Guid(nullable: false));
            AddColumn("dbo.Cargos", "ConvocacaoId", c => c.Guid(nullable: false));
            DropForeignKey("dbo.Cargos", "ProcessoId", "dbo.Processos");
            DropIndex("dbo.Processos", new[] { "ClienteId" });
            DropIndex("dbo.Cargos", new[] { "ProcessoId" });
            DropColumn("dbo.Convocados", "ProcessoId");
            DropColumn("dbo.Convocacoes", "Desistente");
            DropColumn("dbo.Convocacoes", "EnviouEmail");
            DropColumn("dbo.Convocacoes", "EnderecoEntregaDocumento");
            DropColumn("dbo.Convocacoes", "HorarioEntregaDocumento");
            DropColumn("dbo.Convocacoes", "DataEntregaDocumentos");
            DropColumn("dbo.Convocacoes", "PessoaId");
            DropColumn("dbo.Convocacoes", "ProcessoId");
            DropColumn("dbo.Cargos", "ProcessoId");
            DropTable("dbo.Processos");
            CreateIndex("dbo.Convocacoes", "ClienteId");
            CreateIndex("dbo.Cargos", "ConvocacaoId");
            AddForeignKey("dbo.Cargos", "ConvocacaoId", "dbo.Convocacoes", "ConvocacaoId");
        }
    }
}
