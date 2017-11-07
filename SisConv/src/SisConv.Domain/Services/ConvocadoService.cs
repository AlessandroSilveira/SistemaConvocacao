using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using SisConv.Domain.Entities;
using SisConv.Domain.Interfaces.Repositories;
using SisConv.Domain.Interfaces.Services;

namespace SisConv.Domain.Services
{
    public class ConvocadoService : IConvocadoService
    {
        private readonly IConvocadoRepository _convocadoRepository;

        public ConvocadoService(IConvocadoRepository convocadoRepository)
        {
            _convocadoRepository = convocadoRepository;
        }

        public void Dispose()
        {
            _convocadoRepository.Dispose();
        }

        public Convocado Add(Convocado obj)
        {
            return _convocadoRepository.Add(obj);
        }

        public Convocado GetById(Guid id)
        {
            return _convocadoRepository.GetById(id);
        }

        public IEnumerable<Convocado> GetAll()
        {
            return _convocadoRepository.GetAll();
        }

        public Convocado Update(Convocado obj)
        {
            return _convocadoRepository.Update(obj);
        }

        public void Remove(Guid id)
        {
             _convocadoRepository.Remove(id);
        }

        public IEnumerable<Convocado> Search(Expression<Func<Convocado, bool>> predicate)
        {
            return _convocadoRepository.Search(predicate);
        }
    }
}