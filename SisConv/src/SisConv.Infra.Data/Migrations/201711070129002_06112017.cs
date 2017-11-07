namespace SisConv.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _06112017 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Convocados",
                c => new
                    {
                        ConvocadoId = c.Guid(nullable: false, identity: true),
                        ConvocacaoId = c.Guid(nullable: false),
                        Inscricao = c.String(nullable: false, maxLength: 10, unicode: false),
                        Nome = c.String(nullable: false, maxLength: 100, unicode: false),
                        Mae = c.String(nullable: false, maxLength: 100, unicode: false),
                        Sexo = c.Boolean(nullable: false),
                        Nascimento = c.DateTime(nullable: false),
                        Documento = c.String(nullable: false, maxLength: 50, unicode: false),
                        Cpf = c.String(nullable: false, maxLength: 11, unicode: false),
                        Email = c.String(nullable: false, maxLength: 100, unicode: false),
                        Telefone = c.String(nullable: false, maxLength: 11, unicode: false),
                        Celular = c.String(nullable: false, maxLength: 11, unicode: false),
                        Endereco = c.String(nullable: false, maxLength: 100, unicode: false),
                        Numero = c.String(nullable: false, maxLength: 10, unicode: false),
                        Complemento = c.String(nullable: false, maxLength: 100, unicode: false),
                        Bairro = c.String(nullable: false, maxLength: 100, unicode: false),
                        Cidade = c.String(nullable: false, maxLength: 50, unicode: false),
                        Uf = c.String(nullable: false, maxLength: 2, unicode: false),
                        Cep = c.String(nullable: false, maxLength: 8, unicode: false),
                        Cargo = c.String(nullable: false, maxLength: 8, unicode: false),
                        CargoId = c.Guid(nullable: false),
                        Pontuacao = c.Int(nullable: false),
                        Posicao = c.Int(nullable: false),
                        Resultado = c.String(nullable: false, maxLength: 8000, unicode: false),
                    })
                .PrimaryKey(t => t.ConvocadoId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Convocados");
        }
    }
}
