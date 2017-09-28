using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SisConv.Domain.Entities;
using SisConv.Infra.Data.Extensions;

namespace SisConv.Infra.Data.Mapping
{
	public class PessoaMap : EntityTypeConfiguration<Pessoa>
	{
		public override void Map(EntityTypeBuilder<Pessoa> builder)
		{
			builder.HasKey(c => c.PessoaId);

            builder.Property(c => c.PessoaId)
                .HasColumnName("PessoaId");
            
            builder.Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("varchar(100)");

		    builder.Property(c => c.Naturalidade)
		        .IsRequired()
		        .HasMaxLength(100)
		        .HasColumnType("varchar(100)");

		    builder.Property(c => c.Naturalidade)
		        .IsRequired()
		        .HasMaxLength(100)
		        .HasColumnType("varchar(100)");

		    builder.Property(c => c.Mae)
		        .IsRequired()
		        .HasMaxLength(100)
		        .HasColumnType("varchar(100)");

		    builder.Property(c => c.Pai)
		        .IsRequired()
		        .HasMaxLength(100)
		        .HasColumnType("varchar(100)");

		    builder.Property(c => c.Documento)
		        .IsRequired()
		        .HasMaxLength(30)
		        .HasColumnType("varchar(30)");

		    builder.Property(c => c.OrgaoEmissor)
		        .IsRequired()
		        .HasMaxLength(10)
		        .HasColumnType("varchar(10)");

		    builder.Property(c => c.Sexo)
		        .IsRequired()
		        .HasMaxLength(1)
		        .HasColumnType("bool");

		    builder.Property(c => c.EstadoCivil)
		        .IsRequired()
		        .HasMaxLength(1)
		        .HasColumnType("varchar(1)");

		    builder.Property(c => c.DataNascimento)
		        .IsRequired()
		        .HasColumnType("Datetime");

		    builder.Property(c => c.Filhos)
		        .IsRequired();

		    builder.Property(c => c.Endereco)
		        .IsRequired()
		        .HasMaxLength(100)
                .HasColumnType("varchar(100)");

		    builder.Property(c => c.Numero)
		        .IsRequired()
		        .HasMaxLength(6)
		        .HasColumnType("varchar(6)");

		    builder.Property(c => c.Complemento)
		        .IsRequired()
		        .HasMaxLength(100)
		        .HasColumnType("varchar(100)");

		    builder.Property(c => c.Bairro)
		        .IsRequired()
		        .HasMaxLength(100)
		        .HasColumnType("varchar(100)");

		    builder.Property(c => c.Cep)
		        .IsRequired()
		        .HasMaxLength(8)
		        .HasColumnType("varchar(8)");

		    builder.Property(c => c.Cidade)
		        .IsRequired()
		        .HasMaxLength(100)
		        .HasColumnType("varchar(100)");

		    builder.Property(c => c.Uf)
		        .IsRequired()
		        .HasMaxLength(2)
		        .HasColumnType("varchar(2)");

		    builder.Property(c => c.Cargo)
		        .IsRequired()
		        .HasMaxLength(6)
		        .HasColumnType("varchar(6)");

		    builder.Property(c => c.Deficiente)
		        .IsRequired()
		        .HasMaxLength(1)
		        .HasColumnType("bool");

		    builder.Property(c => c.Deficiencia)
		        .IsRequired()
		        .HasMaxLength(100)
		        .HasColumnType("varchar(100)");

		    builder.Property(c => c.CondicaoEspecial)
		        .IsRequired()
		        .HasMaxLength(100)
		        .HasColumnType("varchar(100)");

		    builder.Property(c => c.Cpf)
		        .IsRequired()
		        .HasMaxLength(11)
		        .HasColumnType("varchar(11)");

		    builder.Property(c => c.Email)
		        .IsRequired()
		        .HasMaxLength(100)
		        .HasColumnType("varchar(100)");

		    builder.Property(c => c.Afro)
		        .IsRequired()
		        .HasMaxLength(1)
		        .HasColumnType("bool");

		    builder.ToTable("Pessoa");
		}
	}
}
