using System.Data.Entity.ModelConfiguration;
using SisConv.Domain.Entities;

namespace SisConv.Infra.Data.EntityConfig
{
    public class ConvocacaoConfiguration : EntityTypeConfiguration<Convocacao>
    {
        public ConvocacaoConfiguration()
        {
            HasKey(c => c.ConvocacaoId);

            Property(c => c.ConvocacaoId)
                .HasColumnName("ConvocacaoId");

            Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(100);

            Property(c => c.ClienteId)
                .IsRequired();

            Property(c => c.Ativo)
                .IsRequired();

            Property(c => c.DataCriacao)
                .IsRequired();

            ToTable("Convocacoes");
        }
    }
}