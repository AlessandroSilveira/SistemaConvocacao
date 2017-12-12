﻿using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using SisConv.Application.Interfaces.Repository;
using SisConv.Application.ViewModels;
using SisConv.Infra.CrossCutting.Identity.Configuration;
using SisConv.Infra.CrossCutting.Identity.Model;
using SisConv.Infra.CrossCutting.Identity.Roles;

namespace SisConv.Mvc.Controllers
{
	public class ConvocacaoController : Controller
	{
		private readonly IConvocacaoAppService _convocacaoAppService;
		//private readonly IEmailAppService _emailAppService;
		private readonly IConvocadoAppService _convocadoAppService;
		private readonly ApplicationUserManager _userManager;
		private readonly IDocumentacaoAppService _documentacaoAppService;

		public ConvocacaoController(IConvocacaoAppService convocacaoAppService,
			IConvocadoAppService convocadoAppService, ApplicationUserManager userManager, IDocumentacaoAppService documentacaoAppService)
		{
			_convocacaoAppService = convocacaoAppService;
			_convocadoAppService = convocadoAppService;
			_userManager = userManager;
			_documentacaoAppService = documentacaoAppService;
			//_emailAppService = emailAppService;
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
				//_emailAppService.EnviarEmail(dadosConvocado);
				RegistarCandidatoParaFazerLogin(dadosConvocado);
			}

			return RedirectToAction("ListaConvocados", "Processos", new {cargo = Cargo.ToString(), id = convocacaoViewModel.ProcessoId.ToString()});
		}

		private string GerarSenha()
		{
			return _convocacaoAppService.GerarSenhaUsuario();
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

		private void RegistarCandidatoParaFazerLogin(ConvocadoViewModel convocadoViewModel)
		{
			var dadosConvocado = _convocadoAppService.Search(a => a.ConvocadoId.Equals(convocadoViewModel.ConvocadoId))
				.FirstOrDefault();
		    if (dadosConvocado != null)
		    {
		        var user = new ApplicationUser
		        {
		            Id = dadosConvocado.ConvocadoId.ToString(),
		            UserName = convocadoViewModel.Email,
		            Email = convocadoViewModel.Email
		        };
		        var result = _userManager.Create(user, GerarSenha());
		        var user2 = _userManager.FindByName(dadosConvocado.Email);
		        _userManager.AddToRole(user2.Id, RolesNames.ROLE_CONVOCADO);
			  
		    }
		}

		[HttpPost]
		public ActionResult ConfirmaConvocacao(Guid ProcessoId, Guid ConvocadoId,Guid ConvocacaoId, bool decisao )
		{
			var dadosConvocacao =
				_convocacaoAppService.GetById(ConvocacaoId);

			if (dadosConvocacao != null) dadosConvocacao.Desistente = decisao;

			_convocacaoAppService.Update(dadosConvocacao);

			return RedirectToAction(decisao.Equals(true) ? "DesistenciaCandidato" : "DocumentacaoConvocado", "Convocacao", new {ProcessoId, ConvocadoId, ConvocacaoId});
		}

		public ActionResult DocumentacaoConvocado(Guid ProcessoId, Guid ConvocadoId, Guid ConvocacaoId)
		{
			var dadosConvocado = _convocadoAppService.GetById(Guid.Parse(User.Identity.GetUserId()));
			ViewBag.dadosConvocado = dadosConvocado;

			ViewBag.listaDocumentacao = _documentacaoAppService.Search(a => a.ProcessoId.Equals(ProcessoId));
			return View();
		}

		public ActionResult DesistenciaCandidato(Guid ProcessoId, Guid ConvocadoId, Guid ConvocacaoId)
		{
			ViewBag.dadosConvocacao = _convocacaoAppService.GetById(ConvocadoId);
			return View();
		}
	}
}