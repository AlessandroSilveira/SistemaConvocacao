using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SisConv.Domain.Entities;

namespace SisConv.Infra.Data.Context
{
    public class SisConvContext : DbContext, IDbContext
    {
        public static IConfiguration Configuration { get; set; }

        public new DbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity
        {
            return base.Set<TEntity>();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // get the configuration from the app settings
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            // define the database to use
            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Pessoa> Empresas { get; set; }
        public DbSet<Telefone> Telefones { get; set; }
        public DbSet<Usuario> Templates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.AddConfiguration(new CampanhaMap());
            //modelBuilder.AddConfiguration(new EmpresaMap());
            //modelBuilder.AddConfiguration(new PessoaMap());
            //modelBuilder.AddConfiguration(new TemplateMap());
            //base.OnModelCreating(modelBuilder);
        }
    }
}
