using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using SisConv.Application.ViewModels;
using SisConv.Domain.Entities;

namespace SisConv.Application.Interfaces.Repository
{
    public interface IConvocacaoAppService : IDisposable
    {
        ConvocacaoViewModel Add(ConvocacaoViewModel obj);
        ConvocacaoViewModel GetById(Guid id);
        IEnumerable<ConvocacaoViewModel> GetAll();
        ConvocacaoViewModel Update(ConvocacaoViewModel obj);
        void Remove(Guid id);
        IEnumerable<ConvocacaoViewModel> Search(Expression<Func<Convocacao, bool>> predicate);
	    string GerarSenhaUsuario();
        List<ConvocadoViewModel> MontaListaDeConvocados(IEnumerable<ConvocacaoViewModel> dadosConfirmados, IEnumerable<ConvocadoViewModel> convocados);
		ConvocacaoViewModel GetOne(Expression<Func<Convocacao, bool>> predicate);
		List<ConvocadoViewModel> MontarListaDeConvocadosQueIngressaram(IEnumerable<PrimeiroAcessoViewModel> candidadosQueFizeramPrimeiroAcesso, IEnumerable<ConvocadoViewModel> convocados,IEnumerable<ConvocacaoViewModel> dadosConfirmados);
		List<ConvocadoViewModel> MontarListaDeConvocadosNaoQueIngressaram(IEnumerable<ConvocadoViewModel> convocados, IEnumerable<ConvocacaoViewModel> dadosConfirmados);
	}
}