using System.Data.Entity.Migrations;

namespace SisConv.Infra.Data.Migrations
{
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                    "dbo.Cargos",
                    c => new
                    {
                        CargoId = c.Guid(false, true),
                        ProcessoId = c.Guid(false),
                        Nome = c.String(false, 100, unicode: false),
                        CodigoCargo = c.String(false, 4, unicode: false),
                        Ativo = c.Boolean(false)
                    })
                .PrimaryKey(t => t.CargoId)
                .ForeignKey("dbo.Processos", t => t.ProcessoId)
                .Index(t => t.ProcessoId);

            CreateTable(
                    "dbo.Processos",
                    c => new
                    {
                        ProcessoId = c.Guid(false, true),
                        ClienteId = c.Guid(false),
                        Nome = c.String(false, 100, unicode: false),
                        DataCriacao = c.DateTime(false),
                        TextoDeAceitacaoDaConvocacao = c.String(false, 200, unicode: false),
                        TextoInicialTelaConvocado = c.String(false, 200, unicode: false),
                        TextoParaDesistentes = c.String(false, 200, unicode: false),
                        Ativo = c.Boolean(false)
                    })
                .PrimaryKey(t => t.ProcessoId)
                .ForeignKey("dbo.Clientes", t => t.ClienteId)
                .Index(t => t.ClienteId);

            CreateTable(
                    "dbo.Clientes",
                    c => new
                    {
                        ClienteId = c.Guid(false, true),
                        Nome = c.String(false, 100, unicode: false),
                        Cnpj = c.String(false, 15, unicode: false),
                        Email = c.String(false, 100, unicode: false),
                        Telefone = c.String(false, 20, unicode: false),
                        Imagem = c.String(false, 8000, unicode: false),
                        Ativo = c.Boolean(false),
                        Password = c.String(false, 10, unicode: false),
                        ConfirmPassword = c.String(maxLength: 8000, unicode: false)
                    })
                .PrimaryKey(t => t.ClienteId);

            CreateTable(
                    "dbo.Documentos",
                    c => new
                    {
                        DocumentoId = c.Guid(false),
                        ProcessoId = c.Guid(false),
                        Descricao = c.String(false, 100, unicode: false),
                        DataCriacao = c.DateTime(false),
                        Path = c.String(false, 200, unicode: false),
                        Ativo = c.Boolean(false)
                    })
                .PrimaryKey(t => t.DocumentoId)
                .ForeignKey("dbo.Processos", t => t.ProcessoId)
                .Index(t => t.ProcessoId);

            CreateTable(
                    "dbo.Convocacoes",
                    c => new
                    {
                        ConvocacaoId = c.Guid(false, true),
                        ProcessoId = c.Guid(false),
                        ConvocadoId = c.Guid(false),
                        DataEntregaDocumentos = c.DateTime(false),
                        HorarioEntregaDocumento = c.String(false, 8000, unicode: false),
                        EnderecoEntregaDocumento = c.String(false, 150, unicode: false),
                        EnviouEmail = c.Boolean(false),
                        Desistente = c.String(maxLength: 1, unicode: false),
                        Ativo = c.Boolean(false),
                        StatusConvocacao = c.String(maxLength: 150, unicode: false),
                        StatusContratacao = c.String(maxLength: 150, unicode: false)
                    })
                .PrimaryKey(t => t.ConvocacaoId);

            CreateTable(
                    "dbo.Convocados",
                    c => new
                    {
                        ConvocadoId = c.Guid(false, true),
                        ProcessoId = c.Guid(false),
                        Inscricao = c.String(false, 10, unicode: false),
                        Nome = c.String(false, 100, unicode: false),
                        Mae = c.String(false, 100, unicode: false),
                        Sexo = c.String(false, 8000, unicode: false),
                        Nascimento = c.String(false, 8000, unicode: false),
                        Documento = c.String(false, 50, unicode: false),
                        Cpf = c.String(false, 11, unicode: false),
                        Email = c.String(false, 100, unicode: false),
                        Telefone = c.String(false, 20, unicode: false),
                        Celular = c.String(false, 20, unicode: false),
                        Endereco = c.String(false, 100, unicode: false),
                        Numero = c.String(false, 50, unicode: false),
                        Complemento = c.String(false, 100, unicode: false),
                        Bairro = c.String(false, 100, unicode: false),
                        Cidade = c.String(false, 50, unicode: false),
                        Uf = c.String(false, 2, unicode: false),
                        Cep = c.String(false, 8, unicode: false),
                        Cargo = c.String(false, 100, unicode: false),
                        CargoId = c.Guid(false),
                        Pontuacao = c.Int(false),
                        Posicao = c.Int(false),
                        Resultado = c.String(false, 8000, unicode: false),
                        Naturalidade = c.String(false, 100, unicode: false),
                        Pai = c.String(false, 100, unicode: false),
                        OrgaoEmissor = c.String(false, 100, unicode: false),
                        EstadoCivil = c.Int(false),
                        DataNascimento = c.DateTime(false),
                        Filhos = c.Int(false),
                        Deficiente = c.Boolean(false),
                        Deficiencia = c.String(false, 100, unicode: false),
                        CondicaoEspecial = c.String(false, 100, unicode: false),
                        Afro = c.Boolean(false)
                    })
                .PrimaryKey(t => t.ConvocadoId);

            CreateTable(
                    "dbo.Pessoa",
                    c => new
                    {
                        PessoaId = c.Guid(false, true),
                        Nome = c.String(false, 100, unicode: false),
                        Naturalidade = c.String(false, 100, unicode: false),
                        Mae = c.String(false, 100, unicode: false),
                        Pai = c.String(false, 100, unicode: false),
                        Documento = c.String(false, 30, unicode: false),
                        OrgaoEmissor = c.String(false, 10, unicode: false),
                        Sexo = c.Int(false),
                        EstadoCivil = c.Int(false),
                        DataNascimento = c.DateTime(false),
                        Filhos = c.Int(false),
                        Endereco = c.String(false, 100, unicode: false),
                        Numero = c.String(false, 6, unicode: false),
                        Complemento = c.String(false, 100, unicode: false),
                        Bairro = c.String(false, 100, unicode: false),
                        Cep = c.String(false, 8, unicode: false),
                        Cidade = c.String(false, 100, unicode: false),
                        Uf = c.String(false, 2, unicode: false),
                        Cargo = c.String(false, 6, unicode: false),
                        Deficiente = c.Boolean(false),
                        Deficiencia = c.String(false, 100, unicode: false),
                        CondicaoEspecial = c.String(false, 100, unicode: false),
                        Cpf = c.String(false, 11, unicode: false),
                        Email = c.String(false, 100, unicode: false),
                        Afro = c.Boolean(false)
                    })
                .PrimaryKey(t => t.PessoaId);

            CreateTable(
                    "dbo.PrimeiroAcesso",
                    c => new
                    {
                        PrimeiroAcessoId = c.Guid(false, true),
                        primeiroAcesso = c.Boolean(false)
                    })
                .PrimaryKey(t => t.PrimeiroAcessoId);

            CreateTable(
                    "dbo.Telefone",
                    c => new
                    {
                        TelefoneId = c.Guid(false, true),
                        Ddd = c.String(false, 2, unicode: false),
                        Numero = c.String(false, 11, unicode: false),
                        PessoaId_PessoaId = c.Guid()
                    })
                .PrimaryKey(t => t.TelefoneId)
                .ForeignKey("dbo.Pessoa", t => t.PessoaId_PessoaId)
                .Index(t => t.PessoaId_PessoaId);

            CreateTable(
                    "dbo.Usuario",
                    c => new
                    {
                        UsuarioId = c.Guid(false, true),
                        Nome = c.String(false, 100, unicode: false),
                        Email = c.String(false, 100, unicode: false),
                        Login = c.String(false, 20, unicode: false),
                        Senha = c.String(false, 10, unicode: false),
                        Perfil = c.String(false, 1, unicode: false),
                        Ativo = c.Boolean(false)
                    })
                .PrimaryKey(t => t.UsuarioId);

            CreateTable(
                    "dbo.Admin",
                    c => new
                    {
                        AdminId = c.Guid(false, true),
                        Nome = c.String(false, 100, unicode: false),
                        Email = c.String(false, 100, unicode: false),
                        Empresa = c.String(false, 50, unicode: false),
                        Cnpj = c.String(false, 15, unicode: false),
                        Telefone = c.String(false, 11, unicode: false),
                        Imagem = c.Binary(false),
                        Ativo = c.Boolean(false),
                        Senha = c.String(maxLength: 8000, unicode: false)
                    })
                .PrimaryKey(t => t.AdminId);
        }

        public override void Down()
        {
            DropForeignKey("dbo.Telefone", "PessoaId_PessoaId", "dbo.Pessoa");
            DropForeignKey("dbo.Documentos", "ProcessoId", "dbo.Processos");
            DropForeignKey("dbo.Processos", "ClienteId", "dbo.Clientes");
            DropForeignKey("dbo.Cargos", "ProcessoId", "dbo.Processos");
            DropIndex("dbo.Telefone", new[] {"PessoaId_PessoaId"});
            DropIndex("dbo.Documentos", new[] {"ProcessoId"});
            DropIndex("dbo.Processos", new[] {"ClienteId"});
            DropIndex("dbo.Cargos", new[] {"ProcessoId"});
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