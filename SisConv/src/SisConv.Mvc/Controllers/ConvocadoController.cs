using System;
using System.Web.Mvc;
using SisConv.Application.Interfaces.Repository;
using SisConv.Application.ViewModels;
using SisConv.Domain.Enums;
using SisConv.Domain.Services;

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
		public ActionResult Edit(Guid id, bool modal=false)
		{
			var pessoaViewModel = _convocadoAppService.GetById(id);
			RetornaViewBagsDasSelectList();
			ViewBag.modal = modal.ToString();
			return pessoaViewModel.Equals(null) ? (ActionResult)HttpNotFound() : View(pessoaViewModel);
		}

		// POST: Convocado/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(ConvocadoViewModel convocadoViewModel)
		{
			if (!ModelState.IsValid)
			{
				RetornaViewBagsDasSelectList();
				return View(convocadoViewModel);
			}

			if (!_convocadoAppService.VerificaSeHaSobrenome(convocadoViewModel.Nome))
			{
				ModelState.AddModelError("Nome", "O campo nome deve ter um sobrenome");
				RetornaViewBagsDasSelectList();
				return View(convocadoViewModel);
			}
			if (!_convocadoAppService.VerificaSeHaSobrenome(convocadoViewModel.Mae))
			{
				ModelState.AddModelError("Mae", "O campo nome deve ter um sobrenome");
				RetornaViewBagsDasSelectList();
				return View(convocadoViewModel);
			}
			if (!_convocadoAppService.VerificaSeHaSobrenome(convocadoViewModel.Pai))
			{
				ModelState.AddModelError("Pai", "O campo nome deve ter um sobrenome");
				RetornaViewBagsDasSelectList();
				return View(convocadoViewModel);
			}

			_convocadoAppService.Update(convocadoViewModel);


			return RedirectToAction("Edit",new { @id = convocadoViewModel.ConvocadoId,@modal = true});
		}

		private void RetornaViewBagsDasSelectList()
		{
			ViewBag.ListaSexo = _listaOpcoes.MontarListaOpcoes<Sexo>();
			ViewBag.ListaEstados = _listaOpcoes.MontarListaOpcoes<Estados>();
			ViewBag.ListaEstadoCivil = _listaOpcoes.MontarListaOpcoes<EstadoCivil>();
			ViewBag.ListaSimNao = _listaOpcoes.MontarListaOpcoes<SimNao>();
			ViewBag.ListaFatorSanguineo = _listaOpcoes.MontarListaOpcoes<FatorSanguineo>();
			ViewBag.ListaGrauInstrucao = _listaOpcoes.MontarListaOpcoes<GrauInstrucao>();
			ViewBag.ListaNacionalidade = _listaOpcoes.MontarListaOpcoes<Nacionalidade>();
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
