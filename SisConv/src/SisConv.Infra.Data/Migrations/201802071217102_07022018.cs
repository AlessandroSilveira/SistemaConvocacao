namespace SisConv.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _07022018 : DbMigration
    {
        public override void Up()
        {
           
            AddColumn("dbo.Convocacoes", "StatusContratacao", c => c.String(maxLength: 150, unicode: false));
        }
        
        public override void Down()
        {
           
          
        }
    }
}
