using System;
using System.Web.Mvc;
using SisConv.Application.Interfaces.Repository;
using SisConv.Application.ViewModels;
using SisConv.Domain.Core.Enums;
using SisConv.Domain.Core.Services;

namespace SisConv.Mvc.Controllers
{
	public class ConvocadoController : Controller
	{
		private readonly IConvocadoAppService _convocadoAppService;
		private readonly IListaOpcoes _listaOpcoes;
		

		public ConvocadoController(IConvocadoAppService convocadoAppService, IListaOpcoes listaOpcoes)
		{
			_convocadoAppService = convocadoAppService;
			_listaOpcoes = listaOpcoes;
		}

		// GET: Convocado
		public ActionResult Index()
		{
			return View(_convocadoAppService.GetAll());
		}

		// GET: Convocado/Details/5
		public ActionResult Details(Guid id)
		{
			var convocadoViewModel = _convocadoAppService.GetById(id);
			return convocadoViewModel.Equals(null) ? (ActionResult)HttpNotFound() : View(convocadoViewModel);
		}

		// GET: Convocado/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: Convocado/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(ConvocadoViewModel convocadoViewModel)
		{
			if (!ModelState.IsValid) return View(convocadoViewModel);
			_convocadoAppService.Add(convocadoViewModel);
			return RedirectToAction("Index");
		}

		// GET: Convocado/Edit/5
		public ActionResult Edit(Guid id)
		{
			var pessoaViewModel = _convocadoAppService.GetById(id);
			ViewBag.ListaSexo = _listaOpcoes.MontarListaOpcoes<Sexo>();
			ViewBag.ListaEstados = _listaOpcoes.MontarListaOpcoes<Estados>();
			ViewBag.ListaEstadoCivil = _listaOpcoes.MontarListaOpcoes<EstadoCivil>();
			ViewBag.ListaSimNao = _listaOpcoes.MontarListaOpcoes<SimNao>();
			ViewBag.ListaFatorSanguineo = _listaOpcoes.MontarListaOpcoes<FatorSanguineo>();
			return pessoaViewModel.Equals(null) ? (ActionResult)HttpNotFound() : View(pessoaViewModel);
		}

		// POST: Convocado/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(ConvocadoViewModel convocadoViewModel)
		{
			if (!ModelState.IsValid) return View(convocadoViewModel);

			if (!_convocadoAppService.VerificaSeHaSobrenome(convocadoViewModel.Nome))
			{
				ModelState.AddModelError("Nome", "O campo nome deve ter um sobrenome");
				return View(convocadoViewModel);
			}

			_convocadoAppService.Update(convocadoViewModel);
			return RedirectToAction("Index");
		}

		

		// GET: Convocado/Delete/5
		public ActionResult Delete(Guid id)
		{
			var convocadoViewModel = _convocadoAppService.GetById(id);
			return _convocadoAppService.Equals(null) ? (ActionResult)HttpNotFound() : View(convocadoViewModel);
		}

		// POST: Convocado/Delete/5
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
			{
				_convocadoAppService.Dispose();
			}
			base.Dispose(disposing);
		}
	}
}
