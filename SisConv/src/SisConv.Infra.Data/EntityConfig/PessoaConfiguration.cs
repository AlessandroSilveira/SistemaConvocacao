using System.Data.Entity.ModelConfiguration;
using SisConv.Domain.Entities;

namespace SisConv.Infra.Data.EntityConfig
{
    public class PessoaConfiguration : EntityTypeConfiguration<Pessoa>
    {
        public PessoaConfiguration()
        {
            HasKey(c => c.PessoaId);

            Property(c => c.PessoaId)
                .HasColumnName("PessoaId");

            Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(100);

            Property(c => c.Naturalidade)
                .IsRequired()
                .HasMaxLength(100);

            Property(c => c.Naturalidade)
                .IsRequired()
                .HasMaxLength(100);

            Property(c => c.Mae)
                .IsRequired()
                .HasMaxLength(100);

            Property(c => c.Pai)
                .IsRequired()
                .HasMaxLength(100);

            Property(c => c.Documento)
                .IsRequired()
                .HasMaxLength(30);

            Property(c => c.OrgaoEmissor)
                .IsRequired()
                .HasMaxLength(10);

            Property(c => c.Sexo)
                .IsRequired();

            Property(c => c.EstadoCivil)
                .IsRequired();

            Property(c => c.DataNascimento)
                .IsRequired();

            Property(c => c.Filhos)
                .IsRequired();

            Property(c => c.Endereco)
                .IsRequired()
                .HasMaxLength(100);

            Property(c => c.Numero)
                .IsRequired()
                .HasMaxLength(6);

            Property(c => c.Complemento)
                .IsRequired()
                .HasMaxLength(100);

            Property(c => c.Bairro)
                .IsRequired()
                .HasMaxLength(100);

            Property(c => c.Cep)
                .IsRequired()
                .HasMaxLength(8);

            Property(c => c.Cidade)
                .IsRequired()
                .HasMaxLength(100);

            Property(c => c.Uf)
                .IsRequired()
                .HasMaxLength(2);

            Property(c => c.Cargo)
                .IsRequired()
                .HasMaxLength(6);

            Property(c => c.Deficiente)
                .IsRequired();

            Property(c => c.Deficiencia)
                .IsRequired()
                .HasMaxLength(100);

            Property(c => c.CondicaoEspecial)
                .IsRequired()
                .HasMaxLength(100);

            Property(c => c.Cpf)
                .IsRequired()
                .HasMaxLength(11);

            Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(100);

            Property(c => c.Afro)
                .IsRequired();

            ToTable("Pessoa");
        }
    }
}