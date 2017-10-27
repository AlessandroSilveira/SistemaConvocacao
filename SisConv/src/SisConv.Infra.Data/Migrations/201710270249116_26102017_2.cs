namespace SisConv.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _26102017_2 : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Convocacoes", "ClienteId", "dbo.Clientes");
            DropIndex("dbo.Convocacoes", new[] { "ClienteId" });
            DropTable("dbo.Convocacoes");
        }
    }
}
