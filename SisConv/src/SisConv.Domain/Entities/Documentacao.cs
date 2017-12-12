using System;

namespace SisConv.Domain.Entities
{
	public class Documentacao
	{
		public Documentacao()
		{
			DocumentoId = Guid.NewGuid();
		}

		public Guid DocumentoId { get; set; }
		public Guid ProcessoId { get; set; }
		public string Descricao { get; set; }
		public DateTime DataCriacao { get; set; }
		public string Path { get; set; }
		public bool Ativo { get; set; }
		public virtual Processo Processo{ get; set; }
	}
}