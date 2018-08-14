using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using AutoMapper;
using SisConv.Application.Interfaces.Repository;
using SisConv.Domain.Entities;
using SisConv.Domain.Interfaces.Repositories;
using SisConv.Domain.Interfaces.Services;

namespace SisConv.Application.Services
{
    public class TipoDocumentoAppService : ApplicationService, ITipoDocumentoAppService
    {
        private readonly ITipoDocumentoService _tipoDocumentoService;
        
        public TipoDocumentoAppService(IUnitOfWork unitOfWork, ITipoDocumentoService tipoDocumentoService) : base(unitOfWork)
        {
            _tipoDocumentoService = tipoDocumentoService;
        }

        public void Dispose()
        {
            _tipoDocumentoService.Dispose();
        }

        public TipoDocumentoViewModel Add(TipoDocumentoViewModel obj)
        {
            var dados = Mapper.Map<TipoDocumentoViewModel, TipoDocumento>(obj);
            BeginTransaction();
            _tipoDocumentoService.Add(dados);
            Commit();
            return obj;
        }

        public TipoDocumentoViewModel GetById(Guid id)
        {
            return Mapper.Map<TipoDocumento, TipoDocumentoViewModel>(_tipoDocumentoService.GetById(id));
        }

        public IEnumerable<TipoDocumentoViewModel> GetAll()
        {
            return Mapper.Map<IEnumerable<TipoDocumento>, IEnumerable<TipoDocumentoViewModel>>(_tipoDocumentoService.GetAll());

        }

        public TipoDocumentoViewModel Update(TipoDocumentoViewModel obj)
        {
            BeginTransaction();
            _tipoDocumentoService.Update(Mapper.Map<TipoDocumentoViewModel, TipoDocumento>(obj));
            Commit();
            return obj;
        }

        public void Remove(Guid id)
        {
            BeginTransaction();
            _tipoDocumentoService.Remove(id);
            Commit();
        }

        public IEnumerable<TipoDocumentoViewModel> Search(Expression<Func<TipoDocumento, bool>> predicate)
        {
            return Mapper.Map<IEnumerable<TipoDocumento>, IEnumerable<TipoDocumentoViewModel>>(
                _tipoDocumentoService.Search(predicate));
        }

        public TipoDocumentoViewModel GetOne(Expression<Func<TipoDocumento, bool>> predicate)
        {
            return Mapper.Map<TipoDocumento, TipoDocumentoViewModel>(
                _tipoDocumentoService.GetOne(predicate));
        }
    }
}