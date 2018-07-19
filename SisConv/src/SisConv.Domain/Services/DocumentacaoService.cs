using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using SisConv.Domain.Entities;
using SisConv.Domain.Interfaces.Repositories;
using SisConv.Domain.Interfaces.Services;

namespace SisConv.Domain.Services
{
	public class DocumentacaoService : IDocumentacaoService
	{
		private readonly IDocumentacaoRepository _documentacaoRepository;

		public DocumentacaoService(IDocumentacaoRepository documentacaoRepository)
		{
			_documentacaoRepository = documentacaoRepository;
		}

		public void Dispose()
		{
			_documentacaoRepository.Dispose();
		}

		public Documentacao Add(Documentacao obj)
		{
			return _documentacaoRepository.Add(obj);
		}

		public Documentacao GetById(Guid id)
		{
			return _documentacaoRepository.GetById(id);
		}

		public IEnumerable<Documentacao> GetAll()
		{
			return _documentacaoRepository.GetAll();
		}

		public Documentacao Update(Documentacao obj)
		{
			return _documentacaoRepository.Update(obj);
		}

		public void Remove(Guid id)
		{
			_documentacaoRepository.Remove(id);
		}

		public IEnumerable<Documentacao> Search(Expression<Func<Documentacao, bool>> predicate)
		{
			return _documentacaoRepository.Search(predicate);
		}

		public Documentacao GetOne(Expression<Func<Documentacao, bool>> predicate)
		{
			return _documentacaoRepository.GetOne(predicate);
		}
	}
}