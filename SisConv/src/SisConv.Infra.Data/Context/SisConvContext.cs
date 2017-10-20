using SisConv.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
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


            //modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            //modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            //modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });

            base.OnModelCreating(modelBuilder);
        }


    }
}
