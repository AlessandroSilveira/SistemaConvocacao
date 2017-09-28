using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SisConv.Domain.Entities;
using SisConv.Infra.Data.Extensions;

namespace SisConv.Infra.Data.Mapping
{
    public class ClienteMap : EntityTypeConfiguration<Cliente>
    {
        public override void Map(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(c => c.ClienteId);

            builder.Property(c => c.ClienteId)
                .HasColumnName("ClienteId");

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("varchar(100)");

            builder.Property(c => c.Cnpj)
                .IsRequired()
                .HasMaxLength(15)
                .HasColumnType("varchar(15)");

            builder.Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("varchar(100)");

            builder.Property(c => c.Telefone)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnType("varchar(20)");

            builder.ToTable("Cliente");
        }
    }
}