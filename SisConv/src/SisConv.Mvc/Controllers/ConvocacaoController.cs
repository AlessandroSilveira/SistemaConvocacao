using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Web.Configuration;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using SisConv.Application.Interfaces.Repository;
using SisConv.Application.ViewModels;
using SisConv.Domain.Core.Enums;
using SisConv.Domain.Core.Services;
using SisConv.Infra.CrossCutting.Identity.Configuration;
using SisConv.Infra.CrossCutting.Identity.Model;
using SisConv.Infra.CrossCutting.Identity.Roles;

namespace SisConv.Mvc.Controllers
{
	public class ConvocacaoController : Controller
	{
		private readonly IConvocacaoAppService _convocacaoAppService;
		private readonly IConvocadoAppService _convocadoAppService;
		private readonly ApplicationUserManager _userManager;
		private readonly IDocumentacaoAppService _documentacaoAppService;
		private readonly IProcessoAppService _processoAppService;
		private readonly IEmailAppService _emailAppService;
		private readonly IEnumDescription _enumDescription;

		public ConvocacaoController(IConvocacaoAppService convocacaoAppService,
			IConvocadoAppService convocadoAppService, 
			ApplicationUserManager userManager, 
			IDocumentacaoAppService documentacaoAppService, 
			IProcessoAppService processoAppService, 
			IEmailAppService emailAppService,
			IEnumDescription enumDescription)
		{
			_convocacaoAppService = convocacaoAppService;
			_convocadoAppService = convocadoAppService;
			_userManager = userManager;
			_documentacaoAppService = documentacaoAppService;
			_processoAppService = processoAppService;
			_emailAppService = emailAppService;
			_enumDescription = enumDescription;
		}

		public ActionResult Index()
		{
			return View(_convocacaoAppService.GetAll());
		}

		public ActionResult Details(Guid? id)
		{
			if (id.Equals(null)) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			var convocacaoViewModel = _convocacaoAppService.GetById(Guid.Parse(id.ToString()));
			return convocacaoViewModel.Equals(null) ? (ActionResult)HttpNotFound() : View(convocacaoViewModel);
		}

		public ActionResult Create()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(ConvocacaoViewModel convocacaoViewModel, string Cargo)
		{
			if (!ModelState.IsValid) return View(convocacaoViewModel);

			var selecionado = convocacaoViewModel.CandidatosSelecionados.Split(',');
			var confirmacao = false;

			convocacaoViewModel.StatusConvocacao =_enumDescription.GetEnumDescription(StatusConvocacao.EmConvocacao);

			foreach (var t in selecionado)
			{
				var dadosConvocado = _convocadoAppService.GetById(Guid.Parse(t));
				RegistarCandidatoParaFazerLogin(dadosConvocado);
				convocacaoViewModel.ConvocadoId = Guid.Parse(t);
				var gravaConvocacao = _convocacaoAppService.Add(convocacaoViewModel);
				if (gravaConvocacao == null)				
					break;				
				else				
					confirmacao = true;				

				_emailAppService.EnviarEmail(dadosConvocado);
			}

			return RedirectToAction("ListaConvocados", "Processos", new { @ProcessoId = convocacaoViewModel.ProcessoId.ToString(), @cargo = Cargo, @confirmacao = confirmacao });
		}

		private string GerarSenha()
		{
			return _convocacaoAppService.GerarSenhaUsuario();
		}

		public ActionResult Edit(Guid? id)
		{
			if (id.Equals(null)) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			var convocacaoViewModel = _convocacaoAppService.GetById(Guid.Parse(id.ToString()));
			return convocacaoViewModel.Equals(null) ? (ActionResult)HttpNotFound() : View(convocacaoViewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(ConvocacaoViewModel convocacaoViewModel)
		{
			if (!ModelState.IsValid) return View(convocacaoViewModel);
			_convocacaoAppService.Update(convocacaoViewModel);
			return RedirectToAction("Index");
		}

		public ActionResult Delete(Guid? id)
		{
			if (id.Equals(null)) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			var convocacaoViewModel = _convocacaoAppService.GetById(Guid.Parse(id.ToString()));
			return convocacaoViewModel.Equals(null) ? (ActionResult)HttpNotFound() : View(convocacaoViewModel);
		}

		[HttpPost]
		[ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(Guid id)
		{
			_convocacaoAppService.Remove(id);
			return RedirectToAction("Index");
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
				_convocacaoAppService.Dispose();

			base.Dispose(disposing);
		}

		private void RegistarCandidatoParaFazerLogin(ConvocadoViewModel convocadoViewModel)
		{
			if (ObterDadosConvocado(convocadoViewModel, out var dadosConvocado)) return;

			var user = new ApplicationUser
			{
				Id = dadosConvocado.ConvocadoId.ToString(),
				UserName = convocadoViewModel.Email,
				Email = convocadoViewModel.Email
			};

			var dados = _userManager.FindByEmail(user.Email);
			if (dados != null) return;
			_userManager.Create(user, GerarSenha());
			var user2 = _userManager.FindByName(dadosConvocado.Email);
			_userManager.AddToRole(user2.Id, RolesNames.ROLE_CONVOCADO);
		}

		private bool ObterDadosConvocado(ConvocadoViewModel convocadoViewModel, out ConvocadoViewModel dadosConvocado)
		{
			dadosConvocado = _convocadoAppService.Search(a => a.ConvocadoId.Equals(convocadoViewModel.ConvocadoId))
				.FirstOrDefault();
			if (dadosConvocado == null) return true;
			return false;
		}

		[HttpPost]
		public ActionResult ConfirmaConvocacao(Guid ProcessoId, Guid ConvocadoId, Guid ConvocacaoId, string decisao)
		{
			var dadosConvocacao =
				_convocacaoAppService.GetById(ConvocacaoId);

			dadosConvocacao.Desistente = decisao;

			if(decisao.Equals("S"))
				dadosConvocacao.StatusConvocacao = _enumDescription.GetEnumDescription(StatusConvocacao.Desistente);
			else
				dadosConvocacao.StatusConvocacao = _enumDescription.GetEnumDescription(StatusConvocacao.EmConvocacao);

			_convocacaoAppService.Update(dadosConvocacao);
			return RedirectToAction(decisao.Equals("S") ? "DesistenciaCandidato" : "DocumentacaoConvocado", "Convocacao", new { ProcessoId, ConvocadoId, ConvocacaoId });
		}

		public ActionResult DocumentacaoConvocado(Guid ProcessoId, Guid ConvocadoId, Guid ConvocacaoId)
		{
			ViewBag.dadosProcesso = _processoAppService.GetById(ProcessoId);
			var dadosConvocado = _convocadoAppService.GetById(Guid.Parse(User.Identity.GetUserId()));
			ViewBag.dadosConvocado = dadosConvocado;
			ViewBag.listaDocumentacao = _documentacaoAppService.Search(a => a.ProcessoId.Equals(ProcessoId));
			return View();
		}


		public  void Download(string arquivo)
		{
			
			var pathArquivo = WebConfigurationManager.AppSettings[@"SisConvDocs"];
			var caminhoArquivo = Path.Combine(pathArquivo, arquivo);
			var fInfo = new FileInfo(caminhoArquivo);
			HttpContext.Response.Clear();
			HttpContext.Response.ContentType = "application/octet-stream";
			HttpContext.Response.AddHeader("Content-Disposition", "attachment; filename=\"" + fInfo.Name + "\"");
			HttpContext.Response.AddHeader("Content-Length", fInfo.Length.ToString());
			HttpContext.Response.Flush();
			HttpContext.Response.WriteFile(fInfo.FullName);
			fInfo = null;
		}

		public ActionResult DesistenciaCandidato(Guid ProcessoId, Guid ConvocadoId, Guid ConvocacaoId)
		{
			ViewBag.dadosConvocacao = _convocacaoAppService.GetById(ConvocacaoId);
			var dadosConvocado = _convocadoAppService.GetById(ConvocadoId);
			ViewBag.dadosConvocado = dadosConvocado;
			ViewBag.dadosProcesso = _processoAppService.GetById(ProcessoId);
			return View();
		}
	}
}