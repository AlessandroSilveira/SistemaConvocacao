using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using SisConv.Application.Interfaces.Repository;
using SisConv.Application.ViewModels;
using SisConv.Domain.Core.Enums;
using SisConv.Domain.Core.Services;
using SisConv.Domain.Entities;
using SisConv.Domain.Interfaces.Repositories;
using SisConv.Domain.Interfaces.Services;

namespace SisConv.Application.Services
{
	public class ConvocacaoAppService : ApplicationService, IConvocacaoAppService
	{
		private readonly IConvocacaoService _convocacaoService;
		private readonly IListaOpcoes _opcoesComparecimento;
		private readonly IPrimeiroAcessoService _primeiroAcessoService;


		public ConvocacaoAppService(IUnitOfWork unitOfWork,
			IConvocacaoService convocacaoService,
			IListaOpcoes opcoesComparecimento,
			IPrimeiroAcessoService primeiroAcessoService) : base(unitOfWork)
		{
			_convocacaoService = convocacaoService;
			_opcoesComparecimento = opcoesComparecimento;
			_primeiroAcessoService = primeiroAcessoService;
		}

		public void Dispose()
		{
			_convocacaoService.Dispose();
		}

		public ConvocacaoViewModel Add(ConvocacaoViewModel obj)
		{
			var convocacao = Mapper.Map<ConvocacaoViewModel, Convocacao>(obj);
			BeginTransaction();
			_convocacaoService.Add(convocacao);
			Commit();
			return obj;
		}

		public ConvocacaoViewModel GetById(Guid id)
		{
			return Mapper.Map<Convocacao, ConvocacaoViewModel>(_convocacaoService.GetById(id));
		}

		public IEnumerable<ConvocacaoViewModel> GetAll()
		{
			return Mapper.Map<IEnumerable<Convocacao>, IEnumerable<ConvocacaoViewModel>>(_convocacaoService.GetAll());
		}

		public ConvocacaoViewModel Update(ConvocacaoViewModel obj)
		{
			BeginTransaction();
			_convocacaoService.Update(Mapper.Map<ConvocacaoViewModel, Convocacao>(obj));
			Commit();
			return obj;
		}

		public void Remove(Guid id)
		{
			BeginTransaction();
			_convocacaoService.Remove(id);
			Commit();
		}

		public IEnumerable<ConvocacaoViewModel> Search(Expression<Func<Convocacao, bool>> predicate)
		{
			return Mapper.Map<IEnumerable<Convocacao>, IEnumerable<ConvocacaoViewModel>>(
				_convocacaoService.Search(predicate));
		}

		public string GerarSenhaUsuario()
		{
			return _convocacaoService.GeneratePassword();
		}

		public List<ConvocadoViewModel> MontaListaDeConvocados(IEnumerable<ConvocacaoViewModel> dadosConfirmados, IEnumerable<ConvocadoViewModel> convocados)
		{
			var result = dadosConfirmados.GroupJoin(convocados, conf => conf.ConvocadoId, conv => conv.ConvocadoId,
				(conf, conv) => new
				{
					conf.Desistente,
					conf.DataEntregaDocumentos,
					conf.ConvocacaoId,
					conf.StatusConvocacao,
					conf.StatusContratacao,
					conf.EntrouNoSistema,
					convocados = conv
				});

			var listaDeconvocados = new List<ConvocadoViewModel>();

			foreach (var itens in result)
			{

				listaDeconvocados.AddRange(itens.convocados.Select(lista => new ConvocadoViewModel
				{
					ConvocacaoId =lista.ConvocacaoId,
					ConvocadoId = lista.ConvocadoId,
					Nome = lista.Nome,
					Posicao = lista.Posicao,
					Inscricao = lista.Inscricao,
					Desistente = lista.Desistente,
					EntrouNoSistema = _primeiroAcessoService.Search(a => a.Email.Equals(lista.Email)) == null ? @"Não" : "Sim",
					DataEntregaDocumentos = lista.DataEntregaDocumentos,
					InstituicaoEnsino = lista.InstituicaoEnsino,
					StatusConvocacao = string.IsNullOrEmpty(lista.StatusConvocacao) ? "" : _opcoesComparecimento.EnumDescription((StatusConvocacao)Enum.Parse(typeof(StatusConvocacao), lista.StatusConvocacao)),
					StatusContratacao = string.IsNullOrEmpty(lista.StatusContratacao) ? "" : _opcoesComparecimento.EnumDescription((StatusConvocacao)Enum.Parse(typeof(StatusConvocacao), lista.StatusContratacao))
				}));
			}
			return listaDeconvocados;
		}

		public ConvocacaoViewModel GetOne(Expression<Func<Convocacao, bool>> predicate)
		{
			return Mapper.Map<Convocacao, ConvocacaoViewModel>(_convocacaoService.GetOne(predicate));
		}


		
	}
}