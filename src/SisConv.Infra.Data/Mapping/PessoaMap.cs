using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SisConv.Domain.Entities;
using SisConv.Infra.Data.Extensions;

namespace SisConv.Infra.Data.Mapping
{
	public class PessoaMap : EntityTypeConfiguration<Pessoa>
	{
		public override void Map(EntityTypeBuilder<Pessoa> builder)
		{
			//builder.HasKey(c => c.CampanhaId);
			//builder.Property(c => c.CampanhaId)
			//	.HasColumnName("CampanhaId");

			//builder.Property(c => c.DataInicio)
			//	.IsRequired();

			//builder.Property(c => c.DataCriacao)
			//	.IsRequired();

			//builder.Property(c => c.Nome)
			//	.IsRequired()
			//	.HasMaxLength(100)
			//	.HasColumnType("varchar(100)");

			//builder.Property(c => c.Status)
			//	.IsRequired();

			//builder.Property(c => c.TemplateId)
			//	.IsRequired();

			//builder.Property(c => c.Publico)
			//	.IsRequired();
		}
	}
}
