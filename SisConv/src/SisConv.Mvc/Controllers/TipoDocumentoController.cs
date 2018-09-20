using SisConv.Application.Interfaces.Repository;
using SisConv.Application.ViewModels;
using System;
using System.Net;
using System.Web.Mvc;

namespace SisConv.Mvc.Controllers
{
    public class TipoDocumentoController : Controller
    {
        private readonly ITipoDocumentoAppService _tipoDocumentoAppService;
        private readonly IProcessoAppService _processoAppService;

        public TipoDocumentoController(
            ITipoDocumentoAppService tipoDocumentoAppService,
            IProcessoAppService processoAppService
            )
        {
            _tipoDocumentoAppService = tipoDocumentoAppService;
            _processoAppService = processoAppService;
        }

        // GET: TipoDocumento
        public ActionResult Index(Guid Id)
        {
            ViewBag.dadosProcesso = _processoAppService.GetById(Id);
            ViewBag.ProcessoId = Id;
            return View(_tipoDocumentoAppService.GetAll());
        }

        // GET: TipoDocumento/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id.Equals(null))
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            if (_tipoDocumentoAppService.GetById(Guid.Parse(id.ToString())).Equals(null))
                return HttpNotFound();

            return View(_tipoDocumentoAppService.GetById(Guid.Parse(id.ToString())));
        }

        // GET: TipoDocumento/Create
        public ActionResult Create(Guid Id)
        {
            ViewBag.dadosProcesso = _processoAppService.GetById(Id);
            ViewBag.ProcessoId = Id;
            return View();
        }

        // POST: TipoDocumento/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TipoDocumentoViewModel tipoDocumentoViewModel)
        {
            if (!ModelState.IsValid)
                return View(tipoDocumentoViewModel);

            ViewBag.dadosProcesso = _processoAppService.GetById(tipoDocumentoViewModel.ProcessoId);
            ViewBag.ProcessoId = tipoDocumentoViewModel.ProcessoId;

            tipoDocumentoViewModel.TipoDocumentoId = Guid.NewGuid();
            _tipoDocumentoAppService.Add(tipoDocumentoViewModel);
            return RedirectToAction("Index", new { Id = tipoDocumentoViewModel.TipoDocumentoId });
        }

        // GET: TipoDocumento/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id.Equals(null))
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var docCandidatoViewModel = _tipoDocumentoAppService.GetById(Guid.Parse(id.ToString()));
            ViewBag.dadosProcesso = _processoAppService.GetById(docCandidatoViewModel.ProcessoId);
            ViewBag.ProcessoId = docCandidatoViewModel.ProcessoId;
            return docCandidatoViewModel.Equals(null) ? (ActionResult)HttpNotFound() : View(docCandidatoViewModel);
        }

        // POST: TipoDocumento/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TipoDocumentoViewModel tipoDocumentoViewModel)
        {
            if (!ModelState.IsValid)
                return View(tipoDocumentoViewModel);

            ViewBag.dadosProcesso = _processoAppService.GetById(tipoDocumentoViewModel.ProcessoId);
            ViewBag.ProcessoId = tipoDocumentoViewModel.ProcessoId;

            _tipoDocumentoAppService.Update(tipoDocumentoViewModel);
            return RedirectToAction("Index", new { Id = tipoDocumentoViewModel.TipoDocumentoId });
        }

        // GET: TipoDocumento/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id.Equals(null))
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var docCandidatoViewModel = _tipoDocumentoAppService.GetById(Guid.Parse(id.ToString()));
            ViewBag.dadosProcesso = _processoAppService.GetById(docCandidatoViewModel.ProcessoId);
            ViewBag.ProcessoId = docCandidatoViewModel.ProcessoId;

            return _tipoDocumentoAppService.GetById(Guid.Parse(id.ToString())).Equals(null)
                ? (ActionResult)HttpNotFound()
                : View(_tipoDocumentoAppService.GetById(Guid.Parse(id.ToString())));
        }

        // POST: TipoDocumento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            var docCandidatoViewModel = _tipoDocumentoAppService.GetById(Guid.Parse(id.ToString()));
            ViewBag.dadosProcesso = _processoAppService.GetById(docCandidatoViewModel.ProcessoId);
            ViewBag.ProcessoId = docCandidatoViewModel.ProcessoId;
            _tipoDocumentoAppService.Remove(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _tipoDocumentoAppService.Dispose();

            base.Dispose(disposing);
        }
    }
}