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
            
            Property(c => c.ProcessoId)
                .IsRequired();

            Property(c => c.PessoaId)
                .IsRequired();

            Property(c => c.Ativo)
                .IsRequired();

            Property(c => c.DataEntregaDocumentos)
                .IsRequired();

            Property(c => c.HorarioEntregaDocumento)
                .IsRequired();

            Property(c => c.EnderecoEntregaDocumento)
                .HasMaxLength(150)
                .IsRequired();

            Property(c => c.EnviouEmail)
                .IsRequired();

            Property(c => c.Desistente)
                .IsRequired();

            ToTable("Convocacoes");
        }
    }
}