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
    public class ConvocacaoAppService : ApplicationService, IConvocacaoAppService
    {
        private readonly IConvocacaoService _convocacaoService;
	    

        public ConvocacaoAppService(IUnitOfWork unitOfWork, IConvocacaoService convocacaoService) : base(unitOfWork)
        {
            _convocacaoService = convocacaoService;
	        
        }

        public void Dispose()
        {
            _convocacaoService.Dispose();
        }

        public ConvocacaoViewModel Add(ConvocacaoViewModel obj)
        {
            var convocacao = Mapper.Map<ConvocacaoViewModel, Convocacao>(obj);
            BeginTransaction();
            _convocacaoService.Add(convocacao);
            Commit();
            return obj;
        }

        public ConvocacaoViewModel GetById(Guid id)
        {
            return Mapper.Map<Convocacao, ConvocacaoViewModel>(_convocacaoService.GetById(id));
        }

        public IEnumerable<ConvocacaoViewModel> GetAll()
        {
            return Mapper.Map<IEnumerable<Convocacao>, IEnumerable<ConvocacaoViewModel>>(_convocacaoService.GetAll());
        }

        public ConvocacaoViewModel Update(ConvocacaoViewModel obj)
        {
            BeginTransaction();
            _convocacaoService.Update(Mapper.Map<ConvocacaoViewModel, Convocacao>(obj));
            Commit();
            return obj;
        }

        public void Remove(Guid id)
        {
            BeginTransaction();
            _convocacaoService.Remove(id);
            Commit();
        }

        public IEnumerable<ConvocacaoViewModel> Search(Expression<Func<Convocacao, bool>> predicate)
        {
            return Mapper.Map<IEnumerable<Convocacao>, IEnumerable<ConvocacaoViewModel>>(
                _convocacaoService.Search(predicate));
        }

	    public string GerarSenhaUsuario()
	    {
		    return _convocacaoService.GerarSenha();
	    }

        public List<ConvocadoViewModel> MontaListaDeConvocados(IEnumerable<ConvocacaoViewModel> dadosConfirmados, IEnumerable<ConvocadoViewModel> convocados)
        {
            return _convocacaoService.MontarListaConvocado(dadosConfirmados, convocados);
        }
    }
}