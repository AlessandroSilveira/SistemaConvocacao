using System;
using System.Linq;
using System.Web.Mvc;
using SisConv.Application.Interfaces.Repository;

namespace SisConv.Mvc.Controllers
{
	public class RelatorioController : Controller
	{
	    private readonly ICargoAppService _cargoAppService;
	    private readonly IConvocadoAppService _convocadoAppService;
	    private readonly IConvocacaoAppService _convocacaoAppService;

	    public RelatorioController(ICargoAppService cargoAppService, IConvocadoAppService convocadoAppService, IConvocacaoAppService convocacaoAppService)
	    {
	        _cargoAppService = cargoAppService;
	        _convocadoAppService = convocadoAppService;
	        _convocacaoAppService = convocacaoAppService;
	    }

	    // GET: Relatorio
        public ActionResult Index(Guid Id)
        {
            ViewBag.ProcessoId = Id;
            return View();
        }

        public ActionResult ClassificadosPorCargo(Guid id)
        {
            ViewBag.ProcessoId = id;
            ViewBag.ListaCargos = _cargoAppService.Search(a => a.ProcessoId.Equals(id) && a.Ativo.Equals(true));
            ViewBag.ListaConvocadosPorCargo = null;
            return View();
        }

        [HttpPost]
	    public ActionResult ClassificadosPorCargo(Guid id, Guid cargo)
	    {
	        ViewBag.ProcessoId = id;
	        var dadosConfirmados = _convocacaoAppService.Search(a => a.ProcessoId.Equals(id)).Where(b => b.StatusConvocacao != null);
	        var convocados = _convocadoAppService.Search(a => a.ProcessoId.Equals(id) && a.CargoId.Equals(cargo));
	        ViewBag.ListaConvocadosPorCargo = _convocacaoAppService.MontaListaDeConvocados(dadosConfirmados, convocados);
	        ViewBag.ListaCargos = _cargoAppService.Search(a => a.ProcessoId.Equals(id) && a.Ativo.Equals(true));

            return View();
	    }
    }
}