using SisConv.Application.Interfaces.Repository;
using SisConv.Application.ViewModels;
using System;
using System.IO;
using System.Net;
using System.Web.Configuration;
using System.Web.Mvc;

namespace SisConv.Mvc.Controllers
{
    public class DocumentoCandidatoController : Controller
    {
        private readonly IDocumentoCandidatoAppService _documentoCandidatoAppService;
        private readonly ITipoDocumentoAppService _tipoDocumentoAppService;
        private readonly IConvocadoAppService _convocadoAppService;
        private readonly IProcessoAppService _processoAppService;

        public DocumentoCandidatoController(
            IDocumentoCandidatoAppService documentoCandidatoAppService,
             ITipoDocumentoAppService tipoDocumentoAppService,
             IConvocadoAppService convocadoAppService,
             IProcessoAppService processoAppService
            )
        {
            _documentoCandidatoAppService = documentoCandidatoAppService;
            _tipoDocumentoAppService = tipoDocumentoAppService;
            _convocadoAppService = convocadoAppService;
            _processoAppService = processoAppService;
        }

        // GET: DocumentoCandidato
        public ActionResult Index(Guid id, Guid ProcessoId, bool arquivoExiste = false)
        {
            ViewBag.ConvocacaoId = id;
            ViewBag.dadosConvocado = _convocadoAppService.GetById(id);
            ViewBag.dadosProcesso = _processoAppService.GetById(ProcessoId);
            ViewBag.ProcessoId = ProcessoId;
            ViewBag.ArquivoExiste = arquivoExiste;
            return View(_documentoCandidatoAppService.Search(a => a.ConvocadoId == id));
        }

        public ActionResult ListaDocumentos(Guid ProcessoId)
        {
            var documentos = _documentoCandidatoAppService.Search(a => a.ProcessoId == ProcessoId);
            var dadosCandidatos = _convocadoAppService.GetAll();
            ViewBag.ProcessoId = ProcessoId;
            ViewBag.dadosProcesso = _processoAppService.GetById(ProcessoId);
            return View(_documentoCandidatoAppService.MontarListaDeDocumentosDoCandidatos(documentos, dadosCandidatos));
        }

        // GET: DocumentoCandidato/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id.Equals(null))
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            if (_documentoCandidatoAppService.GetById(Guid.Parse(id.ToString())).Equals(null))
                return HttpNotFound();

            return View(_documentoCandidatoAppService.GetById(Guid.Parse(id.ToString())));
        }

        // GET: DocumentoCandidato/Create
        public ActionResult Create(Guid id, Guid ProcessoId)
        {
            ViewBag.ConvocacaoId = id;
            ViewBag.ProcessoId = ProcessoId;
            ViewBag.dadosDocumentoCandidato = _documentoCandidatoAppService.GetById(id);
            ViewBag.dadosConvocado = _convocadoAppService.GetById(id);
            ViewBag.DadosProcesso = _processoAppService.GetById(ProcessoId);
            ViewBag.ListaTipoDocumento = _tipoDocumentoAppService.Search(a => a.Ativo);
            return View();
        }

        // POST: DocumentoCandidato/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DocumentoCandidatoViewModel documentoCandidatoViewModel)
        {
            if (!ModelState.IsValid) return View(documentoCandidatoViewModel);

            var pathArquivo = WebConfigurationManager.AppSettings["SisConvDocs"];
            var arquivo = Request.Files[0];
            var nomeArquivo = Path.GetFileName(arquivo.FileName);

            var file = new FileInfo(Path.Combine(pathArquivo, nomeArquivo));

            if (!file.Exists)
            {
                documentoCandidatoViewModel.DocumentoCandidatoId = Guid.NewGuid();
                documentoCandidatoViewModel.Path = SalvarDocumemento(documentoCandidatoViewModel);
                documentoCandidatoViewModel.DataInclusao = DateTime.Now;
                documentoCandidatoViewModel.Documento = nomeArquivo;
                _documentoCandidatoAppService.Add(documentoCandidatoViewModel);
                return RedirectToAction("Index", new { id = documentoCandidatoViewModel.ConvocadoId, ProcessoId = documentoCandidatoViewModel.ProcessoId });
            }
            else
            {
                return RedirectToAction("Index", new { id = documentoCandidatoViewModel.ConvocadoId, ProcessoId = documentoCandidatoViewModel.ProcessoId, @arquivoExiste = true });
            }
        }

        public string SalvarDocumemento(DocumentoCandidatoViewModel documentoCandidatoViewModel)
        {
            var pathArquivo = WebConfigurationManager.AppSettings["SisConvDocs"];
            var caminho = pathArquivo.Replace(@"\\\\", @"\");
            var arquivo = Request.Files[0];
            if (arquivo == null)
                return string.Empty;

            var nomeArquivo = Path.GetFileName(arquivo.FileName);

            if (!Directory.Exists(pathArquivo))
                Directory.CreateDirectory(pathArquivo);

            if (nomeArquivo != null)
                arquivo.SaveAs(Path.Combine(pathArquivo, nomeArquivo));

            return nomeArquivo;
        }

        // GET: DocumentoCandidato/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id.Equals(null)) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var docCandidatoViewModel = _documentoCandidatoAppService.GetById(Guid.Parse(id.ToString()));
            return docCandidatoViewModel.Equals(null) ? (ActionResult)HttpNotFound() : View(docCandidatoViewModel);
        }

        // POST: DocumentoCandidato/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DocumentoCandidatoViewModel documentoCandidatoViewModel)
        {
            if (!ModelState.IsValid) return View(documentoCandidatoViewModel);
            _documentoCandidatoAppService.Update(documentoCandidatoViewModel);
            return RedirectToAction("Index", new { Id = documentoCandidatoViewModel.ProcessoId });
        }

        // GET: DocumentoCandidato/Delete/5
        public ActionResult Delete(Guid? id, Guid ConvocadoId, Guid ProcessoId)
        {
            ViewBag.ConvocadoId = ConvocadoId;
            ViewBag.ProcessoId = ProcessoId;
            ViewBag.dadosConvocado = _convocadoAppService.GetById(ConvocadoId);
            ViewBag.DadosProcesso = _processoAppService.GetById(ProcessoId);

            if (id.Equals(null)) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            return _documentoCandidatoAppService.GetById(Guid.Parse(id.ToString())).Equals(null)
                ? (ActionResult)HttpNotFound()
                : View(_documentoCandidatoAppService.GetById(Guid.Parse(id.ToString())));
        }

        // POST: DocumentoCandidato/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id, Guid ConvocadoId, Guid ProcessoId)
        {
            ViewBag.ConvocadoId = ConvocadoId;
            ViewBag.ProcessoId = ProcessoId;
            ViewBag.dadosConvocado = _convocadoAppService.GetById(ConvocadoId);
            ViewBag.DadosProcesso = _processoAppService.GetById(ProcessoId);

            _documentoCandidatoAppService.Remove(id);
            return RedirectToAction("Index", new { @id = ConvocadoId, @ProcessoId = ProcessoId });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _documentoCandidatoAppService.Dispose();

            base.Dispose(disposing);
        }

        public void Download(Guid DocumentoCandidatoId)
        {

            var dadosDocumento = _documentoCandidatoAppService.GetById(DocumentoCandidatoId);

            var pathArquivo = WebConfigurationManager.AppSettings[@"SisConvDocs"];
            var caminhoArquivo = Path.Combine(pathArquivo, dadosDocumento.Path);
            var fInfo = new FileInfo(caminhoArquivo);
            HttpContext.Response.Clear();
            HttpContext.Response.ContentType = "application/octet-stream";
            HttpContext.Response.AddHeader("Content-Disposition", "attachment; filename=\"" + fInfo.Name + "\"");
            HttpContext.Response.AddHeader("Content-Length", fInfo.Length.ToString());
            HttpContext.Response.Flush();
            HttpContext.Response.WriteFile(fInfo.FullName);
            fInfo = null;
        }

        public ActionResult Protocolo(Guid id, Guid ConvocadoId, Guid ProcessoId)
        {
            ViewBag.dadosDocumentoCandidato = _documentoCandidatoAppService.GetById(id);
            ViewBag.dadosConvocado = _convocadoAppService.GetById(ConvocadoId);
            ViewBag.DadosProcesso = _processoAppService.GetById(ProcessoId);
            return View();
        }
    }
}