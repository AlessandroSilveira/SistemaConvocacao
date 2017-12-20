using System;
using System.Web.Mvc;
using SisConv.Application.Interfaces.Repository;
using SisConv.Application.ViewModels;

namespace SisConv.Mvc.Controllers
{
	public class ConvocadoController : Controller
	{
		private readonly IConvocadoAppService _convocadoAppService;

		public ConvocadoController(IConvocadoAppService convocadoAppService)
		{
			_convocadoAppService = convocadoAppService;
		}

		public ActionResult Index()
		{
			return View(_convocadoAppService.GetAll());
		}

		public ActionResult Details(Guid id)
		{
			var convocadoViewModel = _convocadoAppService.GetById(id);
			return convocadoViewModel.Equals(null) ? (ActionResult)HttpNotFound() : View(convocadoViewModel);
		}

		public ActionResult Create()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(ConvocadoViewModel convocadoViewModel)
		{
			if (!ModelState.IsValid) return View(convocadoViewModel);
			_convocadoAppService.Add(convocadoViewModel);
			return RedirectToAction("Index");

		}

		public ActionResult Edit(Guid id)
		{
			var convocadoViewModel = _convocadoAppService.GetById(id);
			return convocadoViewModel.Equals(null) ? (ActionResult)HttpNotFound() : View(convocadoViewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(ConvocadoViewModel convocadoViewModel)
		{
			if (!ModelState.IsValid) return View(convocadoViewModel);
			_convocadoAppService.Update(convocadoViewModel);
			return RedirectToAction("Index");
		}

		public ActionResult Delete(Guid id)
		{
			var convocadoViewModel = _convocadoAppService.GetById(id);
			return convocadoViewModel.Equals(null) ? (ActionResult)HttpNotFound() : View(convocadoViewModel);
		}

		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(Guid id)
		{
			_convocadoAppService.Remove(id);
			return RedirectToAction("Index");
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
				_convocadoAppService.Dispose();

			base.Dispose(disposing);
		}
	}
}
