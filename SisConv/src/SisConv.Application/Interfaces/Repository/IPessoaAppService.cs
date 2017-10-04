using System;
using System.Collections.Generic;
using SisConv.Application.ViewModels;

namespace SisConv.Application.Interfaces.Repository
{
    public interface IPessoaAppService : IDisposable
    {
        PessoaViewModel Add(PessoaViewModel obj);
        PessoaViewModel GetById(Guid id);
        IEnumerable<PessoaViewModel> GetAll();
        PessoaViewModel Update(PessoaViewModel obj);
        void Remove(Guid id);
    }
}