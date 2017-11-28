using System;
using System.IO;
using System.Web.Configuration;
using System.Web.Mvc;
using SisConv.Application.Interfaces.Repository;
using SisConv.Application.ViewModels;

namespace SisConv.Mvc.Controllers
{
	public class DadosConvocadosController : Controller
	{
		private readonly IDadosConvocacaoAppService _dadosConvocacaoAppService;

		public DadosConvocadosController(IDadosConvocacaoAppService dadosConvocacaoAppService)
		{
			_dadosConvocacaoAppService = dadosConvocacaoAppService;
		}
		
		public ActionResult Create(Guid id)
		{
			ViewBag.id = id;
			return View();
		}
		
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create( DadosConvocadosViewModel dadosConvocadosViewModel)
		{
			if (!ModelState.IsValid) return View(dadosConvocadosViewModel);

			var pathArquivo = WebConfigurationManager.AppSettings["SisConvDocs"];
			var arquivo = Request.Files[0];
			if (arquivo == null) return View(dadosConvocadosViewModel);
			var nomeArquivo = Path.GetFileName(arquivo.FileName);

			if (SalvarArquivoConvocados(out _))
				_dadosConvocacaoAppService.SalvarCargos(dadosConvocadosViewModel.Id,
					string.Format("{0}{1}", pathArquivo, nomeArquivo));
			_dadosConvocacaoAppService.SalvarCandidatos(dadosConvocadosViewModel.Id,
				string.Format("{0}{1}", pathArquivo, nomeArquivo));

			return RedirectToAction("Index", "Processos");
		}

		private bool SalvarArquivoConvocados(out ActionResult view)
		{
			var pathArquivo = WebConfigurationManager.AppSettings["SisConvDocs"];
			var arquivo = Request.Files[0];
			if (arquivo == null)
			{
				view = null;
				return false;
			}
			var nomeArquivo = Path.GetFileName(arquivo.FileName);
			var strExtension = Path.GetExtension(arquivo.FileName)?.ToLower();

			if (VerificaArquivoExcel(out view, strExtension)) return true;

			if (!Directory.Exists(pathArquivo))
				Directory.CreateDirectory(pathArquivo);

			arquivo.SaveAs(pathArquivo + nomeArquivo);
			return true;
		}

		private bool VerificaArquivoExcel(out ActionResult view, string strExtension)
		{
			if (!strExtension.Equals(".xls") && !strExtension.Equals(".xlsx"))
			{
				ModelState.AddModelError("Erro", "Arquivo Inválido");
				{
					view = View();
					return true;
				}
			}
			view = null;
			return false;
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
				_dadosConvocacaoAppService.Dispose();

			base.Dispose(disposing);
		}
	}
}