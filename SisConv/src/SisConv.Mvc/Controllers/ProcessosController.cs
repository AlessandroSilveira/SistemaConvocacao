using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using SisConv.Application.Interfaces.Repository;
using SisConv.Application.ViewModels;
using SisConv.Domain.Core.Enums;
using SisConv.Domain.Core.Services;

namespace SisConv.Mvc.Controllers
{
	[Authorize(Roles = "Cliente")]
	public class ProcessosController : Controller
    {
        private readonly IProcessoAppService _processoAppService;
        private readonly ICargoAppService _cargoAppService;
        private readonly IConvocadoAppService _convocadoAppService;
        private readonly IConvocacaoAppService _convocacaoAppService;
        private readonly IListaOpcoes _listaOpcoes;

        public ProcessosController(IProcessoAppService processoAppService, ICargoAppService cargoAppService,
            IConvocadoAppService convocadoAppService, IConvocacaoAppService convocacaoAppService,
            IListaOpcoes listaOpcoes)
        {
            _processoAppService = processoAppService;
            _cargoAppService = cargoAppService;
            _convocadoAppService = convocadoAppService;
            _convocacaoAppService = convocacaoAppService;
            _listaOpcoes = listaOpcoes;
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
        public ActionResult ListaConvocados(string ProcessoId, string cargo)
        {
            var dadosConvocadoViewModel = new ConvocadoViewModel
            {
                CargoId = Guid.Parse(cargo),
                ProcessoId = Guid.Parse(ProcessoId)
            };

            var convocados = _convocacaoAppService.Search(a => a.ProcessoId.Equals(dadosConvocadoViewModel.ProcessoId));

            ViewBag.DadosConvocacao = _processoAppService.GetById(dadosConvocadoViewModel.ProcessoId);
            ViewBag.ListaCandidatos = _convocadoAppService
                .Search(a => a.CargoId.Equals(dadosConvocadoViewModel.CargoId)).OrderBy(a => a.Posicao)
                .Where(a => convocados.All(p2 => p2.ConvocadoId != a.ConvocadoId));

            ViewBag.DadosCargo = _cargoAppService.GetById(dadosConvocadoViewModel.CargoId);
            ViewBag.ProcessoId = ProcessoId;
            
            return View();
        }

        public ActionResult ListaConvocados(Guid ProcessoId, string cargo, bool confirmacao)
        {
            var dadosConvocadoViewModel = new ConvocadoViewModel
            {
                CargoId = Guid.Parse(cargo),
                ProcessoId = ProcessoId
            };

            ViewBag.Confirmacao = confirmacao;

            var convocados = _convocacaoAppService.Search(a => a.ProcessoId.Equals(dadosConvocadoViewModel.ProcessoId));

            ViewBag.DadosConvocacao = _processoAppService.GetById(dadosConvocadoViewModel.ProcessoId);
            ViewBag.ListaCandidatos = _convocadoAppService
                .Search(a => a.CargoId.Equals(dadosConvocadoViewModel.CargoId)).OrderBy(a => a.Posicao)
                .Where(a => convocados.All(p2 => p2.ConvocadoId != a.ConvocadoId));

            ViewBag.DadosCargo = _cargoAppService.GetById(dadosConvocadoViewModel.CargoId);
            ViewBag.ProcessoId = ProcessoId;
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

            //var opcoesComp = _listaOpcoes.MontarListaOpcoesComparecimento();

	        var opcoesComp = _listaOpcoes.MontarListaOpcoes<StatusComparecimento>();

            ViewBag.ListaOpcoesComparecimento = opcoesComp;

            return View();
        }

        [HttpPost]
        public ActionResult AtualizarCandidatosConfirmados(Guid? id, Guid? cargo)
        {

            var novoid = Guid.Parse(id.ToString());
            
            //if (VerificarIdNulos(id, cargo, novoid, out var actionResult)) return actionResult;
            //if (VerificarSerCargoEstaNulo(cargo, novoid, out actionResult)) return actionResult;
            var novocargo = Guid.Parse(cargo.ToString());

            if (VerificarSerCargoEstaNulo(cargo, novoid, out var actionResult)) return actionResult;
            if (VerificarSeProcessoIdEstaNulo(id, novoid, out var view)) return view;


            var dadosConfirmados = _convocacaoAppService.Search(a => a.ProcessoId.Equals(novoid));
            var convocados = _convocadoAppService.Search(a => a.ProcessoId.Equals(novoid) && a.CargoId.Equals(novocargo));
            var listaDeconvocados = _convocacaoAppService.MontaListaDeConvocados(dadosConfirmados, convocados);

            ViewBag.ListaDeCandidatos = listaDeconvocados;
            ViewBag.dadosProcesso = _processoAppService.GetById(novoid);
            ViewBag.Cargos = _cargoAppService.Search(a => a.ProcessoId.Equals(novoid) && a.Ativo.Equals(true))
                .OrderBy(a => a.CodigoCargo);

	        var opcoesComp = _listaOpcoes.MontarListaOpcoes<StatusComparecimento>();

            ViewBag.ListaOpcoesComparecimento = opcoesComp;

            return View();
        }

        //private bool VerificarSeProcessoIdEstaNulo2(Guid? id, Guid novoid, out ActionResult view)
        //{
        //    if (id.Equals(null))
        //    {
        //        ModelState.AddModelError(id.ToString(), $"Algo deu errado,por favor tente novamente");
        //        ViewBag.Cargos = _cargoAppService.Search(a => a.ProcessoId.Equals(novoid) && a.Ativo.Equals(true))
        //            .OrderBy(a => a.CodigoCargo);
        //        ViewBag.dadosProcesso = _processoAppService.GetById(novoid);
        //        {
        //            view = View();
        //            return true;
        //        }
        //    }

        //    view = null;
        //    return false;
        //}

        //private bool VerificarSeCargoEstaNulo2(Guid? cargo, Guid novoid, out ActionResult actionResult)
        //{
        //    if (cargo.Equals(null))
        //    {
        //        ModelState.AddModelError(cargo.ToString(), $"Escolha um cargo");
        //        ViewBag.Cargos = _cargoAppService.Search(a => a.ProcessoId.Equals(novoid) && a.Ativo.Equals(true))
        //            .OrderBy(a => a.CodigoCargo);
        //        ViewBag.dadosProcesso = _processoAppService.GetById(novoid);
        //        {
        //            actionResult = View();
        //            return true;
        //        }
        //    }

        //    actionResult = null;
        //    return false;
        //}

        [HttpPost]
        public ActionResult AtualizarConvocacao(string opcaoConvocacao,Guid ProcessoId, Guid ConvocacaoId)
        {
            var dadosConvocacao = _convocacaoAppService.GetById(ConvocacaoId);
            dadosConvocacao.StatusConvocacao = opcaoConvocacao;
            var dados = _convocacaoAppService.Update(dadosConvocacao);
            return Json(dados, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AtualizarStatusEstudante(Guid id)
        {
            ViewBag.dadosProcesso = _processoAppService.GetById(id);
            ViewBag.Cargos = _cargoAppService.Search(a => a.ProcessoId.Equals(id) && a.Ativo.Equals(true))
                .OrderBy(a => a.CodigoCargo);
            ViewBag.ListaCandidatos = null;

            ViewBag.ProcessoId = id;

	        var opcoesComp = _listaOpcoes.MontarListaOpcoes<StatusComparecimento>();

            ViewBag.ListaOpcoesComparecimento = opcoesComp;
            return View();
        }

        [HttpPost]
        public ActionResult AtualizarStatusEstudante(Guid?  id, Guid? cargo)
        {
            var guidId = Guid.Parse(id.ToString());
            var guidCargo = Guid.Parse(cargo.ToString());

            if (VerificarSerCargoEstaNulo(cargo, guidId, out var actionResult)) return actionResult;
            if (VerificarSeProcessoIdEstaNulo(id, guidId, out var view)) return view;

            var dadosConfirmados = _convocacaoAppService.Search(a => a.ProcessoId.Equals(guidId) ).Where(b=>b.StatusConvocacao!=null);
            var convocados = _convocadoAppService.Search(a => a.ProcessoId.Equals(guidId) && a.CargoId.Equals(guidCargo));
            var listaDeconvocados = _convocacaoAppService.MontaListaDeConvocados(dadosConfirmados, convocados);

            ViewBag.ListaDeCandidatos = listaDeconvocados;
            ViewBag.dadosProcesso = _processoAppService.GetById(guidId);
            ViewBag.Cargos = _cargoAppService.Search(a => a.ProcessoId.Equals(guidId) && a.Ativo.Equals(true))
                .OrderBy(a => a.CodigoCargo);

	        var opcoesContatacao = _listaOpcoes.MontarListaOpcoes<StatusContratacao>();

            ViewBag.ProcessoId = id;
            ViewBag.ListaOpcoesContratacao = opcoesContatacao;

            return View();
        }

        private bool VerificarSeProcessoIdEstaNulo(Guid? id, Guid guidId, out ActionResult view)
        {
            if (id.Equals(null))
            {
                ModelState.AddModelError(id.ToString(), $"Algo deu errado,por favor tente novamente");
                ViewBag.Cargos = _cargoAppService.Search(a => a.ProcessoId.Equals(guidId) && a.Ativo.Equals(true))
                    .OrderBy(a => a.CodigoCargo);
                ViewBag.dadosProcesso = _processoAppService.GetById(guidId);
                {
                    view = View();
                    return true;
                }
            }

            view = null;
            return false;
        }

        private bool VerificarSerCargoEstaNulo(Guid? cargo, Guid guidId, out ActionResult actionResult)
        {
            if (cargo.Equals(null))
            {
                ModelState.AddModelError(cargo.ToString(), $"Escolha um cargo");
                ViewBag.Cargos = _cargoAppService.Search(a => a.ProcessoId.Equals(guidId) && a.Ativo.Equals(true))
                    .OrderBy(a => a.CodigoCargo);
                ViewBag.dadosProcesso = _processoAppService.GetById(guidId);
                {
                    actionResult = View();
                    return true;
                }
            }

            actionResult = null;
            return false;
        }

        [HttpPost]
        public ActionResult AtualizarStatusEstudanteParaContratacao(string opcaoStatus, Guid processoId, Guid convocacaoId)
        {
            var dadosConvocacao = _convocacaoAppService.GetById(convocacaoId);
            dadosConvocacao.StatusContratacao = opcaoStatus;
            var dados = _convocacaoAppService.Update(dadosConvocacao);
            return Json(dados, JsonRequestBehavior.AllowGet);
        }
    }
}