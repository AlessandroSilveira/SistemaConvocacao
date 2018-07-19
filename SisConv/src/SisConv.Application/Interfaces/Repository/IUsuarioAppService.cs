using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using SisConv.Application.ViewModels;
using SisConv.Domain.Entities;

namespace SisConv.Application.Interfaces.Repository
{
    public interface IUsuarioAppService : IDisposable
    {
        UsuarioViewModel Add(UsuarioViewModel obj);
        UsuarioViewModel GetById(Guid id);
        IEnumerable<UsuarioViewModel> GetAll();
        UsuarioViewModel Update(UsuarioViewModel obj);
        void Remove(Guid id);
        IEnumerable<UsuarioViewModel> Search(Expression<Func<Usuario, bool>> predicate);
		UsuarioViewModel GetOne(Expression<Func<Usuario, bool>> predicate);
	}
}