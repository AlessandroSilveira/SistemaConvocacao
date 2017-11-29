using System;
using System.Net;
using System.Web.Mvc;
using SisConv.Application.Interfaces.Repository;
using SisConv.Application.ViewModels;

namespace SisConv.Mvc.Controllers
{
	public class ConvocacaoController : Controller
	{
		private readonly IConvocacaoAppService _convocacaoAppService;

		public ConvocacaoController(IConvocacaoAppService convocacaoAppService)
		{
			_convocacaoAppService = convocacaoAppService;
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
		public ActionResult Create(ConvocacaoViewModel convocacaoViewModel)
		{
			if (!ModelState.IsValid) return View(convocacaoViewModel);

			var selecionado = convocacaoViewModel.CandidatosSelecionados.Split(',');

			foreach (var t in selecionado)
			{
				convocacaoViewModel.ConvocadoId = Guid.Parse(t);
				_convocacaoAppService.Add(convocacaoViewModel);
			}

			return RedirectToAction("Index");
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
	}
}