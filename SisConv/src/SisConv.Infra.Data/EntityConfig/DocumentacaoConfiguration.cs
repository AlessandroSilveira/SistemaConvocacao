using System.Data.Entity.ModelConfiguration;
using SisConv.Domain.Entities;

namespace SisConv.Infra.Data.EntityConfig
{
    public class DocumentacaoConfiguration : EntityTypeConfiguration<Documentacao>
    {
        public DocumentacaoConfiguration()
        {
            HasKey(c => c.DocumentoId);

            Property(c => c.DocumentoId)
                .HasColumnName("DocumentoId");

            Property(c => c.ProcessoId)
                .HasColumnName("ProcessoId");

            Property(c => c.Descricao)
                .IsRequired()
                .HasMaxLength(100);

            Property(c => c.Ativo)
                .IsRequired();

            Property(c => c.DataCriacao)
                .IsRequired();

            Property(c => c.Path)
                .HasMaxLength(200)
                .IsRequired();

            ToTable("Documentos");
        }
    }
}