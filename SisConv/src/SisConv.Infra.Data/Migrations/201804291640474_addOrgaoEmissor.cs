namespace SisConv.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addOrgaoEmissor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Convocados", "OrgaoEmissor", c => c.String(nullable: false, maxLength: 10, unicode: false));
            AlterColumn("dbo.Convocados", "TelefoneIES", c => c.String(nullable: false, maxLength: 20, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Convocados", "TelefoneIES", c => c.String(nullable: false, maxLength: 100, unicode: false));
            DropColumn("dbo.Convocados", "OrgaoEmissor");
        }
    }
}
