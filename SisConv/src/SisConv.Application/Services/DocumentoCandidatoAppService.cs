using AutoMapper;
using SisConv.Application.Interfaces.Repository;
using SisConv.Application.ViewModels;
using SisConv.Domain.Entities;
using SisConv.Domain.Interfaces.Repositories;
using SisConv.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SisConv.Application.Services
{
    public class DocumentoCandidatoAppService : ApplicationService, IDocumentoCandidatoAppService

    {
        private readonly IDocumentoCandidatoService _documentoCandidatoService;
        private readonly IConvocadoAppService _convocadoAppService;

        public string Inscricao { get; private set; }

        public DocumentoCandidatoAppService(
            IUnitOfWork unitOfWork,
            IDocumentoCandidatoService documentoCandidatoService,
            IConvocadoAppService convocadoAppService
            ) : base(unitOfWork)
        {
            _documentoCandidatoService = documentoCandidatoService;
            _convocadoAppService = convocadoAppService;
        }

        public void Dispose()
        {
            _documentoCandidatoService.Dispose();
        }

        public DocumentoCandidatoViewModel Add(DocumentoCandidatoViewModel obj)
        {
            var dados = Mapper.Map<DocumentoCandidatoViewModel, DocumentoCandidato>(obj);
            BeginTransaction();
            _documentoCandidatoService.Add(dados);
            Commit();
            return obj;
        }

        public DocumentoCandidatoViewModel GetById(Guid id)
        {
            return Mapper.Map<DocumentoCandidato, DocumentoCandidatoViewModel>(_documentoCandidatoService.GetById(id));
        }

        public IEnumerable<DocumentoCandidatoViewModel> GetAll()
        {
            return Mapper.Map<IEnumerable<DocumentoCandidato>, IEnumerable<DocumentoCandidatoViewModel>>(_documentoCandidatoService.GetAll());
        }

        public DocumentoCandidatoViewModel Update(DocumentoCandidatoViewModel obj)
        {
            BeginTransaction();
            _documentoCandidatoService.Update(Mapper.Map<DocumentoCandidatoViewModel, DocumentoCandidato>(obj));
            Commit();
            return obj;
        }

        public void Remove(Guid id)
        {
            BeginTransaction();
            _documentoCandidatoService.Remove(id);
            Commit();
        }

        public IEnumerable<DocumentoCandidatoViewModel> Search(Expression<Func<DocumentoCandidato, bool>> predicate)
        {
            return Mapper.Map<IEnumerable<DocumentoCandidato>, IEnumerable<DocumentoCandidatoViewModel>>(
                _documentoCandidatoService.Search(predicate));
        }

        public DocumentoCandidatoViewModel GetOne(Expression<Func<DocumentoCandidato, bool>> predicate)
        {
            return Mapper.Map<DocumentoCandidato, DocumentoCandidatoViewModel>(
                _documentoCandidatoService.GetOne(predicate));
        }

        public List<ListaDocumentosViewModel> MontarListaDeDocumentosDoCandidatos(IEnumerable<DocumentoCandidatoViewModel> documentos,
            IEnumerable<ConvocadoViewModel> dadosCandidatos)
        {
            var result = documentos.GroupJoin(dadosCandidatos, docs => docs.ConvocadoId, cand => cand.ConvocadoId,
                (docs, cand) => new
                {
                    docs.Ativo,
                    docs.ConvocadoId,
                    docs.DataInclusao,
                    docs.Documento,
                    docs.DocumentoCandidatoId,
                    docs.Path,
                    docs.ProcessoId,
                    docs.TipoDocumento,
                    dadosCandidatos = cand
                });

            var listaDeDocumentosCandidatos = new List<ListaDocumentosViewModel>();

            foreach (var itens in result)
            {
                listaDeDocumentosCandidatos.AddRange(itens.dadosCandidatos.Select(lista => new ListaDocumentosViewModel
                {
                    ConvocacaoId = itens.ConvocadoId,
                    Inscricao = lista.Inscricao,
                    Nome = lista.Nome,
                    Curso = lista.Curso,
                    Path = itens.Path,
                    TipoDocumento = itens.TipoDocumento,
                    DataPostagem = itens.DataInclusao,
                    DocumentoCandidatoId = itens.DocumentoCandidatoId
                }));
            }

            return listaDeDocumentosCandidatos;
        }
    }
}