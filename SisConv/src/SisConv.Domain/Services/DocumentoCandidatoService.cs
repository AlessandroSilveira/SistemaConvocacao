using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using SisConv.Domain.Entities;
using SisConv.Domain.Interfaces.Repositories;
using SisConv.Domain.Interfaces.Services;

namespace SisConv.Domain
{
    public class DocumentoCandidatoService : IDocumentoCandidatoService
    {
        private readonly IDocumentoCandidatoRepository _documentoCandidatoRepository;

        public DocumentoCandidatoService(IDocumentoCandidatoRepository documentoCandidatoRepository)
        {
            _documentoCandidatoRepository = documentoCandidatoRepository;
        }
        
        public void Dispose()
        {
            _documentoCandidatoRepository.Dispose();
        }

        public DocumentoCandidato Add(DocumentoCandidato obj)
        {
            return _documentoCandidatoRepository.Add(obj);
        }

        public DocumentoCandidato GetById(Guid id)
        {
            return _documentoCandidatoRepository.GetById(id);
        }

        public IEnumerable<DocumentoCandidato> GetAll()
        {
            return _documentoCandidatoRepository.GetAll();
        }

        public DocumentoCandidato Update(DocumentoCandidato obj)
        {
            return _documentoCandidatoRepository.Update(obj);
        }

        public void Remove(Guid id)
        {
            _documentoCandidatoRepository.Remove(id);
        }

        public IEnumerable<DocumentoCandidato> Search(Expression<Func<DocumentoCandidato, bool>> predicate)
        {
            return _documentoCandidatoRepository.Search(predicate);
        }

        public DocumentoCandidato GetOne(Expression<Func<DocumentoCandidato, bool>> predicate)
        {
            return _documentoCandidatoRepository.GetOne(predicate);
        }
    }
}