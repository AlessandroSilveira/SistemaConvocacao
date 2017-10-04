using System;
using System.Collections.Generic;
using SisConv.Application.ViewModels;

namespace SisConv.Application.Interfaces.Repository
{
	public interface IPrimeiroAcessoAppService : IDisposable
	{
		PrimeiroAcessoViewModel Add(PrimeiroAcessoViewModel obj);
		PrimeiroAcessoViewModel GetById(Guid id);
		IEnumerable<PrimeiroAcessoViewModel> GetAll();
		PrimeiroAcessoViewModel Update(PrimeiroAcessoViewModel obj);
		void Remove(Guid id);
	}
}