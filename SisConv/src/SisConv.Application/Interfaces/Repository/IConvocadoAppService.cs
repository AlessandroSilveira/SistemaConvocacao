using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using SisConv.Application.ViewModels;
using SisConv.Domain.Entities;

namespace SisConv.Application.Interfaces.Repository
{
    public interface IConvocadoAppService : IDisposable
    {
        ConvocadoViewModel Add(ConvocadoViewModel obj);
        ConvocadoViewModel GetById(Guid id);
        IEnumerable<ConvocadoViewModel> GetAll();
        ConvocadoViewModel Update(ConvocadoViewModel obj);
        void Remove(Guid id);
        IEnumerable<ConvocadoViewModel> Search(Expression<Func<Convocado, bool>> predicate);
	    bool VerificaSeHaSobrenome(string nome);
    }
}