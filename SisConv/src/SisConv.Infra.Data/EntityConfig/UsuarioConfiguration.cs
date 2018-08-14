using System.Data.Entity.ModelConfiguration;
using SisConv.Domain.Entities;

namespace SisConv.Infra.Data.EntityConfig
{
    public class UsuarioConfiguration : EntityTypeConfiguration<Usuario>
    {
        public UsuarioConfiguration()
        {
            HasKey(c => c.UsuarioId);

            Property(c => c.UsuarioId)
                .HasColumnName("UsuarioId");

            Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(100);

            Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(100);

            Property(c => c.Login)
                .IsRequired()
                .HasMaxLength(20);

            Property(c => c.Senha)
                .IsRequired()
                .HasMaxLength(10);

            Property(c => c.Perfil)
                .IsRequired()
                .HasMaxLength(1);

            Property(c => c.Ativo)
                .IsRequired();

            ToTable("Usuario");
        }
    }
}