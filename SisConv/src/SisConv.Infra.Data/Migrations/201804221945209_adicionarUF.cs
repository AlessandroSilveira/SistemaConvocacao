using System.Data.Entity.Migrations;

namespace SisConv.Infra.Data.Migrations
{
    public partial class adicionarUF : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Convocados", "Uf", c => c.String(false, 2, unicode: false));
            DropColumn("dbo.Convocados", "Estado");
        }

        public override void Down()
        {
            AddColumn("dbo.Convocados", "Estado", c => c.String(false, 2, unicode: false));
            DropColumn("dbo.Convocados", "Uf");
        }
    }
}