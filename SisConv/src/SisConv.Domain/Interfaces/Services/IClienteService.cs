using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using SisConv.Domain.Entities;

namespace SisConv.Domain.Interfaces.Services
{
    public interface IClienteService : IDisposable
    {
        Cliente Add(Cliente obj);
        Cliente GetById(Guid id);
        IEnumerable<Cliente> GetAll();
        Cliente Update(Cliente obj);
        void Remove(Guid id);
        IEnumerable<Cliente> Search(Expression<Func<Cliente, bool>> predicate);
		Cliente GetOne(Expression<Func<Cliente, bool>> predicate);
	}
}