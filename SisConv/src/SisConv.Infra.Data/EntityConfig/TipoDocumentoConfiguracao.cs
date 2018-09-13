using System.Data.Entity.ModelConfiguration;
using SisConv.Domain.Entities;

namespace SisConv.Infra.Data.EntityConfig
{
    public class TipoDocumentoConfiguracao : EntityTypeConfiguration<TipoDocumento>
    {
        public TipoDocumentoConfiguracao()
        {
            HasKey(c => c.TipoDocumentoId);

            Property(c => c.TipoDocumentoId)
                .HasColumnName("DocumentoCandidatoId");

            Property(c => c.TipoDocumentos)
                .IsRequired()
                .HasMaxLength(100);

            Property(c => c.Ativo)
                .IsRequired();

            ToTable("TipoDocumento");
        }
    }
}