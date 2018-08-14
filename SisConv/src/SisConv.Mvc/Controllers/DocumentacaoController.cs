using System;
using System.IO;
using System.Web.Configuration;
using System.Web.Mvc;
using SisConv.Application.Interfaces.Repository;
using SisConv.Application.ViewModels;

namespace SisConv.Mvc.Controllers
{
    [Authorize(Roles = "Cliente")]
    public class DocumentacaoController : Controller
    {
        private readonly IDocumentacaoAppService _documentacaoAppService;

        public DocumentacaoController(IDocumentacaoAppService documentacaoAppService)
        {
            _documentacaoAppService = documentacaoAppService;
        }

        public ActionResult Index(Guid Id)
        {
            ViewBag.ProcessoId = Id;
            return View(_documentacaoAppService.GetAll());
        }

        public ActionResult Details(Guid id)
        {
            var documentacaoViewModel = _documentacaoAppService.GetById(id);
            return documentacaoViewModel == null ? (ActionResult) HttpNotFound() : View(documentacaoViewModel);
        }

        public ActionResult Create(Guid Id)
        {
            ViewBag.ProcessoId = Id;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DocumentacaoViewModel documentacaoViewModel)
        {
            documentacaoViewModel.DataCriacao = DateTime.Now;
            if (!ModelState.IsValid) return View(documentacaoViewModel);

            var path = SalvarArquivoConvocados(documentacaoViewModel);

            if (string.IsNullOrEmpty(path)) return RedirectToAction("Index");
            documentacaoViewModel.Path = path;
            _documentacaoAppService.Add(documentacaoViewModel);

            return RedirectToAction("Index", new {Id = documentacaoViewModel.ProcessoId});
        }

        private string SalvarArquivoConvocados(DocumentacaoViewModel documentacaoViewModel)
        {
            var pathArquivo = WebConfigurationManager.AppSettings["SisConvDocs"];
            pathArquivo = pathArquivo.Replace(@"\\", @"\");
            var arquivo = Request.Files[0];
            if (arquivo == null)
                return string.Empty;

            var nomeArquivo = Path.GetFileName(arquivo.FileName);

            if (Directory.Exists(pathArquivo) == false)
                Directory.CreateDirectory(pathArquivo);

            if (nomeArquivo != null)
                arquivo.SaveAs(Path.Combine(pathArquivo, nomeArquivo));

            return nomeArquivo;
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
            var documento = _documentacaoAppService.GetById(id);
            _documentacaoAppService.Remove(id);
            return RedirectToAction("Index", new {id = documento.ProcessoId});
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _documentacaoAppService.Dispose();
            base.Dispose(disposing);
        }
    }
}