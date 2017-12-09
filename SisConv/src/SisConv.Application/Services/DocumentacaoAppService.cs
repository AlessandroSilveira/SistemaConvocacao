using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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
		public DocumentacaoAppService(IUnitOfWork unitOfWork, IDocumentacaoService documentacaoService) : base(unitOfWork)
		{
			_documentacaoService = documentacaoService;
		}

		public void Dispose()
		{
			throw new NotImplementedException();
		}

		public DocumentacaoViewModel Add(DocumentacaoViewModel obj)
		{
			throw new NotImplementedException();
		}

		public DocumentacaoViewModel GetById(Guid id)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<DocumentacaoViewModel> GetAll()
		{
			throw new NotImplementedException();
		}

		public DocumentacaoViewModel Update(DocumentacaoViewModel obj)
		{
			throw new NotImplementedException();
		}

		public void Remove(Guid id)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<DocumentacaoViewModel> Search(Expression<Func<Documentacao, bool>> predicate)
		{
			throw new NotImplementedException();
		}
	}
}