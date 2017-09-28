using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SisConv.Domain.Entities;
using SisConv.Infra.Data.Extensions;

namespace SisConv.Infra.Data.Mapping
{
    public class TelefoneMap : EntityTypeConfiguration<Telefone>
    {
        public override void Map(EntityTypeBuilder<Telefone> builder)
        {
            builder.HasKey(c => c.TelefoneId);

            builder.Property(c => c.TelefoneId)
                .HasColumnName("TelefoneId");

            builder.Property(c => c.PessoaId)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("varchar(100)");

            builder.Property(c => c.Ddd)
                .IsRequired()
                .HasMaxLength(2)
                .HasColumnType("varchar(2)");

            builder.Property(c => c.Numero)
                .IsRequired()
                .HasMaxLength(11)
                .HasColumnType("varchar(11)");

            builder.ToTable("Telefone");
        }
    }
}
