using System.Data.Entity.ModelConfiguration;
using SisConv.Domain.Entities;

namespace SisConv.Infra.Data.EntityConfig
{
    public class CargoConfiguration : EntityTypeConfiguration<Cargo>
    {
        public CargoConfiguration()
        {
            HasKey(c => c.CargoId);

            Property(c => c.CargoId)
                .HasColumnName("CargoId");

            Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(100);

            Property(c => c.CodigoCargo)
                .IsRequired()
                .HasMaxLength(4);

            Property(c => c.Ativo)
                .IsRequired();

            ToTable("Cargos");
        }
    }
}