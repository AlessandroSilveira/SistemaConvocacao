namespace SisConv.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _12122017_2 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Documentos", newName: "Documentacao");
            AlterColumn("dbo.Documentacao", "Path", c => c.String(nullable: false, maxLength: 200, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Documentacao", "Path", c => c.String(nullable: false, maxLength: 100, unicode: false));
            RenameTable(name: "dbo.Documentacao", newName: "Documentos");
        }
    }
}
