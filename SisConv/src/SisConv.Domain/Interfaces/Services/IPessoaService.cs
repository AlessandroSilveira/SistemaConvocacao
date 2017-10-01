using System;
using System.Collections.Generic;
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
    }
}