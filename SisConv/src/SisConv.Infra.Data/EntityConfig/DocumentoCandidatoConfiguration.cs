using System.Data.Entity.ModelConfiguration;
using SisConv.Domain.Entities;

namespace SisConv.Infra.Data.EntityConfig
{
    public class DocumentoCandidatoConfiguration : EntityTypeConfiguration<DocumentoCandidato>
    {
        public DocumentoCandidatoConfiguration()
        {
            HasKey(c => c.DocumentoCandidatoId);

            Property(c => c.DocumentoCandidatoId)
                .HasColumnName("DocumentoCandidatoId");

            Property(c => c.ProcessoId)
                .HasColumnName("ProcessoId");

            Property(c => c.ConvocadoId)
                .HasColumnName("ConvocadoId");

            Property(c => c.Documento)
                .IsRequired()
                .HasMaxLength(100);

            Property(c => c.Ativo)
                .IsRequired();

            Property(c => c.DataInclusao)
                .IsRequired();

            Property(c => c.Path)
                .HasMaxLength(200)
                .IsRequired();

            ToTable("DocumentoCandidato");
        }
    }
}