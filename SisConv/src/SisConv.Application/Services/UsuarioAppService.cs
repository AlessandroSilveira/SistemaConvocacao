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
    public class UsuarioAppService : ApplicationService, IUsuarioAppService
    {
        private readonly IUsuarioService _usuarioService;
	   
        public UsuarioAppService(IUnitOfWork unitOfWork, IUsuarioService usuarioService) : base(unitOfWork)
        {
	        _usuarioService = usuarioService;
	      
        }

        public void Dispose()
        {
            _usuarioService.Dispose();
        }

        public UsuarioViewModel Add(UsuarioViewModel obj)
        {
            var telefone = Mapper.Map<UsuarioViewModel, Usuario>(obj);
            BeginTransaction();
            _usuarioService.Add(telefone);
            Commit();
            return obj;
        }

        public UsuarioViewModel GetById(Guid id)
        {
            return Mapper.Map<Usuario, UsuarioViewModel>(_usuarioService.GetById(id));
        }

        public IEnumerable<UsuarioViewModel> GetAll()
        {
            return Mapper.Map<IEnumerable<Usuario>, IEnumerable<UsuarioViewModel>>(_usuarioService.GetAll());
        }

        public UsuarioViewModel Update(UsuarioViewModel obj)
        {
            BeginTransaction();
            _usuarioService.Update(Mapper.Map<UsuarioViewModel, Usuario>(obj));
            Commit();
            return obj;
        }

        public void Remove(Guid id)
        {
            BeginTransaction();
            _usuarioService.Remove(id);
            Commit();
        }

        public IEnumerable<UsuarioViewModel> Search(Expression<Func<Usuario, bool>> predicate)
        {
            return Mapper.Map<IEnumerable<Usuario>, IEnumerable<UsuarioViewModel>>(_usuarioService.Search(predicate));
        }
    }
}