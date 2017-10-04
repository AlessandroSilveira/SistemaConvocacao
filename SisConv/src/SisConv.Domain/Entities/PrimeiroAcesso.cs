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
		public bool primeiroAcesso { get; set; }
	}
}
