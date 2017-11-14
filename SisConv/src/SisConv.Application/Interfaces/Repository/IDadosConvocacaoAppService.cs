using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using SisConv.Application.ViewModels;
using SisConv.Domain.Entities;

namespace SisConv.Application.Interfaces.Repository
{
    public interface IDadosConvocacaoAppService : IDisposable
    {
        DadosConvocadosViewModel Add(DadosConvocadosViewModel obj);
        DadosConvocadosViewModel GetById(Guid id);
        IEnumerable<DadosConvocadosViewModel> GetAll();
        DadosConvocadosViewModel Update(DadosConvocadosViewModel obj);
        void Remove(Guid id);
        IEnumerable<DadosConvocadosViewModel> Search(Expression<Func<Convocado, bool>> predicate);
        void SalvarCandidatos(DadosConvocadosViewModel dadosConvocadosViewModel);
        void SalvarCandidatos(Guid id, string file);
    }
}