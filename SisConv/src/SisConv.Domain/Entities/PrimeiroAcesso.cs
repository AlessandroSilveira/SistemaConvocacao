using System;

namespace SisConv.Domain.Entities
{
	public class PrimeiroAcesso
	{
		public PrimeiroAcesso()
		{
			PrimeiroAcessoId = Guid.NewGuid();
		}

		public Guid PrimeiroAcessoId { get; set; }
		public Guid ConvocadoId { get; set; }
		public string Email { get; set; }
		public DateTime Data { get; set; }
	}
}
