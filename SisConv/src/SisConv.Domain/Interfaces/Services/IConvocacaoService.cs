using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using SisConv.Domain.Entities;

namespace SisConv.Domain.Interfaces.Services
{
    public interface IConvocacaoService : IDisposable
    {
        Convocacao Add(Convocacao obj);
        Convocacao GetById(Guid id);
        IEnumerable<Convocacao> GetAll();
        Convocacao Update(Convocacao obj);
        void Remove(Guid id);
        IEnumerable<Convocacao> Search(Expression<Func<Convocacao, bool>> predicate);
		

		// List<ConvocadoViewModel> MontarListaConvocado(IEnumerable<ConvocacaoViewModel> dadosConfirmados, IEnumerable<ConvocadoViewModel> convocados);
	    string GeneratePassword();
    }
}