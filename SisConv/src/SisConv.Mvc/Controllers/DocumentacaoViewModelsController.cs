using System;
using System.Web.Mvc;
using SisConv.Application.Interfaces.Repository;
using SisConv.Application.ViewModels;

namespace SisConv.Mvc.Controllers
{
    public class DocumentacaoViewModelsController : Controller
    {
        private readonly IDocumentacaoAppService _documentacaoAppService;

        public DocumentacaoViewModelsController(IDocumentacaoAppService documentacaoAppService)
        {
            _documentacaoAppService = documentacaoAppService;
        }
       
        public ActionResult Index()
        {
            return View(_documentacaoAppService.GetAll());
        }
        
        public ActionResult Details(Guid id)
        {
            var documentacaoViewModel = _documentacaoAppService.GetById(id);
            return documentacaoViewModel == null ? (ActionResult) HttpNotFound() : View(documentacaoViewModel);
        }
       
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
            [Bind(Include = "DocumentoId,ProcessoId,Descricao,DataCriacao,Path,Ativo")]
            DocumentacaoViewModel documentacaoViewModel)
        {
            if (!ModelState.IsValid) return View(documentacaoViewModel);
            _documentacaoAppService.Add(documentacaoViewModel);
            return RedirectToAction("Index");
        }

       public ActionResult Edit(Guid id)
        {
            var documentacaoViewModel = _documentacaoAppService.GetById(id);
            return documentacaoViewModel == null ? (ActionResult) HttpNotFound() : View(documentacaoViewModel);
        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(
            [Bind(Include = "DocumentoId,ProcessoId,Descricao,DataCriacao,Path,Ativo")]
            DocumentacaoViewModel documentacaoViewModel)
        {
            if (!ModelState.IsValid) return View(documentacaoViewModel);
            _documentacaoAppService.Update(documentacaoViewModel);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(Guid id)
        {
            var documentacaoViewModel = _documentacaoAppService.GetById(id);
            return documentacaoViewModel == null ? (ActionResult) HttpNotFound() : View(documentacaoViewModel);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _documentacaoAppService.Remove(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _documentacaoAppService.Dispose();
            base.Dispose(disposing);
        }
    }
}