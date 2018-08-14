using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using SisConv.Domain.Entities;

namespace SisConv.Domain.Interfaces.Services
{
    public interface IUsuarioService : IDisposable
    {
        Usuario Add(Usuario obj);
        Usuario GetById(Guid id);
        IEnumerable<Usuario> GetAll();
        Usuario Update(Usuario obj);
        void Remove(Guid id);
        IEnumerable<Usuario> Search(Expression<Func<Usuario, bool>> predicate);
        Usuario GetOne(Expression<Func<Usuario, bool>> predicate);
    }
}