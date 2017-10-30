namespace SisConv.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _29102017 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cargos",
                c => new
                    {
                        CargoId = c.Guid(nullable: false, identity: true),
                        ConvocacaoId = c.Guid(nullable: false),
                        Nome = c.String(nullable: false, maxLength: 100, unicode: false),
                        CodigoCargo = c.String(nullable: false, maxLength: 4, unicode: false),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CargoId)
                .ForeignKey("dbo.Convocacoes", t => t.ConvocacaoId)
                .Index(t => t.ConvocacaoId);
            
            CreateTable(
                "dbo.Convocacoes",
                c => new
                    {
                        ConvocacaoId = c.Guid(nullable: false, identity: true),
                        ClienteId = c.Guid(nullable: false),
                        Nome = c.String(nullable: false, maxLength: 100, unicode: false),
                        DataCriacao = c.DateTime(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ConvocacaoId)
                .ForeignKey("dbo.Clientes", t => t.ClienteId)
                .Index(t => t.ClienteId);
            
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        ClienteId = c.Guid(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100, unicode: false),
                        Cnpj = c.String(nullable: false, maxLength: 15, unicode: false),
                        Email = c.String(nullable: false, maxLength: 100, unicode: false),
                        Telefone = c.String(nullable: false, maxLength: 20, unicode: false),
                        Imagem = c.String(nullable: false, maxLength: 8000, unicode: false),
                        Ativo = c.Boolean(nullable: false),
                        Password = c.String(nullable: false, maxLength: 10, unicode: false),
                        ConfirmPassword = c.String(maxLength: 8000, unicode: false),
                    })
                .PrimaryKey(t => t.ClienteId);
            
            CreateTable(
                "dbo.Pessoa",
                c => new
                    {
                        PessoaId = c.Guid(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100, unicode: false),
                        Naturalidade = c.String(nullable: false, maxLength: 100, unicode: false),
                        Mae = c.String(nullable: false, maxLength: 100, unicode: false),
                        Pai = c.String(nullable: false, maxLength: 100, unicode: false),
                        Documento = c.String(nullable: false, maxLength: 30, unicode: false),
                        OrgaoEmissor = c.String(nullable: false, maxLength: 10, unicode: false),
                        Sexo = c.Int(nullable: false),
                        EstadoCivil = c.Int(nullable: false),
                        DataNascimento = c.DateTime(nullable: false),
                        Filhos = c.Int(nullable: false),
                        Endereco = c.String(nullable: false, maxLength: 100, unicode: false),
                        Numero = c.String(nullable: false, maxLength: 6, unicode: false),
                        Complemento = c.String(nullable: false, maxLength: 100, unicode: false),
                        Bairro = c.String(nullable: false, maxLength: 100, unicode: false),
                        Cep = c.String(nullable: false, maxLength: 8, unicode: false),
                        Cidade = c.String(nullable: false, maxLength: 100, unicode: false),
                        Uf = c.String(nullable: false, maxLength: 2, unicode: false),
                        Cargo = c.String(nullable: false, maxLength: 6, unicode: false),
                        Deficiente = c.Boolean(nullable: false),
                        Deficiencia = c.String(nullable: false, maxLength: 100, unicode: false),
                        CondicaoEspecial = c.String(nullable: false, maxLength: 100, unicode: false),
                        Cpf = c.String(nullable: false, maxLength: 11, unicode: false),
                        Email = c.String(nullable: false, maxLength: 100, unicode: false),
                        Afro = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PessoaId);
            
            CreateTable(
                "dbo.PrimeiroAcesso",
                c => new
                    {
                        PrimeiroAcessoId = c.Guid(nullable: false, identity: true),
                        primeiroAcesso = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PrimeiroAcessoId);
            
            CreateTable(
                "dbo.Telefone",
                c => new
                    {
                        TelefoneId = c.Guid(nullable: false, identity: true),
                        Ddd = c.String(nullable: false, maxLength: 2, unicode: false),
                        Numero = c.String(nullable: false, maxLength: 11, unicode: false),
                        PessoaId_PessoaId = c.Guid(),
                    })
                .PrimaryKey(t => t.TelefoneId)
                .ForeignKey("dbo.Pessoa", t => t.PessoaId_PessoaId)
                .Index(t => t.PessoaId_PessoaId);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        UsuarioId = c.Guid(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100, unicode: false),
                        Email = c.String(nullable: false, maxLength: 100, unicode: false),
                        Login = c.String(nullable: false, maxLength: 20, unicode: false),
                        Senha = c.String(nullable: false, maxLength: 10, unicode: false),
                        Perfil = c.String(nullable: false, maxLength: 1, unicode: false),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UsuarioId);
            
            CreateTable(
                "dbo.Admin",
                c => new
                    {
                        AdminId = c.Guid(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100, unicode: false),
                        Email = c.String(nullable: false, maxLength: 100, unicode: false),
                        Empresa = c.String(nullable: false, maxLength: 50, unicode: false),
                        Cnpj = c.String(nullable: false, maxLength: 15, unicode: false),
                        Telefone = c.String(nullable: false, maxLength: 11, unicode: false),
                        Imagem = c.Binary(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                        Senha = c.String(maxLength: 8000, unicode: false),
                    })
                .PrimaryKey(t => t.AdminId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Telefone", "PessoaId_PessoaId", "dbo.Pessoa");
            DropForeignKey("dbo.Convocacoes", "ClienteId", "dbo.Clientes");
            DropForeignKey("dbo.Cargos", "ConvocacaoId", "dbo.Convocacoes");
            DropIndex("dbo.Telefone", new[] { "PessoaId_PessoaId" });
            DropIndex("dbo.Convocacoes", new[] { "ClienteId" });
            DropIndex("dbo.Cargos", new[] { "ConvocacaoId" });
            DropTable("dbo.Admin");
            DropTable("dbo.Usuario");
            DropTable("dbo.Telefone");
            DropTable("dbo.PrimeiroAcesso");
            DropTable("dbo.Pessoa");
            DropTable("dbo.Clientes");
            DropTable("dbo.Convocacoes");
            DropTable("dbo.Cargos");
        }
    }
}
