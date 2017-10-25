using System;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using SisConv.Application.Interfaces.Repository;
using SisConv.Application.ViewModels;
using SisConv.Infra.CrossCutting.Identity.Configuration;
using SisConv.Infra.CrossCutting.Identity.Model;
using SisConv.Infra.CrossCutting.Identity.Roles;

namespace SisConv.Mvc.Controllers
{
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
        public async Task<ActionResult> Create(ClienteViewModel clienteViewModel)
        {
            if (!ModelState.IsValid) return View(clienteViewModel);

            clienteViewModel.ClienteId = Guid.NewGuid();
            _clienteAppService.Add(clienteViewModel);

            var user = new ApplicationUser { UserName = clienteViewModel.Email, Email = clienteViewModel.Email };
            var result = await _userManager.CreateAsync(user, clienteViewModel.Password);
            if (result.Succeeded)
            {
                var user2 = _userManager.FindByName(clienteViewModel.Email);
                await _userManager.AddToRoleAsync(user2.Id, RolesNames.ROLE_CLIENTE);
               
            }
            return RedirectToAction("Index");
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
        
        [HttpPost, ActionName("Delete")]
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
