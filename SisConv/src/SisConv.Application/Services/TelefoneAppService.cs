using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using AutoMapper;
using SisConv.Application.Interfaces.Repository;
using SisConv.Application.ViewModels;
using SisConv.Domain.Entities;
using SisConv.Domain.Interfaces.Repositories;
using SisConv.Domain.Interfaces.Services;

namespace SisConv.Application.Services
{
    public class TelefoneAppService : ApplicationService, ITelefoneAppService
    {
        private readonly ITelefoneService _telefoneService;

        public TelefoneAppService(IUnitOfWork unitOfWork, ITelefoneService telefoneService) : base(unitOfWork)
        {
            _telefoneService = telefoneService;
        }

        public void Dispose()
        {
            _telefoneService.Dispose();
        }

        public TelefoneViewModel Add(TelefoneViewModel obj)
        {
            var telefone = Mapper.Map<TelefoneViewModel, Telefone>(obj);
            BeginTransaction();
            _telefoneService.Add(telefone);
            Commit();
            return obj;
        }

        public TelefoneViewModel GetById(Guid id)
        {
            return Mapper.Map<Telefone, TelefoneViewModel>(_telefoneService.GetById(id));
        }

        public IEnumerable<TelefoneViewModel> GetAll()
        {
            return Mapper.Map<IEnumerable<Telefone>, IEnumerable<TelefoneViewModel>>(_telefoneService.GetAll());
        }

        public TelefoneViewModel Update(TelefoneViewModel obj)
        {
            BeginTransaction();
            _telefoneService.Update(Mapper.Map<TelefoneViewModel, Telefone>(obj));
            Commit();
            return obj;
        }

        public void Remove(Guid id)
        {
            BeginTransaction();
            _telefoneService.Remove(id);
            Commit();
        }

        public IEnumerable<TelefoneViewModel> Search(Expression<Func<Telefone, bool>> predicate)
        {
            return Mapper.Map<IEnumerable<Telefone>, IEnumerable<TelefoneViewModel>>(
                _telefoneService.Search(predicate));
        }

        public TelefoneViewModel GetOne(Expression<Func<Telefone, bool>> predicate)
        {
            return Mapper.Map<Telefone, TelefoneViewModel>(_telefoneService.GetOne(predicate));
        }
    }
}