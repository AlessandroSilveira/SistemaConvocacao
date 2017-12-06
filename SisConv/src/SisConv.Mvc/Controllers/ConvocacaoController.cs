using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using SisConv.Application.Interfaces.Repository;
using SisConv.Application.ViewModels;
using SisConv.Domain.Interfaces.Services;
using SisConv.Infra.CrossCutting.Identity.Configuration;
using SisConv.Infra.CrossCutting.Identity.Model;
using SisConv.Infra.CrossCutting.Identity.Roles;

namespace SisConv.Mvc.Controllers
{
	public class ConvocacaoController : Controller
	{
		private readonly IConvocacaoAppService _convocacaoAppService;
		private readonly IEmailServices _emailServices;
		private readonly IConvocadoAppService _convocadoAppService;
		private readonly ApplicationUserManager _userManager;

		public ConvocacaoController(IConvocacaoAppService convocacaoAppService, IEmailServices emailServices,
			IConvocadoAppService convocadoAppService, ApplicationUserManager userManager)
		{
			_convocacaoAppService = convocacaoAppService;
			_emailServices = emailServices;
			_convocadoAppService = convocadoAppService;
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
		public ActionResult Create(ConvocacaoViewModel convocacaoViewModel, string Cargo)
		{
			if (!ModelState.IsValid) return View(convocacaoViewModel);

			var selecionado = convocacaoViewModel.CandidatosSelecionados.Split(',');

			foreach (var t in selecionado)
			{
				convocacaoViewModel.ConvocadoId = Guid.Parse(t);
				_convocacaoAppService.Add(convocacaoViewModel);
				var dadosConvocado = _convocadoAppService.GetById(Guid.Parse(t));
				_emailServices.EnviarEmail(dadosConvocado);
				RegistarCandidatoParaFazerLogin(dadosConvocado);
			}

			return RedirectToAction("ListaConvocados", "Processos", new {cargo = Cargo, id = convocacaoViewModel.ProcessoId});
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

		private bool RegistarCandidatoParaFazerLogin(ConvocadoViewModel convocadoViewModel)
		{
			var dadosConvocado = _convocadoAppService.Search(a => a.Email.Equals(convocadoViewModel.ConvocadoId))
				.FirstOrDefault();
			var user = new ApplicationUser
			{
				Id = dadosConvocado.ConvocadoId.ToString(),
				UserName = convocadoViewModel.Email,
				Email = convocadoViewModel.Email
			};
			var result = _userManager.Create(user, dadosConvocado.Password);

			if (result.Succeeded) return false;
			var user2 = _userManager.FindByName(dadosConvocado.Email);
			_userManager.AddToRole(user2.Id, RolesNames.ROLE_CLIENTE);
			return true;
		}
	}
}