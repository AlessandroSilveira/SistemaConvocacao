using System.Data.Entity.ModelConfiguration;
using SisConv.Domain.Entities;

namespace SisConv.Infra.Data.EntityConfig
{
    public class ConvocadoConfiguration : EntityTypeConfiguration<Convocado>
    {
        public ConvocadoConfiguration()
        {
            HasKey(c => c.ConvocadoId);

            Property(c => c.ConvocadoId)
                .HasColumnName("ConvocadoId");

            Property(c => c.ProcessoId)
                .HasColumnName("ProcessoId");

            Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(100);

            Property(c => c.Inscricao)
                .IsRequired()
                .HasMaxLength(10);

            Property(c => c.Mae)
                .IsRequired()
                .HasMaxLength(100);

            Property(c => c.Sexo)
                .IsRequired();

            Property(c => c.Nascimento)
                .IsRequired();

            Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(100);

            Property(c => c.Documento)
                .IsRequired()
                .HasMaxLength(50);

            Property(c => c.Cpf)
                .IsRequired()
                .HasMaxLength(11);

            Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(100);

            Property(c => c.Telefone)
                .IsRequired()
                .HasMaxLength(20);

            Property(c => c.Celular)
                .IsRequired()
                .HasMaxLength(20);

            Property(c => c.Endereco)
                .IsRequired()
                .HasMaxLength(100);

            Property(c => c.Numero)
                .IsRequired()
                .HasMaxLength(50);

            Property(c => c.Complemento)
                .IsRequired()
                .HasMaxLength(100);

            Property(c => c.Bairro)
                .IsRequired()
                .HasMaxLength(100);

            Property(c => c.Cidade)
                .IsRequired()
                .HasMaxLength(50);

            Property(c => c.Uf)
                .IsRequired()
                .HasMaxLength(2);

            Property(c => c.Cep)
                .IsRequired()
                .HasMaxLength(8);

            Property(c => c.Cargo)
                .IsRequired()
                .HasMaxLength(100);

            Property(c => c.CargoId)
                .IsRequired();

            Property(c => c.Pontuacao)
                .IsRequired();

            Property(c => c.Posicao)
                .IsRequired();

            Property(c => c.Resultado)
                .IsRequired();

            ToTable("Convocados");
        }
    }
}