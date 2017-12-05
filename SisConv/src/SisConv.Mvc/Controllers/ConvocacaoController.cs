using System;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Mvc;
using SisConv.Application.Interfaces.Repository;
using SisConv.Application.ViewModels;
using SisConv.Domain.Interfaces.Services;
using SisConv.Infra.CrossCutting.Identity.Configuration;
using SisConv.Infra.CrossCutting.Identity.Model;

namespace SisConv.Mvc.Controllers
{
	public class ConvocacaoController : Controller
	{
		private readonly IConvocacaoAppService _convocacaoAppService;
		private readonly IEmailServices _emailServices;
		private readonly IEnviadorEmail _enviadorEmail;
		private readonly IConvocadoAppService _convocadoAppService;
		private readonly ApplicationUserManager _userManager;
		private readonly ApplicationSignInManager _signInManager;

		public ConvocacaoController(ApplicationUserManager userManager ,IConvocacaoAppService convocacaoAppService, IEmailServices emailServices, IEnviadorEmail enviadorEmail, IConvocadoAppService convocadoAppService, ApplicationSignInManager signInManager)
		{
			_convocacaoAppService = convocacaoAppService;
			_emailServices = emailServices;
			_enviadorEmail = enviadorEmail;
			_convocadoAppService = convocadoAppService;
			_signInManager = signInManager;
			_userManager = userManager;
		}
		
		public ActionResult Index()
		{
			return View(_convocacaoAppService.GetAll());
		}
		
		public ActionResult Details(Guid? id)
		{
			if (id.Equals(null)) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			var convocacaoViewModel = _convocacaoAppService.GetById(Guid.Parse(id.ToString()));
			return convocacaoViewModel.Equals(null) ? (ActionResult) HttpNotFound() : View(convocacaoViewModel);
		}
		
		public ActionResult Create()
		{
			return View();
		}
		
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Create(ConvocacaoViewModel convocacaoViewModel, string Cargo)
		{
			if (!ModelState.IsValid) return View(convocacaoViewModel);

			var selecionado = convocacaoViewModel.CandidatosSelecionados.Split(',');

			foreach (var t in selecionado)
			{
				convocacaoViewModel.ConvocadoId = Guid.Parse(t);
				var salvos = _convocacaoAppService.Add(convocacaoViewModel);
				if (salvos.Equals(null)) continue;
				var dadosConvocado = _convocadoAppService.GetById(Guid.Parse(t));

				await RegistarCandidato(dadosConvocado);

				var dadosEmail = _emailServices.EnviarEmail(dadosConvocado, "");
				_enviadorEmail.EnviarTokenPorEmail(dadosEmail);
				

			}

			return RedirectToAction("ListaConvocados","Processos", new{cargo = Cargo, id = convocacaoViewModel.ProcessoId});
		}
		
		public ActionResult Edit(Guid? id)
		{
			if (id.Equals(null)) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			var convocacaoViewModel = _convocacaoAppService.GetById(Guid.Parse(id.ToString()));
			return convocacaoViewModel.Equals(null) ? (ActionResult) HttpNotFound() : View(convocacaoViewModel);
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
			return convocacaoViewModel.Equals(null) ? (ActionResult) HttpNotFound() : View(convocacaoViewModel);
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
		public async Task<ActionResult> RegistarCandidato(ConvocadoViewModel model)
		{
			if (ModelState.IsValid)
			{
				var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
				await _userManager.CreateAsync(user, model.Password);
				
			}

			// If we got this far, something failed, redisplay form
			return View(model);
		}
	}
}