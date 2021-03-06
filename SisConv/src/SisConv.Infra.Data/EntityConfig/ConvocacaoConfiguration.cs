﻿using System.Data.Entity.ModelConfiguration;
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

            Property(c => c.ConvocadoId)
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

            Property(c => c.StatusConvocacao)
                .HasMaxLength(150);

            Property(c => c.StatusContratacao)
                .HasMaxLength(150);

            Property(c => c.EnviouEmail)
                .IsRequired();

            Property(c => c.Desistente)
                .HasMaxLength(1);

            ToTable("Convocacoes");
        }
    }
}