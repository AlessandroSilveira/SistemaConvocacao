namespace SisConv.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adicionarUF : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Convocados", "Uf", c => c.String(nullable: false, maxLength: 2, unicode: false));
            DropColumn("dbo.Convocados", "Estado");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Convocados", "Estado", c => c.String(nullable: false, maxLength: 2, unicode: false));
            DropColumn("dbo.Convocados", "Uf");
        }
    }
}
