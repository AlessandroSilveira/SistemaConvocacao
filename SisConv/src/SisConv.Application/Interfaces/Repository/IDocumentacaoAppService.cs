using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using SisConv.Application.ViewModels;
using SisConv.Domain.Entities;

namespace SisConv.Application.Interfaces.Repository
{
	public interface IDocumentacaoAppService : IDisposable
	{
		DocumentacaoViewModel Add(DocumentacaoViewModel obj);
		DocumentacaoViewModel GetById(Guid id);
		IEnumerable<DocumentacaoViewModel> GetAll();
		DocumentacaoViewModel Update(DocumentacaoViewModel obj);
		void Remove(Guid id);
		IEnumerable<DocumentacaoViewModel> Search(Expression<Func<Documentacao, bool>> predicate);
	}
}