using System;
using System.Linq;
using System.Net;
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

        // GET: Convocado
        public ActionResult Index(Guid id)
        {
	        ViewBag.Id = id;
	        var dados = _convocadoAppService.Search(a => a.ConvocacaoId.Equals(id));
	        return RedirectToAction(dados.Any() ? "Index" : "Create");
	       
        }

        // GET: Convocado/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id.Equals(null)) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var convocadoViewModel = _convocadoAppService.GetById(Guid.Parse(id.ToString()));
            return convocadoViewModel.Equals(null) ? (ActionResult) HttpNotFound() : View(convocadoViewModel);
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
        public ActionResult Edit(Guid? id)
        {
            if (id.Equals(null)) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var convocadoViewModel = _convocadoAppService.GetById(Guid.Parse(id.ToString()));
            return convocadoViewModel.Equals(null) ? (ActionResult) HttpNotFound() : View(convocadoViewModel);
        }

        // POST: Convocado/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ConvocadoViewModel convocadoViewModel)
        {
            if (!ModelState.IsValid) return View(convocadoViewModel);
            _convocadoAppService.Update(convocadoViewModel);
            return RedirectToAction("Index");
        }

        // GET: Convocado/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id.Equals(null)) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var convocadoViewModel = _convocadoAppService.GetById(Guid.Parse(id.ToString()));
            return convocadoViewModel.Equals(null) ? (ActionResult) HttpNotFound() : View(convocadoViewModel);
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
               _convocadoAppService.Dispose();
            
            base.Dispose(disposing);
        }
    }
}
