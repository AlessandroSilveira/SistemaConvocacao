using System.Data.Entity.Migrations;

namespace SisConv.Infra.Data.Context
{
    public class SisConvContextConfiguration : DbMigrationsConfiguration<SisConvContext>
    {
        public SisConvContextConfiguration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "SisConvContext";
        }
    }
}