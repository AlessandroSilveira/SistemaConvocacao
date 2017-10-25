namespace SisConv.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cliente", "Password", c => c.String(nullable: false, maxLength: 10, unicode: false));
            AddColumn("dbo.Cliente", "ConfirmPassword", c => c.String(maxLength: 8000, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cliente", "ConfirmPassword");
            DropColumn("dbo.Cliente", "Password");
        }
    }
}
