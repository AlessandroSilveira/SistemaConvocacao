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
                .HasMaxLength(100)
                .HasColumnType("varchar(100)");

            Property(c => c.Naturalidade)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("varchar(100)");

            Property(c => c.Naturalidade)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("varchar(100)");

            Property(c => c.Mae)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("varchar(100)");

            Property(c => c.Pai)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("varchar(100)");

            Property(c => c.Documento)
                .IsRequired()
                .HasMaxLength(30)
                .HasColumnType("varchar(30)");

            Property(c => c.OrgaoEmissor)
                .IsRequired()
                .HasMaxLength(10)
                .HasColumnType("varchar(10)");

            Property(c => c.Sexo)
                .IsRequired()
                .HasColumnType("bool");

            Property(c => c.EstadoCivil)
                .IsRequired()
                .HasColumnType("varchar(1)");

            Property(c => c.DataNascimento)
                .IsRequired()
                .HasColumnType("Datetime");

            Property(c => c.Filhos)
                .IsRequired();

            Property(c => c.Endereco)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("varchar(100)");

            Property(c => c.Numero)
                .IsRequired()
                .HasMaxLength(6)
                .HasColumnType("varchar(6)");

            Property(c => c.Complemento)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("varchar(100)");

            Property(c => c.Bairro)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("varchar(100)");

            Property(c => c.Cep)
                .IsRequired()
                .HasMaxLength(8)
                .HasColumnType("varchar(8)");

            Property(c => c.Cidade)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("varchar(100)");

            Property(c => c.Uf)
                .IsRequired()
                .HasMaxLength(2)
                .HasColumnType("varchar(2)");

            Property(c => c.Cargo)
                .IsRequired()
                .HasMaxLength(6)
                .HasColumnType("varchar(6)");

            Property(c => c.Deficiente)
                .IsRequired()
                .HasColumnType("bool");

            Property(c => c.Deficiencia)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("varchar(100)");

            Property(c => c.CondicaoEspecial)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("varchar(100)");

            Property(c => c.Cpf)
                .IsRequired()
                .HasMaxLength(11)
                .HasColumnType("varchar(11)");

            Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("varchar(100)");

            Property(c => c.Afro)
                .IsRequired()
                .HasColumnType("bool");

            ToTable("Pessoa");
        }
    }
}
