﻿using System;
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

	    public HomeController(IConvocadoAppService convocadoAppService, IProcessoAppService processoAppService, IConvocacaoAppService convocacaoAppService)
	    {
		    _convocadoAppService = convocadoAppService;
		    _processoAppService = processoAppService;
		    _convocacaoAppService = convocacaoAppService;
	    }
		
	    public ActionResult Index()
        {
	        if (!User.IsInRole("Convocado")) return View();
	        var dadosConvocado = _convocadoAppService.GetById(Guid.Parse(User.Identity.GetUserId()));

	        ViewBag.dadosConvocado = dadosConvocado;

			 var dadosProcesso = _processoAppService.GetById(dadosConvocado.ProcessoId);

	        ViewBag.dadosProcesso = dadosProcesso;

			ViewBag.dadosConvocacao = _convocacaoAppService.Search(a =>
		        a.ConvocadoId.Equals(dadosConvocado.ConvocadoId) && a.ProcessoId.Equals(dadosProcesso.ProcessoId));

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