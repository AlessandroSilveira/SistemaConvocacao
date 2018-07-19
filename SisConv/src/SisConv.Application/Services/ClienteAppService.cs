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
    public class ClienteAppService : ApplicationService , IClienteAppService
    {

        private readonly IClienteService _clienteService;
	   

		public ClienteAppService(IUnitOfWork unitOfWork, IClienteService clienteService) : base(unitOfWork)
        {
            _clienteService = clienteService;
	      
        }

        public void Dispose()
        {
           _clienteService.Dispose();
        }

        public ClienteViewModel Add(ClienteViewModel obj)
        {
            var cliente = Mapper.Map<ClienteViewModel, Cliente>(obj);
            BeginTransaction();
            _clienteService.Add(cliente);
            Commit();
            return obj;
        }

        public ClienteViewModel GetById(Guid id)
        {
            return Mapper.Map<Cliente, ClienteViewModel>(_clienteService.GetById(id));
        }

        public IEnumerable<ClienteViewModel> GetAll()
        {
            return Mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteViewModel>>(_clienteService.GetAll());
        }

        public ClienteViewModel Update(ClienteViewModel obj)
        {
            BeginTransaction();
            _clienteService.Update(Mapper.Map<ClienteViewModel, Cliente>(obj));
            Commit();
            return obj;
        }

        public void Remove(Guid id)
        {
            BeginTransaction();
            _clienteService.Remove(id);
            Commit();
        }

        public IEnumerable<ClienteViewModel> Search(Expression<Func<Cliente, bool>> predicate)
        {
            return Mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteViewModel>>(_clienteService.Search(predicate));
        }

		public ClienteViewModel GetOne(Expression<Func<Cliente, bool>> predicate)
		{
			return Mapper.Map<Cliente, ClienteViewModel>(_clienteService.GetOne(predicate));
		}
	}
}