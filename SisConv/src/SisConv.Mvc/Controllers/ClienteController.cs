using System;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using SisConv.Application.Interfaces.Repository;
using SisConv.Application.ViewModels;
using SisConv.Infra.CrossCutting.Identity.Configuration;
using SisConv.Infra.CrossCutting.Identity.Model;
using SisConv.Infra.CrossCutting.Identity.Roles;

namespace SisConv.Mvc.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class ClienteController : Controller
    {
        private readonly IClienteAppService _clienteAppService;
        private readonly ApplicationUserManager _userManager;

        public ClienteController(IClienteAppService clienteAppService, ApplicationUserManager userManager)
        {
            _clienteAppService = clienteAppService;
            _userManager = userManager;
        }

        public ActionResult Index()
        {
            return View(_clienteAppService.GetAll());
        }

        public ActionResult Details(Guid? id)
        {
            if (id.Equals(null))
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var clienteViewModel = _clienteAppService.GetById(Guid.Parse(id.ToString()));
            if (clienteViewModel.Equals(null))
                return HttpNotFound();

            return View(clienteViewModel);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClienteViewModel clienteViewModel, HttpPostedFileBase Imagem)
        {
            if (!ModelState.IsValid) return View(clienteViewModel);

            clienteViewModel.ClienteId = Guid.NewGuid();
            var cliente = _clienteAppService.Add(clienteViewModel);

            SalvarImagemCliente(Imagem, cliente);

            return RegistarClienteParaFazerLogin(cliente, out var actionResult)
                ? actionResult
                : RedirectToAction("Index");
        }

        private bool RegistarClienteParaFazerLogin(ClienteViewModel clienteViewModel, out ActionResult actionResult)
        {
            var cliente2 = _clienteAppService.Search(a => a.Email.Equals(clienteViewModel.Email)).FirstOrDefault();
            var user = new ApplicationUser
            {
                Id = cliente2.ClienteId.ToString(),
                UserName = clienteViewModel.Email,
                Email = clienteViewModel.Email
            };
            var result = _userManager.Create(user, clienteViewModel.Password);

            if (!result.Succeeded)
            {
                actionResult = RedirectToAction("Index");
                return true;
            }

            var user2 = _userManager.FindByName(clienteViewModel.Email);
            _userManager.AddToRole(user2.Id, RolesNames.ROLE_CLIENTE);
            actionResult = null;
            return false;
        }

        private void SalvarImagemCliente(HttpPostedFileBase file, ClienteViewModel cliente)
        {
            if (file == null) return;
            var strName = file.FileName.Split('.');
            var strExt = strName[strName.Count() - 1];
            var pathSave = $"{Server.MapPath("~/Images/")}{cliente.ClienteId}.{strExt}";
            var pathBase = $"/Images/{cliente.ClienteId}.{strExt}";
            file.SaveAs(pathSave);
        }

        public ActionResult Edit(Guid? id)
        {
            if (id.Equals(null))
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var clienteViewModel = _clienteAppService.GetById(Guid.Parse(id.ToString()));
            if (clienteViewModel.Equals(null))
                return HttpNotFound();

            return View(clienteViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClienteViewModel clienteViewModel)
        {
            if (!ModelState.IsValid) return View(clienteViewModel);
            _clienteAppService.Update(clienteViewModel);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(Guid? id)
        {
            if (id.Equals(null))
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var clienteViewModel = _clienteAppService.GetById(Guid.Parse(id.ToString()));
            if (clienteViewModel.Equals(null))
                return HttpNotFound();

            return View(clienteViewModel);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _clienteAppService.Remove(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _clienteAppService.Dispose();

            base.Dispose(disposing);
        }
    }
}