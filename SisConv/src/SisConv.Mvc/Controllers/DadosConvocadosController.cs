using System;
using System.IO;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using SisConv.Application.Interfaces.Repository;
using SisConv.Application.ViewModels;
using SisConv.Infra.Data.Context;

namespace SisConv.Mvc.Controllers
{
	public class DadosConvocadosController : Controller
	{
		private readonly IDadosConvocacaoAppService _dadosConvocacaoAppService;

		public DadosConvocadosController(IDadosConvocacaoAppService dadosConvocacaoAppService)
		{
			_dadosConvocacaoAppService = dadosConvocacaoAppService;
		}

		// GET: DadosConvocados
        //public ActionResult Index()
        //{
        //    return View(db.DadosConvocadosViewModels.ToList());
        //}

        // GET: DadosConvocados/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    DadosConvocadosViewModel dadosConvocadosViewModel = db.DadosConvocadosViewModels.Find(id);
        //    if (dadosConvocadosViewModel == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(dadosConvocadosViewModel);
        //}

        // GET: DadosConvocados/Create
        public ActionResult Create(Guid id)
        {
            ViewBag.id = id;
            return View();
        }

        // POST: DadosConvocados/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,File")] DadosConvocadosViewModel dadosConvocadosViewModel)
        {
            if (ModelState.IsValid)
            {
                var pathArquivo = WebConfigurationManager.AppSettings["SisConvDocs"];
                var arquivo = Request.Files[0];
                var nomeArquivo = Path.GetFileName(arquivo.FileName);
                ActionResult view;
                if (SalvarArquivoConvocados(out view)) 

                _dadosConvocacaoAppService.SalvarCandidatos(dadosConvocadosViewModel.Id, string.Format("{0}{1}",pathArquivo,nomeArquivo));

            }

            return View(dadosConvocadosViewModel);
        }

	    private bool SalvarArquivoConvocados(out ActionResult view)
	    {
	        var pathArquivo = WebConfigurationManager.AppSettings["SisConvDocs"];
	        var arquivo = Request.Files[0];
	        if (arquivo == null)
	        {
	            view = null;
	            return false;
	        }
	        var nomeArquivo = Path.GetFileName(arquivo.FileName);
	        var strExtension = Path.GetExtension(arquivo.FileName)?.ToLower();

	        if (VerificaArquivoExcel(out view, strExtension)) return true;

	        if (!Directory.Exists(pathArquivo))
	            Directory.CreateDirectory(pathArquivo);

	        arquivo.SaveAs(pathArquivo + nomeArquivo);
	        return true;
	    }

	    private bool VerificaArquivoExcel(out ActionResult view, string strExtension)
	    {
	        if (strExtension != ".xls" && strExtension != ".xlsx")
	        {
	            ModelState.AddModelError("Erro", "Arquivo Inválido");
	            {
	                view = View();
	                return true;
	            }
	        }
	        view = null;
	        return false;
	    }

	    // GET: DadosConvocados/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    DadosConvocadosViewModel dadosConvocadosViewModel = db.DadosConvocadosViewModels.Find(id);
        //    if (dadosConvocadosViewModel == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(dadosConvocadosViewModel);
        //}

        // POST: DadosConvocados/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,File")] DadosConvocadosViewModel dadosConvocadosViewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(dadosConvocadosViewModel).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(dadosConvocadosViewModel);
        //}

        // GET: DadosConvocados/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    DadosConvocadosViewModel dadosConvocadosViewModel = db.DadosConvocadosViewModels.Find(id);
        //    if (dadosConvocadosViewModel == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(dadosConvocadosViewModel);
        //}

        // POST: DadosConvocados/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    DadosConvocadosViewModel dadosConvocadosViewModel = db.DadosConvocadosViewModels.Find(id);
        //    db.DadosConvocadosViewModels.Remove(dadosConvocadosViewModel);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dadosConvocacaoAppService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
