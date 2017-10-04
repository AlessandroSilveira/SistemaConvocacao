using System;
using System.Collections.Generic;
using AutoMapper;
using SisConv.Application.Interfaces.Repository;
using SisConv.Application.ViewModels;
using SisConv.Domain.Entities;
using SisConv.Domain.Interfaces.Repositories;
using SisConv.Domain.Interfaces.Services;

namespace SisConv.Application.Services
{
    public class PessoaAppService : ApplicationService , IPessoaAppService
    {
        private readonly IPessoaService _pessoaService;

        public PessoaAppService(IUnitOfWork unitOfWork, IPessoaService pessoaService) : base(unitOfWork)
        {
            _pessoaService = pessoaService;
        }

        public void Dispose()
        {
            _pessoaService.Dispose();
        }

        public PessoaViewModel Add(PessoaViewModel obj)
        {
            var pessoa = Mapper.Map<PessoaViewModel, Pessoa>(obj);
            BeginTransaction();
            _pessoaService.Add(pessoa);
            Commit();
            return obj;
        }

        public PessoaViewModel GetById(Guid id)
        {
            return Mapper.Map<Pessoa, PessoaViewModel>(_pessoaService.GetById(id));
        }

        public IEnumerable<PessoaViewModel> GetAll()
        {
            return Mapper.Map<IEnumerable<Pessoa>, IEnumerable<PessoaViewModel>>(_pessoaService.GetAll());
        }

        public PessoaViewModel Update(PessoaViewModel obj)
        {
            BeginTransaction();
            _pessoaService.Update(Mapper.Map<PessoaViewModel, Pessoa>(obj));
            Commit();
            return obj;
        }

        public void Remove(Guid id)
        {
            BeginTransaction();
            _pessoaService.Remove(id);
            Commit();
        }
    }
}