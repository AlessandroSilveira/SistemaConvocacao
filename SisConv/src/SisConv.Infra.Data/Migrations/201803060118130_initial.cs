namespace SisConv.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cargos",
                c => new
                    {
                        CargoId = c.Guid(nullable: false, identity: true),
                        ProcessoId = c.Guid(nullable: false),
                        Nome = c.String(nullable: false, maxLength: 100, unicode: false),
                        CodigoCargo = c.String(nullable: false, maxLength: 4, unicode: false),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CargoId)
                .ForeignKey("dbo.Processos", t => t.ProcessoId)
                .Index(t => t.ProcessoId);
            
            CreateTable(
                "dbo.Processos",
                c => new
                    {
                        ProcessoId = c.Guid(nullable: false, identity: true),
                        ClienteId = c.Guid(nullable: false),
                        Nome = c.String(nullable: false, maxLength: 100, unicode: false),
                        DataCriacao = c.DateTime(nullable: false),
                        TextoDeAceitacaoDaConvocacao = c.String(nullable: false, maxLength: 200, unicode: false),
                        TextoInicialTelaConvocado = c.String(nullable: false, maxLength: 200, unicode: false),
                        TextoParaDesistentes = c.String(nullable: false, maxLength: 200, unicode: false),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ProcessoId)
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
                "dbo.Documentos",
                c => new
                    {
                        DocumentoId = c.Guid(nullable: false),
                        ProcessoId = c.Guid(nullable: false),
                        Descricao = c.String(nullable: false, maxLength: 100, unicode: false),
                        DataCriacao = c.DateTime(nullable: false),
                        Path = c.String(nullable: false, maxLength: 200, unicode: false),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.DocumentoId)
                .ForeignKey("dbo.Processos", t => t.ProcessoId)
                .Index(t => t.ProcessoId);
            
            CreateTable(
                "dbo.Convocacoes",
                c => new
                    {
                        ConvocacaoId = c.Guid(nullable: false, identity: true),
                        ProcessoId = c.Guid(nullable: false),
                        ConvocadoId = c.Guid(nullable: false),
                        DataEntregaDocumentos = c.DateTime(nullable: false),
                        HorarioEntregaDocumento = c.String(nullable: false, maxLength: 8000, unicode: false),
                        EnderecoEntregaDocumento = c.String(nullable: false, maxLength: 150, unicode: false),
                        EnviouEmail = c.Boolean(nullable: false),
                        Desistente = c.String(maxLength: 1, unicode: false),
                        Ativo = c.Boolean(nullable: false),
                        StatusConvocacao = c.String(maxLength: 150, unicode: false),
                        StatusContratacao = c.String(maxLength: 150, unicode: false),
                    })
                .PrimaryKey(t => t.ConvocacaoId);
            
            CreateTable(
                "dbo.Convocados",
                c => new
                    {
                        ConvocadoId = c.Guid(nullable: false, identity: true),
                        ProcessoId = c.Guid(nullable: false),
                        Inscricao = c.String(nullable: false, maxLength: 10, unicode: false),
                        Nome = c.String(nullable: false, maxLength: 100, unicode: false),
                        Mae = c.String(nullable: false, maxLength: 100, unicode: false),
                        Sexo = c.String(nullable: false, maxLength: 8000, unicode: false),
                        Nascimento = c.String(nullable: false, maxLength: 8000, unicode: false),
                        Documento = c.String(nullable: false, maxLength: 50, unicode: false),
                        Cpf = c.String(nullable: false, maxLength: 11, unicode: false),
                        Email = c.String(nullable: false, maxLength: 100, unicode: false),
                        Telefone = c.String(nullable: false, maxLength: 20, unicode: false),
                        Celular = c.String(nullable: false, maxLength: 20, unicode: false),
                        Endereco = c.String(nullable: false, maxLength: 100, unicode: false),
                        Numero = c.String(nullable: false, maxLength: 50, unicode: false),
                        Complemento = c.String(nullable: false, maxLength: 100, unicode: false),
                        Bairro = c.String(nullable: false, maxLength: 100, unicode: false),
                        Cidade = c.String(nullable: false, maxLength: 50, unicode: false),
                        Uf = c.String(nullable: false, maxLength: 2, unicode: false),
                        Cep = c.String(nullable: false, maxLength: 8, unicode: false),
                        Cargo = c.String(nullable: false, maxLength: 100, unicode: false),
                        CargoId = c.Guid(nullable: false),
                        Pontuacao = c.Int(nullable: false),
                        Posicao = c.Int(nullable: false),
                        Resultado = c.String(nullable: false, maxLength: 8000, unicode: false),
                        Naturalidade = c.String(nullable: false, maxLength: 100, unicode: false),
                        Pai = c.String(nullable: false, maxLength: 100, unicode: false),
                        OrgaoEmissor = c.String(nullable: false, maxLength: 100, unicode: false),
                        EstadoCivil = c.Int(nullable: false),
                        DataNascimento = c.DateTime(nullable: false),
                        Filhos = c.Int(nullable: false),
                        Deficiente = c.Boolean(nullable: false),
                        Deficiencia = c.String(nullable: false, maxLength: 100, unicode: false),
                        CondicaoEspecial = c.String(nullable: false, maxLength: 100, unicode: false),
                        Afro = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ConvocadoId);
            
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
            DropForeignKey("dbo.Documentos", "ProcessoId", "dbo.Processos");
            DropForeignKey("dbo.Processos", "ClienteId", "dbo.Clientes");
            DropForeignKey("dbo.Cargos", "ProcessoId", "dbo.Processos");
            DropIndex("dbo.Telefone", new[] { "PessoaId_PessoaId" });
            DropIndex("dbo.Documentos", new[] { "ProcessoId" });
            DropIndex("dbo.Processos", new[] { "ClienteId" });
            DropIndex("dbo.Cargos", new[] { "ProcessoId" });
            DropTable("dbo.Admin");
            DropTable("dbo.Usuario");
            DropTable("dbo.Telefone");
            DropTable("dbo.PrimeiroAcesso");
            DropTable("dbo.Pessoa");
            DropTable("dbo.Convocados");
            DropTable("dbo.Convocacoes");
            DropTable("dbo.Documentos");
            DropTable("dbo.Clientes");
            DropTable("dbo.Processos");
            DropTable("dbo.Cargos");
        }
    }
}
