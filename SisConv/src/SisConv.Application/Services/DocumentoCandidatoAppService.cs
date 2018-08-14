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
    public class DocumentoCandidatoAppService: ApplicationService, IDocumentoCandidatoAppService
    {

        private readonly IDocumentoCandidatoService _documentoCandidatoService;
        
        public DocumentoCandidatoAppService(IUnitOfWork unitOfWork,
            IDocumentoCandidatoService documentoCandidatoService) : base(unitOfWork)
        {
            _documentoCandidatoService = _documentoCandidatoService;
        }

        public void Dispose()
        {
            _documentoCandidatoService.Dispose();
        }

        public DocumentoCandidatoViewModel Add(DocumentoCandidatoViewModel obj)
        {
            var dados = Mapper.Map<DocumentoCandidatoViewModel, DocumentoCandidato>(obj);
            BeginTransaction();
            _documentoCandidatoService.Add(dados);
            Commit();
            return obj;
        }

        public DocumentoCandidatoViewModel GetById(Guid id)
        {
            return Mapper.Map< DocumentoCandidato, DocumentoCandidatoViewModel>(_documentoCandidatoService.GetById(id));
        }

        public IEnumerable<DocumentoCandidatoViewModel> GetAll()
        {
            return Mapper.Map<IEnumerable<DocumentoCandidato>, IEnumerable<DocumentoCandidatoViewModel>>(_documentoCandidatoService.GetAll());

        }

        public DocumentoCandidatoViewModel Update(DocumentoCandidatoViewModel obj)
        {
            BeginTransaction();
            _documentoCandidatoService.Update(Mapper.Map<DocumentoCandidatoViewModel, DocumentoCandidato>(obj));
            Commit();
            return obj;
        }

        public void Remove(Guid id)
        {
            BeginTransaction();
            _documentoCandidatoService.Remove(id);
            Commit();
        }

        public IEnumerable<DocumentoCandidatoViewModel> Search(Expression<Func<DocumentoCandidato, bool>> predicate)
        {
            return Mapper.Map<IEnumerable<DocumentoCandidato>, IEnumerable<DocumentoCandidatoViewModel>>(
                _documentoCandidatoService.Search(predicate));
        }

        public DocumentoCandidatoViewModel GetOne(Expression<Func<DocumentoCandidato, bool>> predicate)
        {
            return Mapper.Map<DocumentoCandidato, DocumentoCandidatoViewModel>(
                _documentoCandidatoService.GetOne(predicate));
        }
    }
}