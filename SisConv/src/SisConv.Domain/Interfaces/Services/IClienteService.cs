using System;
using System.Collections.Generic;
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
    }
}