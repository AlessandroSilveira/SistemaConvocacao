using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SisConv.Domain.Entities;
using SisConv.Infra.Data.Extensions;

namespace SisConv.Infra.Data.Mapping
{
    public class UsuarioMap : EntityTypeConfiguration<Usuario>
    {
        public override void Map(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(c => c.UsuarioId);

            builder.Property(c => c.UsuarioId)
                .HasColumnName("UsuarioId");

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("varchar(100)");

            builder.Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("varchar(100)");

            builder.Property(c => c.Login)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnType("varchar(20)");

            builder.Property(c => c.Senha)
                .IsRequired()
                .HasMaxLength(10)
                .HasColumnType("varchar(10)");

            builder.Property(c => c.Perfil)
                .IsRequired()
                .HasMaxLength(1)
                .HasColumnType("varchar(1)");

            builder.Property(c => c.Ativo)
                .IsRequired()
                .HasMaxLength(1)
                .HasColumnType("bool");
        }
    }
}
