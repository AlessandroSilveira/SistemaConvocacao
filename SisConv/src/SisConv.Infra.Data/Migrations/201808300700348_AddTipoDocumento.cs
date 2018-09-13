namespace SisConv.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTipoDocumento : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DocumentoCandidato", "TipoDocumento", c => c.String(nullable: false, maxLength: 100, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DocumentoCandidato", "TipoDocumento");
        }
    }
}
