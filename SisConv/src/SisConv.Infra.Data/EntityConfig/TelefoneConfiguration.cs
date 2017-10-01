using System.Data.Entity.ModelConfiguration;
using SisConv.Domain.Entities;

namespace SisConv.Infra.Data.EntityConfig
{
    public class TelefoneConfiguration :  EntityTypeConfiguration<Telefone>
    {
        public TelefoneConfiguration()
        {
            HasKey(c => c.TelefoneId);

            Property(c => c.TelefoneId)
                .HasColumnName("TelefoneId");

            Property(c => c.Ddd)
                .IsRequired()
                .HasMaxLength(2)
                .HasColumnType("varchar(2)");

            Property(c => c.Numero)
                .IsRequired()
                .HasMaxLength(11)
                .HasColumnType("varchar(11)");

            ToTable("Telefone");
        }
    }
}
