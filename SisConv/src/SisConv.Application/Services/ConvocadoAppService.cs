using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web;
using AutoMapper;
using SisConv.Application.Interfaces.Repository;
using SisConv.Application.ViewModels;
using SisConv.Domain.Entities;
using SisConv.Domain.Interfaces.Repositories;
using SisConv.Domain.Interfaces.Services;

namespace SisConv.Application.Services
{
    public class ConvocadoAppService : ApplicationService ,IConvocadoAppService
    {
        private readonly IConvocadoService _convocadoService;
	    
        public ConvocadoAppService(IUnitOfWork unitOfWork, IConvocadoService convocadoService) : base(unitOfWork)
        {
	        _convocadoService = convocadoService;
	       
        }

        public void Dispose()
        {
            _convocadoService.Dispose();
        }

        public ConvocadoViewModel Add(ConvocadoViewModel obj)
        {
            var convocado = Mapper.Map<ConvocadoViewModel, Convocado>(obj);
            BeginTransaction();
            _convocadoService.Add(convocado);
            Commit();
            return obj;
        }

        public ConvocadoViewModel GetById(Guid id)
        {
            return Mapper.Map<Convocado, ConvocadoViewModel>(_convocadoService.GetById(id));
        }

        public IEnumerable<ConvocadoViewModel> GetAll()
        {
            return Mapper.Map<IEnumerable<Convocado>, IEnumerable<ConvocadoViewModel>>(_convocadoService.GetAll());
        }

        public ConvocadoViewModel Update(ConvocadoViewModel obj)
        {
            BeginTransaction();
            _convocadoService.Update(Mapper.Map<ConvocadoViewModel, Convocado>(obj));
            Commit();
            return obj;
        }

        public void Remove(Guid id)
        {
            BeginTransaction();
            _convocadoService.Remove(id);
            Commit();
        }

        public IEnumerable<ConvocadoViewModel> Search(Expression<Func<Convocado, bool>> predicate)
        {
            return Mapper.Map<IEnumerable<Convocado>, IEnumerable<ConvocadoViewModel>>(_convocadoService.Search(predicate));
        }

	    public bool VerificaSeHaSobrenome(string nome)
	    {
		    return _convocadoService.VerificaSeHaSobrenome(nome);

	    }

		public ConvocadoViewModel GetOne(Expression<Func<Convocado, bool>> predicate)
		{
			return Mapper.Map<Convocado, ConvocadoViewModel>(_convocadoService.GetOne(predicate));
		}
	}
}