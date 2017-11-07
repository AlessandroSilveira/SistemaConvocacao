using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using SisConv.Application.Interfaces.Repository;
using SisConv.Application.ViewModels;
using SisConv.Infra.Data.Context;

namespace SisConv.Mvc.Controllers
{
    public class ConvocacaoController : Controller
    {
        private readonly IConvocacaoAppService _convocacaoAppService;

        public ConvocacaoController(IConvocacaoAppService convocacaoAppService)
        {
            _convocacaoAppService = convocacaoAppService;
        }

        // GET: Convocacao
        public ActionResult Index()
        {
            return View(_convocacaoAppService.GetAll());
        }

        // GET: Convocacao/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id.Equals(null)) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var convocacaoViewModel = _convocacaoAppService.GetById(Guid.Parse(id.ToString()));
            return convocacaoViewModel.Equals(null) ? (ActionResult) HttpNotFound() : View(convocacaoViewModel);
        }

        // GET: Convocacao/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Convocacao/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ConvocacaoViewModel convocacaoViewModel)
        {
            if (!ModelState.IsValid) return View(convocacaoViewModel);
            _convocacaoAppService.Add(convocacaoViewModel);
            return RedirectToAction("Index");
        }

        // GET: Convocacao/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id.Equals(null)) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var convocacaoViewModel = _convocacaoAppService.GetById(Guid.Parse(id.ToString()));
            return convocacaoViewModel.Equals(null) ? (ActionResult) HttpNotFound() : View(convocacaoViewModel);
        }

        // POST: Convocacao/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ConvocacaoViewModel convocacaoViewModel)
        {
            if (!ModelState.IsValid) return View(convocacaoViewModel);
            _convocacaoAppService.Update(convocacaoViewModel);
            return RedirectToAction("Index");
        }

        // GET: Convocacao/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id.Equals(null)) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var convocacaoViewModel = _convocacaoAppService.GetById(Guid.Parse(id.ToString()));
            return convocacaoViewModel.Equals(null) ? (ActionResult) HttpNotFound() : View(convocacaoViewModel);
        }

        // POST: Convocacao/Delete/5
        [HttpPost, ActionName("Delete")]
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
