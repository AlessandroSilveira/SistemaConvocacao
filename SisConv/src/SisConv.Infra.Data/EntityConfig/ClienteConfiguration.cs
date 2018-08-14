using System.Data.Entity.ModelConfiguration;
using SisConv.Domain.Entities;

namespace SisConv.Infra.Data.EntityConfig
{
    public class ClienteConfiguration : EntityTypeConfiguration<Cliente>
    {
        public ClienteConfiguration()
        {
            HasKey(c => c.ClienteId);

            Property(c => c.ClienteId)
                .HasColumnName("ClienteId");

            Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(100);

            Property(c => c.Cnpj)
                .IsRequired()
                .HasMaxLength(15);

            Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(100);

            Property(c => c.Telefone)
                .IsRequired()
                .HasMaxLength(20);

            Property(c => c.Password)
                .IsRequired()
                .HasMaxLength(10);

            Property(c => c.Imagem)
                .IsRequired();

            Property(c => c.Ativo)
                .IsRequired();

            ToTable("Clientes");
        }
    }
}