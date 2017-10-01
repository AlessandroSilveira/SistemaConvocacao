using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                .HasMaxLength(100)
                .HasColumnType("varchar(100)");

            Property(c => c.Cnpj)
                .IsRequired()
                .HasMaxLength(15)
                .HasColumnType("varchar(15)");

            Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("varchar(100)");

            Property(c => c.Telefone)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnType("varchar(20)");

            ToTable("Cliente");
        }
    }
}
