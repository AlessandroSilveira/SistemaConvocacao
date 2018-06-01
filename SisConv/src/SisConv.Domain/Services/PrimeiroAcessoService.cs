using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using SisConv.Domain.Entities;
using SisConv.Domain.Interfaces.Repositories;
using SisConv.Domain.Interfaces.Services;

namespace SisConv.Domain.Services
{
	public class PrimeiroAcessoService : IPrimeiroAcessoService
	{
		private readonly IPrimeiroAcessoRepository _primeiroAcessoRepository;

		public PrimeiroAcessoService(IPrimeiroAcessoRepository primeiroAcessoRepository)
		{
			_primeiroAcessoRepository = primeiroAcessoRepository;
		}

		public void Dispose()
		{
			_primeiroAcessoRepository.Dispose();
			GC.SuppressFinalize(this);
		}

		public PrimeiroAcesso Add(PrimeiroAcesso obj)
		{
			return _primeiroAcessoRepository.Add(obj);
		}

		public PrimeiroAcesso GetById(Guid id)
		{
			return _primeiroAcessoRepository.GetById(id);
		}

		public IEnumerable<PrimeiroAcesso> GetAll()
		{
			return _primeiroAcessoRepository.GetAll();
		}

		public PrimeiroAcesso Update(PrimeiroAcesso obj)
		{
			return _primeiroAcessoRepository.Update(obj);
		}

		public void Remove(Guid id)
		{
			_primeiroAcessoRepository.Remove(id);
		}

	    public IEnumerable<PrimeiroAcesso> Search(Expression<Func<PrimeiroAcesso, bool>> predicate)
	    {
	        return _primeiroAcessoRepository.Search(predicate);
	    }

		public PrimeiroAcesso GetOne(Expression<Func<PrimeiroAcesso, bool>> predicate)
		{
			return _primeiroAcessoRepository.GetOne(predicate);
		}
	}
}
