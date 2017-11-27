using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using SisConv.Domain.Entities;
using SisConv.Infra.Data.EntityConfig;

namespace SisConv.Infra.Data.Context
{
    public class SisConvContext : DbContext
    {
        public SisConvContext()
            : base("DefaultConnection")
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Pessoa> Pessoas { get; set; }
        public virtual DbSet<Telefone> Telefones { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<PrimeiroAcesso> PrimeiroAcessos { get; set; }
        public virtual DbSet<Convocacao> Convocacoes { get; set; }
        public virtual DbSet<Cargo> Cargos { get; set; }
        public virtual DbSet<Convocado> Convocados { get; set; }
        public virtual DbSet<Processo> Processos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity));
            modelBuilder.Properties<string>().Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Configurations.Add(new ClienteConfiguration());
            modelBuilder.Configurations.Add(new PessoaConfiguration());
            modelBuilder.Configurations.Add(new TelefoneConfiguration());
            modelBuilder.Configurations.Add(new UsuarioConfiguration());
            modelBuilder.Configurations.Add(new PrimeiroAcessoConfiguration());
            modelBuilder.Configurations.Add(new AdminConfiguracao());
            modelBuilder.Configurations.Add(new ProcessoConfiguration());
            modelBuilder.Configurations.Add(new CargoConfiguration());
            modelBuilder.Configurations.Add(new ConvocadoConfiguration());
            modelBuilder.Configurations.Add(new ConvocacaoConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}