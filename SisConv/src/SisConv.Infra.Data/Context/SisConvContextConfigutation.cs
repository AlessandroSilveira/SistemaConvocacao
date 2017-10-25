using System.Data.Entity.Migrations;

namespace SisConv.Infra.Data.Context
{
    public class SisConvContextConfigutation : DbMigrationsConfiguration<SisConvContext>
    {
        public SisConvContextConfigutation()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "SisConvContext";
        }
    }
}