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
    public class ProcessoAppService : ApplicationService, IProcessoAppService
    {
        private readonly IProcessoService _processoService;

        public ProcessoAppService(IUnitOfWork unitOfWork, IProcessoService processoService) : base(unitOfWork)
        {
            _processoService = processoService;
        }

        public void Dispose()
        {
            _processoService.Dispose();
        }

        public ProcessoViewModel Add(ProcessoViewModel obj)
        {
            var admin = Mapper.Map<ProcessoViewModel, Processo>(obj);
            BeginTransaction();
            _processoService.Add(admin);
            Commit();
            return obj;
        }

        public ProcessoViewModel GetById(Guid id)
        {
            return Mapper.Map<Processo, ProcessoViewModel>(_processoService.GetById(id));
        }

        public IEnumerable<ProcessoViewModel> GetAll()
        {
            return Mapper.Map<IEnumerable<Processo>,IEnumerable<ProcessoViewModel> >(_processoService.GetAll());
        }

        public ProcessoViewModel Update(ProcessoViewModel obj)
        {
            BeginTransaction();
            _processoService.Update(Mapper.Map<ProcessoViewModel, Processo>(obj));
            Commit();
            return obj;
        }

        public void Remove(Guid id)
        {
            BeginTransaction();
            _processoService.Remove(id);
            Commit();
        }

        public IEnumerable<ProcessoViewModel> Search(Expression<Func<Processo, bool>> predicate)
        {
            return Mapper.Map<IEnumerable<Processo>, IEnumerable<ProcessoViewModel>>(_processoService.Search(predicate));
        }
    }
}