using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web.Configuration;
using SisConv.Application.ViewModels;
using SisConv.Domain.Core.Enums;
using SisConv.Domain.Core.Services;
using SisConv.Domain.Entities;
using SisConv.Domain.Interfaces.Repositories;
using SisConv.Domain.Interfaces.Services;

namespace SisConv.Domain.Services
{
    public class ConvocacaoService : IConvocacaoService
    {
        private readonly IConvocacaoRepository _convocacaoRepository;
        private readonly IListaOpcoes _opcoesComparecimento;

        private const string SenhaCaracteresValidos = "abcdefghijklmnopqrstuvwxyz1234567890@#!?";

        public ConvocacaoService(IConvocacaoRepository convocacaoRepository, IListaOpcoes opcoesComparecimento)
        {
            _convocacaoRepository = convocacaoRepository;
            _opcoesComparecimento = opcoesComparecimento;
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

        public string GerarSenha()
        {
            var tamanho = Convert.ToInt32(WebConfigurationManager.AppSettings["NumerosCaracteresSenha"]);
            var valormaximo = SenhaCaracteresValidos.Length;
            var random = new Random(DateTime.Now.Millisecond);
            var senha = new StringBuilder(tamanho);

            for (var i = 0; i < tamanho; i++)
                senha.Append(SenhaCaracteresValidos[random.Next(0, valormaximo)]);

            return senha.ToString();
        }

        public List<ConvocadoViewModel> MontarListaConvocado(IEnumerable<ConvocacaoViewModel> dadosConfirmados,
            IEnumerable<ConvocadoViewModel> convocados)
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
                string itemDesistente = language.Desistente;
                DateTime itemDataEntregaDocumentos = language.DataEntregaDocumentos;
                Guid convocacaoId = language.ConvocacaoId;
                string statusConvocacao = language.StatusConvocacao;
                foreach (var person in language.convocados)
                    listaDeconvocados.Add(new ConvocadoViewModel
                    {
                        ConvocacaoId = convocacaoId,
                        ConvocadoId = person.ConvocadoId,
                        Nome = person.Nome,
                        Posicao = person.Posicao,
                        Inscricao = person.Inscricao,
                        Desistente = itemDesistente,
                        DataEntregaDocumentos = itemDataEntregaDocumentos,
                        StatusConvocacao = _opcoesComparecimento.EnumDescription((StatusComparecimento)Enum.Parse(typeof(StatusComparecimento), statusConvocacao))
            });
            }

            return listaDeconvocados;
        }
    }
}