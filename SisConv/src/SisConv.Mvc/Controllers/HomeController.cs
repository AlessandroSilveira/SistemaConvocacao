using System;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using SisConv.Application.Interfaces.Repository;

namespace SisConv.Mvc.Controllers
{
    public class HomeController : Controller
    {
	    private readonly IConvocadoAppService _convocadoAppService;

	    public HomeController(IConvocadoAppService convocadoAppService)
	    {
		    _convocadoAppService = convocadoAppService;
	    }
		
	    public ActionResult Index()
        {
            if (User.IsInRole("Convocado"))
            {
	            ViewBag.dadosConvocado = _convocadoAppService.GetById(Guid.Parse(User.Identity.GetUserId()));

            } 
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