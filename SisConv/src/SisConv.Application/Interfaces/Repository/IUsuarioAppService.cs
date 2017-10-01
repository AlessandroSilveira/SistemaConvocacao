using System;
using System.Collections.Generic;
using SisConv.Application.ViewModels;

namespace SisConv.Application.Interfaces.Repository
{
    public interface IUsuarioAppService : IDisposable
    {
        UsuarioViewModel Add(UsuarioViewModel obj);
        UsuarioViewModel GetById(Guid id);
        IEnumerable<UsuarioViewModel> GetAll();
        UsuarioViewModel Update(UsuarioViewModel obj);
        void Remove(Guid id);
    }
}