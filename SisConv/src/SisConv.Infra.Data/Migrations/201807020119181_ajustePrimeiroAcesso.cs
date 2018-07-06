namespace SisConv.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ajustePrimeiroAcesso : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PrimeiroAcesso", "Data", c => c.DateTime(nullable: false));
            AlterColumn("dbo.PrimeiroAcesso", "Email", c => c.String(nullable: false, maxLength: 200, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PrimeiroAcesso", "Email", c => c.String(nullable: false, maxLength: 8000, unicode: false));
            DropColumn("dbo.PrimeiroAcesso", "Data");
        }
    }
}
