using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using SisConv.Domain.Entities;

namespace SisConv.Domain.Interfaces.Services
{
    public interface IDocumentoCandidatoService : IDisposable
    {
        DocumentoCandidato Add(DocumentoCandidato obj);
        DocumentoCandidato GetById(Guid id);
        IEnumerable<DocumentoCandidato> GetAll();
        DocumentoCandidato Update(DocumentoCandidato obj);
        void Remove(Guid id);
        IEnumerable<DocumentoCandidato> Search(Expression<Func<DocumentoCandidato, bool>> predicate);
        DocumentoCandidato GetOne(Expression<Func<DocumentoCandidato, bool>> predicate);
    }
}