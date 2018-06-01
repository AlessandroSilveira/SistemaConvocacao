using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using SisConv.Application.ViewModels;
using SisConv.Domain.Entities;

namespace SisConv.Application.Interfaces.Repository
{
	public interface IPrimeiroAcessoAppService : IDisposable
	{
		PrimeiroAcessoViewModel Add(PrimeiroAcessoViewModel obj);
	    PrimeiroAcessoViewModel GetById(Guid id);
		IEnumerable<PrimeiroAcessoViewModel> GetAll();
		PrimeiroAcessoViewModel Update(PrimeiroAcessoViewModel obj);
		void Remove(Guid id);
	    IEnumerable<PrimeiroAcessoViewModel> Search(Expression<Func<PrimeiroAcesso, bool>> predicate);
		PrimeiroAcessoViewModel GetOne(Expression<Func<PrimeiroAcesso, bool>> predicate);
	}
}