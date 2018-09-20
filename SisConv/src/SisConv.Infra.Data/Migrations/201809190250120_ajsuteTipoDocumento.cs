namespace SisConv.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ajsuteTipoDocumento : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.TipoDocumento", name: "DocumentoCandidatoId", newName: "TipoDocumentoId");
            AddColumn("dbo.TipoDocumento", "ProcessoId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TipoDocumento", "ProcessoId");
            RenameColumn(table: "dbo.TipoDocumento", name: "TipoDocumentoId", newName: "DocumentoCandidatoId");
        }
    }
}
