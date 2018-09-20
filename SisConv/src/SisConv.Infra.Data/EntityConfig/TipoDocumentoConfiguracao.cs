using SisConv.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace SisConv.Infra.Data.EntityConfig
{
    public class TipoDocumentoConfiguracao : EntityTypeConfiguration<TipoDocumento>
    {
        public TipoDocumentoConfiguracao()
        {
            HasKey(c => c.TipoDocumentoId);

            Property(c => c.TipoDocumentoId)
                .HasColumnName("TipoDocumentoId");

            Property(c => c.ProcessoId)
                .IsRequired();

            Property(c => c.TipoDocumentos)
                .IsRequired()
                .HasMaxLength(100);

            Property(c => c.Ativo)
                .IsRequired();

            ToTable("TipoDocumento");
        }
    }
}