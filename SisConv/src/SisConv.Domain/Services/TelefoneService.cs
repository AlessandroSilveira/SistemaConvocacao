using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using SisConv.Domain.Entities;
using SisConv.Domain.Interfaces.Repositories;
using SisConv.Domain.Interfaces.Services;

namespace SisConv.Domain.Services
{
    public class TelefoneService : ITelefoneService
    {
        private readonly ITelefoneRepository _telefoneRepository;

        public TelefoneService(ITelefoneRepository telefoneRepository)
        {
            _telefoneRepository = telefoneRepository;
        }

        public void Dispose()
        {
            _telefoneRepository.Dispose();
            GC.SuppressFinalize(this);
        }

        public Telefone Add(Telefone obj)
        {
            return _telefoneRepository.Add(obj);
        }

        public Telefone GetById(Guid id)
        {
            return _telefoneRepository.GetById(id);
        }

        public IEnumerable<Telefone> GetAll()
        {
            return _telefoneRepository.GetAll();
        }

        public Telefone Update(Telefone obj)
        {
            return _telefoneRepository.Update(obj);
        }

        public void Remove(Guid id)
        {
            _telefoneRepository.Remove(id);
        }

        public IEnumerable<Telefone> Search(Expression<Func<Telefone, bool>> predicate)
        {
            return _telefoneRepository.Search(predicate);
        }

        public Telefone GetOne(Expression<Func<Telefone, bool>> predicate)
        {
            return _telefoneRepository.GetOne(predicate);
        }
    }
}