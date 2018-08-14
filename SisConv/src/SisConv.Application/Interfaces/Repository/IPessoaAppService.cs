using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using SisConv.Application.ViewModels;
using SisConv.Domain.Entities;

namespace SisConv.Application.Interfaces.Repository
{
    public interface IPessoaAppService : IDisposable
    {
        PessoaViewModel Add(PessoaViewModel obj);

        PessoaViewModel GetById(Guid id);

        IEnumerable<PessoaViewModel> GetAll();

        PessoaViewModel Update(PessoaViewModel obj);

        void Remove(Guid id);

        IEnumerable<PessoaViewModel> Search(Expression<Func<Pessoa, bool>> predicate);

        PessoaViewModel GetOne(Expression<Func<Pessoa, bool>> predicate);
    }
}