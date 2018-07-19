using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using SisConv.Domain.Entities;

namespace SisConv.Domain.Interfaces.Services
{
    public interface IPessoaService : IDisposable
    {
        Pessoa Add(Pessoa obj);
        Pessoa GetById(Guid id);
        IEnumerable<Pessoa> GetAll();
        Pessoa Update(Pessoa obj);
        void Remove(Guid id);
        IEnumerable<Pessoa> Search(Expression<Func<Pessoa, bool>> predicate);
		Pessoa GetOne(Expression<Func<Pessoa, bool>> predicate);
	}
}