using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using SisConv.Application.ViewModels;
using SisConv.Domain.Entities;

namespace SisConv.Application.Interfaces.Repository
{
    public interface ITelefoneAppService : IDisposable
    {
        TelefoneViewModel Add(TelefoneViewModel obj);
        TelefoneViewModel GetById(Guid id);
        IEnumerable<TelefoneViewModel> GetAll();
        TelefoneViewModel Update(TelefoneViewModel obj);
        void Remove(Guid id);
        IEnumerable<TelefoneViewModel> Search(Expression<Func<Telefone, bool>> predicate);
		TelefoneViewModel GetOne(Expression<Func<Telefone, bool>> predicate);
	}
}