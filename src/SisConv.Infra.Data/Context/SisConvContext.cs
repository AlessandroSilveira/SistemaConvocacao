using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace SisConv.Infra.Data.Context
{
    public class SisConvContext : DbContext, IDbContext
    {
        public static IConfiguration Configuration { get; set; }

        public new DbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity
        {
            return base.Set<TEntity>();
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //    //=> optionsBuilder.UseSqlServer(Configuration.GetConnectionString("CrmConnection"));
        //    => optionsBuilder.UseSqlServer("Server=mssql.crm; Database=crm; User ID=sa; Password=nyom.crm-7410");
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // get the configuration from the app settings
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            // define the database to use
            Console.WriteLine(config.GetConnectionString("CrmConnection"));
            optionsBuilder.UseSqlServer(config.GetConnectionString("CrmConnection"));
        }

        public DbSet<CampanhaCrm> Campanhas { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Template> Templates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddConfiguration(new CampanhaMap());
            modelBuilder.AddConfiguration(new EmpresaMap());
            modelBuilder.AddConfiguration(new PessoaMap());
            modelBuilder.AddConfiguration(new TemplateMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
