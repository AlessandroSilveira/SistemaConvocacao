using System.Data.Entity.Migrations;
using SisConv.Infra.Data.Context;

namespace SisConv.Infra.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<SisConvContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(SisConvContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}