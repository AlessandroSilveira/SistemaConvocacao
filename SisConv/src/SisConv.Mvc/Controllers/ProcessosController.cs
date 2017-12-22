using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using SisConv.Application.Interfaces.Repository;
using SisConv.Application.ViewModels;

namespace SisConv.Mvc.Controllers
{
    public class ProcessosController : Controller
    {
        private readonly IProcessoAppService _processoAppService;
        private readonly ICargoAppService _cargoAppService;
        private readonly IConvocadoAppService _convocadoAppService;
	    private readonly IConvocacaoAppService _convocacaoAppService;

        public ProcessosController(IProcessoAppService processoAppService, ICargoAppService cargoAppService,
            IConvocadoAppService convocadoAppService, IConvocacaoAppService convocacaoAppService)
        {
            _processoAppService = processoAppService;
            _cargoAppService = cargoAppService;
            _convocadoAppService = convocadoAppService;
	        _convocacaoAppService = convocacaoAppService;
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

			return View();
	    }

		[HttpPost]
	    public ActionResult AtualizarCandidatosConfirmados(Guid id,Guid cargo)
	    {
			var dadosConfirmados = _convocacaoAppService.Search(a => a.ProcessoId.Equals(id));
			var convocados = _convocadoAppService.Search(a => a.ProcessoId.Equals(id));

			//var convocadoViewModels = dadosConfirmados.ToList();
			//ViewBag.ListaCandidatos = dadosConfirmados.GroupJoin(convocadoViewModels, conf => conf.ConvocadoId,
			// conv => conv.ConvocadoId, (conf, conv) => convocadoViewModels);

			ViewBag.ListaCandidatos = dadosConfirmados.GroupJoin(convocados, conf => conf.ConvocadoId,
			 conv => conv.ConvocadoId, (conf, conv) => new { Conf = conf, Conv = conv.DefaultIfEmpty() });

			ViewBag.Cargos = _cargoAppService.Search(a => a.ProcessoId.Equals(id) && a.Ativo.Equals(true))
			    .OrderBy(a => a.CodigoCargo);

		    return View();
	    }
	}
}