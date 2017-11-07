using System.Data.Entity.ModelConfiguration;
using SisConv.Domain.Entities;

namespace SisConv.Infra.Data.EntityConfig
{
	public class PrimeiroAcessoConfiguration : EntityTypeConfiguration<PrimeiroAcesso>
	{
		public PrimeiroAcessoConfiguration()
		{
			HasKey(c => c.PrimeiroAcessoId);

			Property(c => c.PrimeiroAcessoId)
				.HasColumnName("PrimeiroAcessoId");

			Property(c => c.primeiroAcesso)
				.IsRequired();

			ToTable("PrimeiroAcesso");
		}
	}
}