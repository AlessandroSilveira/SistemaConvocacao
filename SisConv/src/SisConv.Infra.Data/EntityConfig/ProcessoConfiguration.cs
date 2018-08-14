using System.Data.Entity.ModelConfiguration;
using SisConv.Domain.Entities;

namespace SisConv.Infra.Data.EntityConfig
{
    public class ProcessoConfiguration : EntityTypeConfiguration<Processo>
    {
        public ProcessoConfiguration()
        {
            HasKey(c => c.ProcessoId);

            Property(c => c.ProcessoId)
                .HasColumnName("ProcessoId");

            Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(100);

            Property(c => c.ClienteId)
                .IsRequired();

            Property(c => c.Ativo)
                .IsRequired();

            Property(c => c.DataCriacao)
                .IsRequired();

            Property(c => c.TextoInicialTelaConvocado)
                .IsRequired()
                .HasMaxLength(200);

            Property(c => c.TextoDeAceitacaoDaConvocacao)
                .IsRequired()
                .HasMaxLength(200);

            Property(c => c.TextoParaDesistentes)
                .IsRequired()
                .HasMaxLength(200);

            ToTable("Processos");
        }
    }
}