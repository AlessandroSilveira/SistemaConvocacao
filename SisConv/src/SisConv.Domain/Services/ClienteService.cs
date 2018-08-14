using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using SisConv.Domain.Entities;
using SisConv.Domain.Interfaces.Repositories;
using SisConv.Domain.Interfaces.Services;

namespace SisConv.Domain.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public void Dispose()
        {
            _clienteRepository.Dispose();
            GC.SuppressFinalize(this);
        }

        public Cliente Add(Cliente obj)
        {
            return _clienteRepository.Add(obj);
        }

        public Cliente GetById(Guid id)
        {
            return _clienteRepository.GetById(id);
        }

        public IEnumerable<Cliente> GetAll()
        {
            return _clienteRepository.GetAll();
        }

        public Cliente Update(Cliente obj)
        {
            return _clienteRepository.Update(obj);
        }

        public void Remove(Guid id)
        {
            _clienteRepository.Remove(id);
        }

        public IEnumerable<Cliente> Search(Expression<Func<Cliente, bool>> predicate)
        {
            return _clienteRepository.Search(predicate);
        }

        public Cliente GetOne(Expression<Func<Cliente, bool>> predicate)
        {
            return _clienteRepository.GetOne(predicate);
        }
    }
}