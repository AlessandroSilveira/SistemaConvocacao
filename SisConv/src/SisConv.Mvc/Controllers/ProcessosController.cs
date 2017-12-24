using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using SisConv.Application.Interfaces.Repository;
using SisConv.Application.ViewModels;
using SisConv.Domain.Core.Enums;
using SisConv.Domain.Core.Services;

namespace SisConv.Mvc.Controllers
{
    public class ProcessosController : Controller
    {
        private readonly IProcessoAppService _processoAppService;
        private readonly ICargoAppService _cargoAppService;
        private readonly IConvocadoAppService _convocadoAppService;
        private readonly IConvocacaoAppService _convocacaoAppService;
        private readonly IOpcoesComparecimento _opcoesComparecimento;

        public ProcessosController(IProcessoAppService processoAppService, ICargoAppService cargoAppService,
            IConvocadoAppService convocadoAppService, IConvocacaoAppService convocacaoAppService,
            IOpcoesComparecimento opcoesComparecimento)
        {
            _processoAppService = processoAppService;
            _cargoAppService = cargoAppService;
            _convocadoAppService = convocadoAppService;
            _convocacaoAppService = convocacaoAppService;
            _opcoesComparecimento = opcoesComparecimento;
        }

        public ActionResult Index()
        {
            return View(_processoAppService.GetAll());
        }

        public ActionResult Details(Guid? id)
        {
            if (id.Equals(null)) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var processoViewModel = _processoAppService.GetById(Guid.Parse(id.ToString()));
            return processoViewModel.Equals(null) ? (ActionResult) HttpNotFound() : View(processoViewModel);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProcessoViewModel processoViewModel)
        {
            if (!ModelState.IsValid) return View(processoViewModel);
            _processoAppService.Add(processoViewModel);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(Guid? id)
        {
            if (id.Equals(null)) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var processoViewModel = _processoAppService.GetById(Guid.Parse(id.ToString()));
            return processoViewModel.Equals(null) ? (ActionResult) HttpNotFound() : View(processoViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProcessoViewModel processoViewModel)
        {
            if (!ModelState.IsValid) return View(processoViewModel);
            _processoAppService.Update(processoViewModel);
            return RedirectToAction("Index");
        }


        public ActionResult Delete(Guid? id)
        {
            if (id.Equals(null)) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var processoViewModel = _processoAppService.GetById(Guid.Parse(id.ToString()));
            return processoViewModel.Equals(null) ? (ActionResult) HttpNotFound() : View(processoViewModel);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _processoAppService.Remove(id);
            return RedirectToAction("Index");
        }

        public ActionResult EscolherCargo(Guid id)
        {
            ViewBag.DadosConvocacao = _processoAppService.GetById(id);
            ViewBag.Cargos = _cargoAppService.Search(a => a.ProcessoId.Equals(id) && a.Ativo.Equals(true))
                .OrderBy(a => a.CodigoCargo);
            ViewBag.Id = id;
            return View();
        }

        [HttpPost]
        public ActionResult ListaConvocados(string cargo, string id)
        {
            var dadosConvocadoViewModel = new ConvocadoViewModel
            {
                CargoId = Guid.Parse(cargo),
                ProcessoId = Guid.Parse(id)
            };

            var convocados = _convocacaoAppService.Search(a => a.ProcessoId.Equals(dadosConvocadoViewModel.ProcessoId));

            ViewBag.DadosConvocacao = _processoAppService.GetById(dadosConvocadoViewModel.ProcessoId);
            ViewBag.ListaCandidatos = _convocadoAppService
                .Search(a => a.CargoId.Equals(dadosConvocadoViewModel.CargoId)).OrderBy(a => a.Posicao)
                .Where(a => convocados.All(p2 => p2.ConvocadoId != a.ConvocadoId));

            ViewBag.DadosCargo = _cargoAppService.GetById(dadosConvocadoViewModel.CargoId);
            ViewBag.ProcessoId = id;
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _processoAppService.Dispose();
            base.Dispose(disposing);
        }

        public ActionResult Configuracoes(Guid id)
        {
            ViewBag.dadosProcesso = _processoAppService.GetById(id);
            return View();
        }

        public ActionResult Painel(Guid id)
        {
            ViewBag.dadosProcesso = _processoAppService.GetById(id);
            return View();
        }

        public ActionResult AtualizarCandidatosConfirmados(Guid id)
        {
            ViewBag.dadosProcesso = _processoAppService.GetById(id);
            ViewBag.Cargos = _cargoAppService.Search(a => a.ProcessoId.Equals(id) && a.Ativo.Equals(true))
                .OrderBy(a => a.CodigoCargo);
            ViewBag.ListaCandidatos = null;

            return View();
        }

        [HttpPost]
        public ActionResult AtualizarCandidatosConfirmados(Guid id, Guid cargo)
        {
            var dadosConfirmados = _convocacaoAppService.Search(a => a.ProcessoId.Equals(id));
            var convocados = _convocadoAppService.Search(a => a.ProcessoId.Equals(id));
            var listaDeconvocados = _convocacaoAppService.MontaListaDeConvocados(dadosConfirmados, convocados);

            ViewBag.ListaDeCandidatos = listaDeconvocados;
            ViewBag.dadosProcesso = _processoAppService.GetById(id);
            ViewBag.Cargos = _cargoAppService.Search(a => a.ProcessoId.Equals(id) && a.Ativo.Equals(true))
                .OrderBy(a => a.CodigoCargo);

            Dictionary<StatusComparecimento, string> opcoesComp;
            opcoesComp = new Dictionary<StatusComparecimento, string>();

            foreach (StatusComparecimento val in Enum.GetValues(typeof(StatusComparecimento)))
                opcoesComp.Add(Domain.Core.Enums.StatusComparecimento.CompareceuEntregaDocumentacao,
                    _opcoesComparecimento.EnumDescription(Domain.Core.Enums.StatusComparecimento.CompareceuEntregaDocumentacao));

            ViewBag

            return View();
        }

        public IEnumerable StatusComparecimento { get; set; }
    }
}