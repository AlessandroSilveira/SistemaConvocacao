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
    public class DocumentacaoAppService : ApplicationService, IDocumentacaoAppService
    {
        private readonly IDocumentacaoService _documentacaoService;

        public DocumentacaoAppService(IUnitOfWork unitOfWork, IDocumentacaoService documentacaoService) : base(
            unitOfWork)
        {
            _documentacaoService = documentacaoService;
        }

        public void Dispose()
        {
            _documentacaoService.Dispose();
        }

        public DocumentacaoViewModel Add(DocumentacaoViewModel obj)
        {
            var documento = Mapper.Map<DocumentacaoViewModel, Documentacao>(obj);
            BeginTransaction();
            _documentacaoService.Add(documento);
            Commit();
            return obj;
        }

        public DocumentacaoViewModel GetById(Guid id)
        {
            return Mapper.Map<Documentacao, DocumentacaoViewModel>(_documentacaoService.GetById(id));
        }

        public IEnumerable<DocumentacaoViewModel> GetAll()
        {
            return Mapper.Map<IEnumerable<Documentacao>, IEnumerable<DocumentacaoViewModel>>(
                _documentacaoService.GetAll());
        }

        public DocumentacaoViewModel Update(DocumentacaoViewModel obj)
        {
            BeginTransaction();
            _documentacaoService.Update(Mapper.Map<DocumentacaoViewModel, Documentacao>(obj));
            Commit();
            return obj;
        }

        public void Remove(Guid id)
        {
            BeginTransaction();
            _documentacaoService.Remove(id);
            Commit();
        }

        public IEnumerable<DocumentacaoViewModel> Search(Expression<Func<Documentacao, bool>> predicate)
        {
            return Mapper.Map<IEnumerable<Documentacao>, IEnumerable<DocumentacaoViewModel>>(
                _documentacaoService.Search(predicate));
        }

        public DocumentacaoViewModel GetOne(Expression<Func<Documentacao, bool>> predicate)
        {
            return Mapper.Map<Documentacao, DocumentacaoViewModel>(_documentacaoService.GetOne(predicate));
        }
    }
}