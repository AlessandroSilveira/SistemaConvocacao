using System;
using System.Net;
using System.Web.Mvc;
using SisConv.Application.Interfaces.Repository;
using SisConv.Application.ViewModels;

namespace SisConv.Mvc.Controllers
{
    public class CargoController : Controller
    {
        private readonly ICargoAppService _cargoAppService;

        public CargoController(ICargoAppService cargoAppService)
        {
            _cargoAppService = cargoAppService;
        }

        // GET: Cargo
        public ActionResult Index(Guid id)
        {
            ViewBag.id = id;
            return View(_cargoAppService.GetAll());
        }

        // GET: Cargo/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id.Equals(null)) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var cargoViewModel = _cargoAppService.GetById(Guid.Parse(id.ToString()));
            return cargoViewModel.Equals(null) ? (ActionResult) HttpNotFound() : View(cargoViewModel);
        }

        // GET: Cargo/Create
        public ActionResult Create(Guid Id)
        {
            ViewBag.id = Id;
            return View();
        }

        // POST: Cargo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CargoViewModel cargoViewModel)
        {
            if (!ModelState.IsValid) return View(cargoViewModel);
            cargoViewModel.CargoId = Guid.NewGuid();
            _cargoAppService.Add(cargoViewModel);
            return RedirectToAction("Index");
        }

        // GET: Cargo/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id.Equals(null)) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var cargoViewModel = _cargoAppService.GetById(Guid.Parse(id.ToString()));
            return cargoViewModel.Equals(null) ? (ActionResult) HttpNotFound() : View(cargoViewModel);
        }

        // POST: Cargo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( CargoViewModel cargoViewModel)
        {
            if (!ModelState.IsValid) return View(cargoViewModel);
            _cargoAppService.Update(cargoViewModel);
            return RedirectToAction("Index");
        }

        // GET: Cargo/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id.Equals(null)) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var cargoViewModel = _cargoAppService.GetById(Guid.Parse(id.ToString()));
            return cargoViewModel.Equals(null) ? (ActionResult) HttpNotFound() : View(cargoViewModel);
        }

        // POST: Cargo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
          _cargoAppService.Remove(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _cargoAppService.Dispose();
            
            base.Dispose(disposing);
        }
    }
}
