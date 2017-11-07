using System.Data.Entity.ModelConfiguration;
using SisConv.Domain.Entities;

namespace SisConv.Infra.Data.EntityConfig
{
    public class AdminConfiguracao : EntityTypeConfiguration<Admin>
    {
        public AdminConfiguracao()
        {
            HasKey(c => c.AdminId);

            Property(c => c.AdminId)
                .HasColumnName("AdminId");

            Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(100);

            Property(c => c.Cnpj)
                .IsRequired()
                .HasMaxLength(15);

            Property(c => c.Telefone)
                .IsRequired()
                .HasMaxLength(11);

            Property(c => c.Ativo)
                .IsRequired();

            Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(100);

            Property(c => c.Empresa)
                .IsRequired()
                .HasMaxLength(50);

	        Property(c => c.Imagem)
		        .IsRequired();

            ToTable("Admin");
        }
    }
}