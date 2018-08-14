using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using SisConv.Domain.Entities;
using SisConv.Domain.Interfaces.Repositories;
using SisConv.Domain.Interfaces.Services;

namespace SisConv.Domain.Services
{
    public class TipoDocumentoService : ITipoDocumentoService
    {
        private readonly ITipoDocumentoRepository _tipoDocumentoRepository;

        public TipoDocumentoService(ITipoDocumentoRepository tipoDocumentoRepository)
        {
            _tipoDocumentoRepository = tipoDocumentoRepository;
        }
        public void Dispose()
        {
            _tipoDocumentoRepository.Dispose();
        }

        public TipoDocumento Add(TipoDocumento obj)
        {
            _tipoDocumentoRepository.Add(obj);
        }

        public TipoDocumento GetById(Guid id)
        {
            return _tipoDocumentoRepository.GetById(id);
        }

        public IEnumerable<TipoDocumento> GetAll()
        {
            return _tipoDocumentoRepository.GetAll();
        }

        public TipoDocumento Update(TipoDocumento obj)
        {
            return _tipoDocumentoRepository.Update(obj);
        }

        public void Remove(Guid id)
        {
            _tipoDocumentoRepository.Remove(id);
        }

        public IEnumerable<TipoDocumento> Search(Expression<Func<TipoDocumento, bool>> predicate)
        {
            return _tipoDocumentoRepository.Search(predicate);
        }

        public TipoDocumento GetOne(Expression<Func<TipoDocumento, bool>> predicate)
        {
            return _tipoDocumentoRepository.GetOne(predicate);
        }
    }
}