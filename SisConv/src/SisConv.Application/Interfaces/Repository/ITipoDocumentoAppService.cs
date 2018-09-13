using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using SisConv.Application.ViewModels;
using SisConv.Domain.Entities;

namespace SisConv.Application.Interfaces.Repository
{
    public interface ITipoDocumentoAppService : IDisposable
    {
        TipoDocumentoViewModel Add(TipoDocumentoViewModel obj);

        TipoDocumentoViewModel GetById(Guid id);

        IEnumerable<TipoDocumentoViewModel> GetAll();

        TipoDocumentoViewModel Update(TipoDocumentoViewModel obj);

        void Remove(Guid id);

        IEnumerable<TipoDocumentoViewModel> Search(Expression<Func<TipoDocumento, bool>> predicate);

        TipoDocumentoViewModel GetOne(Expression<Func<TipoDocumento, bool>> predicate);
    }
}