using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using SisConv.Domain.Entities;
using SisConv.Domain.Interfaces.Repositories;
using SisConv.Domain.Interfaces.Services;

namespace SisConv.Domain.Services
{
    public class ConvocacaoService : IConvocacaoService
    {

        private readonly IConvocacaoRepository _convocacaoRepository;

        public ConvocacaoService(IConvocacaoRepository convocacaoRepository)
        {
            _convocacaoRepository = convocacaoRepository;
        }

        public void Dispose()
        {
            _convocacaoRepository.Dispose();
        }

        public Convocacao Add(Convocacao obj)
        {
            return _convocacaoRepository.Add(obj);
        }

        public Convocacao GetById(Guid id)
        {
            return _convocacaoRepository.GetById(id);
        }

        public IEnumerable<Convocacao> GetAll()
        {
            return _convocacaoRepository.GetAll();
        }

        public Convocacao Update(Convocacao obj)
        {
            return _convocacaoRepository.Update(obj);
        }

        public void Remove(Guid id)
        {
             _convocacaoRepository.Remove(id);
        }

        public IEnumerable<Convocacao> Search(Expression<Func<Convocacao, bool>> predicate)
        {
            return _convocacaoRepository.Search(predicate);
        }
    }
}