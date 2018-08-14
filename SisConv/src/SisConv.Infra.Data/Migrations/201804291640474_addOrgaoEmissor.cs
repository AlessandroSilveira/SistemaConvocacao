using System.Data.Entity.Migrations;

namespace SisConv.Infra.Data.Migrations
{
    public partial class addOrgaoEmissor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Convocados", "OrgaoEmissor", c => c.String(false, 10, unicode: false));
            AlterColumn("dbo.Convocados", "TelefoneIES", c => c.String(false, 20, unicode: false));
        }

        public override void Down()
        {
            AlterColumn("dbo.Convocados", "TelefoneIES", c => c.String(false, 100, unicode: false));
            DropColumn("dbo.Convocados", "OrgaoEmissor");
        }
    }
}