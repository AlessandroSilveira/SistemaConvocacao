using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using SisConv.Application.Interfaces.Repository;
using SisConv.Application.ViewModels;
using SisConv.Domain.Entities;
using SisConv.Domain.Interfaces.Repositories;
using SisConv.Domain.Interfaces.Services;

namespace SisConv.Application.Services
{
    public class DadosConvocadosAppService : ApplicationService, IDadosConvocacaoAppService
    {
        private readonly IDadosConvocadosService _dadosConvocadosService;

        public DadosConvocadosAppService(IUnitOfWork unitOfWork, IDadosConvocadosService dadosConvocadosService) : base(unitOfWork)
        {
            _dadosConvocadosService = dadosConvocadosService;
        }

        public void Dispose()
        {
            _dadosConvocadosService.Dispose();
        }

        public DadosConvocadosViewModel Add(DadosConvocadosViewModel obj)
        {
            var convocado = Mapper.Map<DadosConvocadosViewModel, Convocado>(obj);
            BeginTransaction();
            _dadosConvocadosService.Add(convocado);
            Commit();
            return obj;
        }

        public DadosConvocadosViewModel GetById(Guid id)
        {
            return Mapper.Map<Convocado, DadosConvocadosViewModel>(_dadosConvocadosService.GetById(id));
        }

        public IEnumerable<DadosConvocadosViewModel> GetAll()
        {
            return Mapper.Map<IEnumerable<Convocado>, IEnumerable<DadosConvocadosViewModel>>(_dadosConvocadosService.GetAll());
        }

        public DadosConvocadosViewModel Update(DadosConvocadosViewModel obj)
        {
            BeginTransaction();
            _dadosConvocadosService.Update(Mapper.Map<DadosConvocadosViewModel, Convocado>(obj));
            Commit();
            return obj;
        }

        public void Remove(Guid id)
        {
            BeginTransaction();
            _dadosConvocadosService.Remove(id);
            Commit();
        }

        public IEnumerable<DadosConvocadosViewModel> Search(Expression<Func<Convocado, bool>> predicate)
        {
            return Mapper.Map<IEnumerable<Convocado>, IEnumerable<DadosConvocadosViewModel>>(_dadosConvocadosService.Search(predicate));
        }
      
        public void SalvarCandidatos(Guid id, string file)
        {
			BeginTransaction();
			_dadosConvocadosService.SalvarCandidatos(id,file);
			Commit();
        }
    }
}