using System;
using System.Collections.Generic;
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
    }
}