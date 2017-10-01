using System;
using System.Collections.Generic;
using SisConv.Domain.Entities;
using SisConv.Domain.Interfaces.Repositories;
using SisConv.Domain.Interfaces.Services;

namespace SisConv.Domain.Services
{
    public class PessoaService : IPessoaService
    {
        private readonly IPessoaRepository _pessoaRepository;

        public PessoaService(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        public void Dispose()
        {
            _pessoaRepository.Dispose();
            GC.SuppressFinalize(this);
        }

        public Pessoa Add(Pessoa obj)
        {
            return _pessoaRepository.Add(obj);
        }

        public Pessoa GetById(Guid id)
        {
            return _pessoaRepository.GetById(id);
        }

        public IEnumerable<Pessoa> GetAll()
        {
            return _pessoaRepository.GetAll();
        }

        public Pessoa Update(Pessoa obj)
        {
            return _pessoaRepository.Update(obj);
        }

        public void Remove(Guid id)
        {
            _pessoaRepository.Remove(id);
        }
    }
}