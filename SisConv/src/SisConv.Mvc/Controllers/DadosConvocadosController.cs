using System.Web.Mvc;
using SisConv.Application.Interfaces.Repository;
using SisConv.Application.ViewModels;
using SisConv.Infra.Data.Context;

namespace SisConv.Mvc.Controllers
{
	public class DadosConvocadosController : Controller
	{
		private readonly IConvocadoAppService _convocadoAppService;

		public DadosConvocadosController(IConvocadoAppService convocadoAppService)
		{
			_convocadoAppService = convocadoAppService;
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
        public ActionResult Create()
        {
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
	            _convocadoAppService.SalvarCandidatos(dadosConvocadosViewModel.File);

            }

            return View(dadosConvocadosViewModel);
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
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
