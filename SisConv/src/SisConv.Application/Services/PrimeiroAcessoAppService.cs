using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using AutoMapper;
using SisConv.Application.Interfaces.Repository;
using SisConv.Application.ViewModels;
using SisConv.Domain.Entities;
using SisConv.Domain.Interfaces.Repositories;
using SisConv.Domain.Interfaces.Services;

namespace SisConv.Application.Services
{
	public class PrimeiroAcessoAppService : ApplicationService , IPrimeiroAcessoAppService
	{
	    private readonly IPrimeiroAcessoService _primeiroAcessoService;
		

	    public PrimeiroAcessoAppService(IUnitOfWork unitOfWork, IPrimeiroAcessoService primeiroAcessoService) : base(unitOfWork)
	    {
	        _primeiroAcessoService = primeiroAcessoService;
		    
	    }

	    public void Dispose()
	    {
	        _primeiroAcessoService.Dispose();
	    }

	    public PrimeiroAcessoViewModel Add(PrimeiroAcessoViewModel obj)
	    {
	        var primeiroAcesso = Mapper.Map<PrimeiroAcessoViewModel, PrimeiroAcesso>(obj);
	        BeginTransaction();
	        _primeiroAcessoService.Add(primeiroAcesso);
	        Commit();
	        return obj;
        }

	    public PrimeiroAcessoViewModel GetById(Guid id)
	    {
	        return Mapper.Map<PrimeiroAcesso, PrimeiroAcessoViewModel>(_primeiroAcessoService.GetById(id));
        }

	    public IEnumerable<PrimeiroAcessoViewModel> GetAll()
	    {
	        return Mapper.Map<IEnumerable<PrimeiroAcesso>, IEnumerable<PrimeiroAcessoViewModel>>(_primeiroAcessoService.GetAll());
        }

	    public PrimeiroAcessoViewModel Update(PrimeiroAcessoViewModel obj)
	    {
	        BeginTransaction();
	        _primeiroAcessoService.Update(Mapper.Map<PrimeiroAcessoViewModel, PrimeiroAcesso>(obj));
	        Commit();
	        return obj;
        }

	    public void Remove(Guid id)
	    {
	        BeginTransaction();
	        _primeiroAcessoService.Remove(id);
	        Commit();
        }

	    public IEnumerable<PrimeiroAcessoViewModel> Search(Expression<Func<PrimeiroAcesso, bool>> predicate)
	    {
	        return Mapper.Map<IEnumerable<PrimeiroAcesso>, IEnumerable<PrimeiroAcessoViewModel>>(_primeiroAcessoService.Search(predicate));
        }

		public PrimeiroAcessoViewModel GetOne(Expression<Func<PrimeiroAcesso, bool>> predicate)
		{
			return Mapper.Map<PrimeiroAcesso, PrimeiroAcessoViewModel>(_primeiroAcessoService.GetOne(predicate));
		}
	}
}