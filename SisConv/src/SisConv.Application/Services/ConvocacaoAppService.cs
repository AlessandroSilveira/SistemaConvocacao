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


        public ConvocacaoAppService(IUnitOfWork unitOfWork, IConvocacaoService convocacaoService, IListaOpcoes opcoesComparecimento) : base(unitOfWork)
        {
            _convocacaoService = convocacaoService;
            _opcoesComparecimento = opcoesComparecimento;
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
                    convocados = conv
                });

            var listaDeconvocados = new List<ConvocadoViewModel>();

            foreach (var language in result)
            {
                var itemDesistente = language.Desistente;
                var itemDataEntregaDocumentos = language.DataEntregaDocumentos;
                var convocacaoId = language.ConvocacaoId;
                var statusConvocacao = language.StatusConvocacao;
                listaDeconvocados.AddRange(language.convocados.Select(person => new ConvocadoViewModel
                {
                    ConvocacaoId = convocacaoId,
                    ConvocadoId = person.ConvocadoId,
                    Nome = person.Nome,
                    Posicao = person.Posicao,
                    Inscricao = person.Inscricao,
                    Desistente = itemDesistente,
                    DataEntregaDocumentos = itemDataEntregaDocumentos,
                    StatusConvocacao = _opcoesComparecimento.EnumDescription((StatusComparecimento) Enum.Parse(typeof(StatusComparecimento), statusConvocacao))
                }));
            }
            return listaDeconvocados;
        }
    }
}