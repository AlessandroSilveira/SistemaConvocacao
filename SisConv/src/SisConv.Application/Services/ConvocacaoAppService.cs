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
				var itemDesistente = itens.Desistente;
				var itemDataEntregaDocumentos = itens.DataEntregaDocumentos;
				var convocacaoId = itens.ConvocacaoId;
				var statusConvocacao = itens.StatusConvocacao;
				var statusContrataco = itens.StatusContratacao;
				var entrouNoSistema = itens.EntrouNoSistema;
				listaDeconvocados.AddRange(itens.convocados.Select(person => new ConvocadoViewModel
				{
					ConvocacaoId = convocacaoId,
					ConvocadoId = person.ConvocadoId,
					Nome = person.Nome,
					Posicao = person.Posicao,
					Inscricao = person.Inscricao,
					Desistente = itemDesistente,
					EntrouNoSistema = _primeiroAcessoService.Search(a => a.Email.Equals(person.Email)) == null ? @"Não" : "Sim",
					DataEntregaDocumentos = itemDataEntregaDocumentos,
					StatusConvocacao = string.IsNullOrEmpty(statusConvocacao) ? "" : _opcoesComparecimento.EnumDescription((StatusComparecimento)Enum.Parse(typeof(StatusComparecimento), statusConvocacao)),
					StatusContratacao = string.IsNullOrEmpty(statusContrataco) ? "" : _opcoesComparecimento.EnumDescription((StatusContratacao)Enum.Parse(typeof(StatusContratacao), statusContrataco))
				}));
			}
			return listaDeconvocados;
		}

		public ConvocacaoViewModel GetOne(Expression<Func<Convocacao, bool>> predicate)
		{
			return Mapper.Map<Convocacao, ConvocacaoViewModel>(_convocacaoService.GetOne(predicate));
		}

		public List<ConvocadoViewModel> MontarListaDeConvocadosQueIngressaram(IEnumerable<PrimeiroAcessoViewModel> candidadosQueFizeramPrimeiroAcesso, IEnumerable<ConvocadoViewModel> convocados, IEnumerable<ConvocacaoViewModel> dadosConfirmados)
		{
			var result = candidadosQueFizeramPrimeiroAcesso.GroupJoin(convocados, conf => conf.Email, conv => conv.Email,
				(conf, conv) => new
				{
					conf.Data,
					conf.Email,
					convocados = conv
				});

			var listaDeCandidatosQueIngressaram = new List<ConvocadoViewModel>();

			foreach (var itens in result)
			{
				listaDeCandidatosQueIngressaram.AddRange(itens.convocados.Select(person => new ConvocadoViewModel
				{
					ConvocacaoId = person.ConvocacaoId,
					ConvocadoId = person.ConvocadoId,
					Nome = person.Nome,
					Posicao = person.Posicao,
					Inscricao = person.Inscricao,
					Desistente = person.Desistente,
					EntrouNoSistema = _primeiroAcessoService.Search(a => a.Email.Equals(person.Email)) == null ? @"Não" : "Sim",
					DataEntregaDocumentos = person.DataEntregaDocumentos,
					StatusConvocacao = string.IsNullOrEmpty(person.StatusConvocacao) ? "" : _opcoesComparecimento.EnumDescription((StatusComparecimento)Enum.Parse(typeof(StatusComparecimento), person.StatusConvocacao)),
					StatusContratacao = string.IsNullOrEmpty(person.StatusContratacao) ? "" : _opcoesComparecimento.EnumDescription((StatusContratacao)Enum.Parse(typeof(StatusContratacao), person.StatusContratacao)),
					InstituicaoEnsino = person.InstituicaoEnsino
				}));
			}
			

			return listaDeCandidatosQueIngressaram;
		}

		public List<ConvocadoViewModel> MontarListaDeConvocadosNaoQueIngressaram(IEnumerable<ConvocadoViewModel> convocados, IEnumerable<ConvocacaoViewModel> dadosConfirmados)
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

			var listaDeCandidatosQueIngressaram = new List<ConvocadoViewModel>();

			foreach (var itens in result)
			{
				listaDeCandidatosQueIngressaram.AddRange(itens.convocados.Select(person => new ConvocadoViewModel
				{
					ConvocacaoId = person.ConvocacaoId,
					ConvocadoId = person.ConvocadoId,
					Nome = person.Nome,
					Posicao = person.Posicao,
					Inscricao = person.Inscricao,
					Desistente = person.Desistente,
					EntrouNoSistema = _primeiroAcessoService.Search(a => a.Email.Equals(person.Email)) == null ? @"Não" : "Sim",
					DataEntregaDocumentos = person.DataEntregaDocumentos,
					StatusConvocacao = string.IsNullOrEmpty(person.StatusConvocacao) ? "" : _opcoesComparecimento.EnumDescription((StatusComparecimento)Enum.Parse(typeof(StatusComparecimento), person.StatusConvocacao)),
					StatusContratacao = string.IsNullOrEmpty(person.StatusContratacao) ? "" : _opcoesComparecimento.EnumDescription((StatusContratacao)Enum.Parse(typeof(StatusContratacao), person.StatusContratacao))
				}));
			}


			return listaDeCandidatosQueIngressaram;
		}
	}
}