using System;
using System.Collections.Generic;
using SisConv.Application.ViewModels;

namespace SisConv.Application.Interfaces.Repository
{
    public interface ITelefoneAppService : IDisposable
    {
        TelefoneViewModel Add(TelefoneViewModel obj);
        TelefoneViewModel GetById(Guid id);
        IEnumerable<TelefoneViewModel> GetAll();
        TelefoneViewModel Update(TelefoneViewModel obj);
        void Remove(Guid id);
    }
}