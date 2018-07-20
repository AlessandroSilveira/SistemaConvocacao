using System;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using SisConv.Application.Interfaces.Repository;

namespace SisConv.Mvc.Controllers
{
	public class HomeController : Controller
	{
		private readonly IConvocadoAppService _convocadoAppService;
		private readonly IProcessoAppService _processoAppService;
		private readonly IConvocacaoAppService _convocacaoAppService;
		private readonly IDocumentacaoAppService _documentacaoAppService;

		public HomeController(
			IConvocadoAppService convocadoAppService, 
			IProcessoAppService processoAppService,
			IConvocacaoAppService convocacaoAppService, 
			IDocumentacaoAppService documentacaoAppService
			)
		{
			_convocadoAppService = convocadoAppService;
			_processoAppService = processoAppService;
			_convocacaoAppService = convocacaoAppService;
			_documentacaoAppService = documentacaoAppService;
		}

		public ActionResult Index()
		{

			if (User.IsInRole("Cliente")) return RedirectToAction("Index", "Processos");

			if (!User.IsInRole("Convocado")) return View();
			

			var dadosConvocado = _convocadoAppService.GetById(Guid.Parse(User.Identity.GetUserId()));
			ViewBag.dadosConvocado = dadosConvocado;

			var dadosProcesso = _processoAppService.GetById(dadosConvocado.ProcessoId);
			ViewBag.dadosProcesso = dadosProcesso;

			var dadosConvocacao = _convocacaoAppService.Search(a =>
					a.ConvocadoId.Equals(dadosConvocado.ConvocadoId) && a.ProcessoId.Equals(dadosProcesso.ProcessoId))
				.FirstOrDefault();
			ViewBag.dadosConvocacao = dadosConvocacao;

			var listaDocumentacao = _documentacaoAppService.Search(a => a.ProcessoId.Equals(dadosProcesso.ProcessoId));
			ViewBag.ListaDocumentacao = listaDocumentacao;

			if (string.IsNullOrEmpty(dadosConvocacao.Desistente)) return View();

			if (dadosConvocacao.Desistente.Equals("N"))
				return RedirectToAction("DocumentacaoConvocado", "Convocacao",
					new {dadosProcesso.ProcessoId, dadosConvocacao.ConvocadoId, dadosConvocacao.ConvocacaoId});
			if (dadosConvocacao.Desistente.Equals("S"))
				return RedirectToAction("DesistenciaCandidato", "Convocacao",
					new {dadosProcesso.ProcessoId, dadosConvocacao.ConvocadoId, dadosConvocacao.ConvocacaoId});
			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}