using System;
using System.Collections.Generic;
using SisConv.Application.ViewModels;

namespace SisConv.Application.Interfaces.Repository
{
    public interface IClienteAppService : IDisposable
    {
        ClienteViewModel Add(ClienteViewModel obj);
        ClienteViewModel GetById(Guid id);
        IEnumerable<ClienteViewModel> GetAll();
        ClienteViewModel Update(ClienteViewModel obj);
        void Remove(Guid id);
    }
}