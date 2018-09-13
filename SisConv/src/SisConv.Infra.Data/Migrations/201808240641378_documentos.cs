namespace SisConv.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class documentos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DocumentoCandidato",
                c => new
                    {
                        DocumentoCandidatoId = c.Guid(nullable: false, identity: true),
                        ProcessoId = c.Guid(nullable: false),
                        ConvocadoId = c.Guid(nullable: false),
                        Documento = c.String(nullable: false, maxLength: 100, unicode: false),
                        DataInclusao = c.DateTime(nullable: false),
                        Path = c.String(nullable: false, maxLength: 200, unicode: false),
                        Ativo = c.String(nullable: false, maxLength: 8000, unicode: false),
                    })
                .PrimaryKey(t => t.DocumentoCandidatoId);
            
            CreateTable(
                "dbo.TipoDocumento",
                c => new
                    {
                        DocumentoCandidatoId = c.Guid(nullable: false, identity: true),
                        TipoDocumentos = c.String(nullable: false, maxLength: 100, unicode: false),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.DocumentoCandidatoId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TipoDocumento");
            DropTable("dbo.DocumentoCandidato");
        }
    }
}
