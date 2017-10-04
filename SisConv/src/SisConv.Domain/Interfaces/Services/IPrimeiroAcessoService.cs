using System;
using System.Collections.Generic;
using SisConv.Domain.Entities;

namespace SisConv.Domain.Interfaces.Services
{
	public interface IPrimeiroAcessoService : IDisposable
	{
		PrimeiroAcesso Add(PrimeiroAcesso obj);
		PrimeiroAcesso GetById(Guid id);
		IEnumerable<PrimeiroAcesso> GetAll();
		PrimeiroAcesso Update(PrimeiroAcesso obj);
		void Remove(Guid id);
	}
}