using System;
using System.Collections.Generic;
using SisConv.Application.Interfaces.Repository;
using SisConv.Application.ViewModels;
using SisConv.Domain.Interfaces.Repositories;

namespace SisConv.Application.Services
{
	public class PrimeiroAcessoAppService : ApplicationService , IPrimeiroAcessoAppService
	{
		private readonly IPrimeiroAcessoAppService _primeiroAcessoAppService;
		public PrimeiroAcessoAppService(IUnitOfWork unitOfWork, IPrimeiroAcessoAppService primeiroAcessoAppService) : base(unitOfWork)
		{
			_primeiroAcessoAppService = primeiroAcessoAppService;
		}

		public void Dispose()
		{
			_primeiroAcessoAppService.Dispose();
		}

		public PrimeiroAcessoViewModel Add(PrimeiroAcessoViewModel obj)
		{
			return _primeiroAcessoAppService.Add(obj);
		}

		public PrimeiroAcessoViewModel GetById(Guid id)
		{
			return _primeiroAcessoAppService.GetById(id);
		}

		public IEnumerable<PrimeiroAcessoViewModel> GetAll()
		{
			return _primeiroAcessoAppService.GetAll();
		}

		public PrimeiroAcessoViewModel Update(PrimeiroAcessoViewModel obj)
		{
			return _primeiroAcessoAppService.Update(obj);
		}

		public void Remove(Guid id)
		{
			_primeiroAcessoAppService.Remove(id);
		}
	}
}