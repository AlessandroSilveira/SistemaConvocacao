namespace SisConv.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first_migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        ClienteId = c.Guid(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100, unicode: false),
                        Cnpj = c.String(nullable: false, maxLength: 15, unicode: false),
                        Email = c.String(nullable: false, maxLength: 100, unicode: false),
                        Telefone = c.String(nullable: false, maxLength: 20, unicode: false),
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Telefone", "PessoaId_PessoaId", "dbo.Pessoa");
            DropIndex("dbo.Telefone", new[] { "PessoaId_PessoaId" });
            DropTable("dbo.Usuario");
            DropTable("dbo.Telefone");
            DropTable("dbo.Pessoa");
            DropTable("dbo.Cliente");
        }
    }
}
