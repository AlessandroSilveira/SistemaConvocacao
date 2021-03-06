﻿using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Web.Configuration;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SisConv.Application.Interfaces.Repository;
using SisConv.Application.ViewModels;
using SisConv.Domain.Enums;
using SisConv.Domain.Helpers;
using SisConv.Domain.Interfaces.Services;
using SisConv.Domain.Services;
using SisConv.Domain.Services.PasswordGenerator;
using SisConv.Infra.CrossCutting.Identity.Configuration;
using SisConv.Infra.CrossCutting.Identity.Context;
using SisConv.Infra.CrossCutting.Identity.Model;
using SisConv.Infra.CrossCutting.Identity.Roles;

namespace SisConv.Mvc.Controllers
{
    [Authorize(Roles = "Cliente, Convocado")]
    public class ConvocacaoController : Controller
    {
        private readonly IConvocacaoAppService _convocacaoAppService;
        private readonly IConvocacaoService _convocacaoService;
        private readonly IConvocadoAppService _convocadoAppService;
        private readonly IDocumentacaoAppService _documentacaoAppService;
        private readonly IEnumDescription _enumDescription;
        private readonly IPasswordGenerator _passwordGenerator;
        private readonly IProcessoAppService _processoAppService;
        private readonly ISysConfig _sysConfig;
        private readonly ApplicationUserManager _userManager;

        public ConvocacaoController(IConvocacaoAppService convocacaoAppService,
            IConvocadoAppService convocadoAppService,
            ApplicationUserManager userManager,
            IDocumentacaoAppService documentacaoAppService,
            IProcessoAppService processoAppService,
            IEnumDescription enumDescription,
            ISysConfig sysConfig,
            IConvocacaoService convocacaoService,
            IPasswordGenerator passwordGenerator
        )
        {
            _convocacaoAppService = convocacaoAppService;
            _convocadoAppService = convocadoAppService;
            _userManager = userManager;
            _documentacaoAppService = documentacaoAppService;
            _processoAppService = processoAppService;
            _enumDescription = enumDescription;
            _sysConfig = sysConfig;
            _convocacaoService = convocacaoService;
            _passwordGenerator = passwordGenerator;
        }

        public ActionResult Index()
        {
            return View(_convocacaoAppService.GetAll());
        }

        public ActionResult Details(Guid? id)
        {
            if (id.Equals(null)) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var convocacaoViewModel = _convocacaoAppService.GetById(Guid.Parse(id.ToString()));
            return convocacaoViewModel.Equals(null) ? (ActionResult) HttpNotFound() : View(convocacaoViewModel);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ConvocacaoViewModel convocacaoViewModel, string Cargo)
        {
            if (!ModelState.IsValid) return View(convocacaoViewModel);

            var selecionado = convocacaoViewModel.CandidatosSelecionados.Split(',');
            var confirmacao = false;

            convocacaoViewModel.StatusConvocacao = StatusConvocacao.EmConvocacao.ToString();

            foreach (var t in selecionado)
            {
                var dadosConvocado = _convocadoAppService.GetById(Guid.Parse(t));
                RegistarCandidatoParaFazerLogin(dadosConvocado);
                convocacaoViewModel.ConvocadoId = Guid.Parse(t);
                var gravaConvocacao = _convocacaoAppService.Add(convocacaoViewModel);

                if (gravaConvocacao == null)
                    break;

                confirmacao = true;

                EnviarEmailAsync(dadosConvocado);
            }

            return RedirectToAction("ListaConvocados", "Processos",
                new {ProcessoId = convocacaoViewModel.ProcessoId.ToString(), cargo = Cargo, confirmacao});
        }

        private void EnviarEmailAsync(ConvocadoViewModel dadosConvocado)
        {
            var user = _userManager.FindByName(dadosConvocado.Email);
            _userManager.SendEmail(user.Id, ObterAssuntoEmail(dadosConvocado), ObterBodyParaEnvioEmail(dadosConvocado));
        }

        private string ObterAssuntoEmail(ConvocadoViewModel convocacao)
        {
            var dadosProcesso = _processoAppService.GetById(convocacao.ProcessoId);
            return string.Format("Prezado candidato {0} você está convocado para o {1}", convocacao.Nome,
                dadosProcesso.Nome);
        }

        public string ObterBodyParaEnvioEmail(ConvocadoViewModel convocacao)
        {
            var context = new ApplicationDbContext();
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            var dadosCandidato = userManager.FindByEmail(convocacao.Email);

            var dadosConvocacao = _convocacaoService.GetOne(a =>
                a.ProcessoId.Equals(convocacao.ProcessoId) && a.ConvocadoId.Equals(convocacao.ConvocadoId));
            var dadosProcesso = _processoAppService.GetById(convocacao.ProcessoId);

            var contentEmail = _sysConfig.GetHelpFile("EmailDeConvocacao");
            var body = GetTagContent(contentEmail, "body");
            if (body == string.Empty)
                return string.Empty;

            var senhaCandidato = _passwordGenerator.GetPassword();

            userManager.RemovePassword(dadosCandidato.Id);
            userManager.AddPassword(dadosCandidato.Id, senhaCandidato);

            body = body.Replace("{DATA}", dadosConvocacao.DataEntregaDocumentos.ToString());
            body = body.Replace("{HORA}", dadosConvocacao.HorarioEntregaDocumento);
            body = body.Replace("{ENDERECO}", dadosConvocacao.EnderecoEntregaDocumento);
            body = body.Replace("{NOMECONVOCACAO}", dadosProcesso.Nome);
            body = body.Replace("{USUARIO}", convocacao.Nome);
            body = body.Replace("{SENHA}", senhaCandidato);

            return body;
        }

        private static string GetTagContent(string fullcontent, string tag)
        {
            var tagStart = "<" + tag.ToUpper() + ">";
            var tagEnd = "</" + tag.ToUpper() + ">";
            var posStart = fullcontent.ToUpper().IndexOf(tagStart);
            var posEnd = fullcontent.ToUpper().IndexOf(tagEnd);

            if (posStart >= 0) posStart += tagStart.Length;

            return posStart >= 0 && posEnd > posStart ? fullcontent.Substring(posStart, posEnd - posStart) : "";
        }

        private string GerarSenha()
        {
            return _convocacaoAppService.GerarSenhaUsuario();
        }

        public ActionResult Edit(Guid? id)
        {
            if (id.Equals(null)) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var convocacaoViewModel = _convocacaoAppService.GetById(Guid.Parse(id.ToString()));
            return convocacaoViewModel.Equals(null) ? (ActionResult) HttpNotFound() : View(convocacaoViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ConvocacaoViewModel convocacaoViewModel)
        {
            if (!ModelState.IsValid) return View(convocacaoViewModel);
            _convocacaoAppService.Update(convocacaoViewModel);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(Guid? id)
        {
            if (id.Equals(null)) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var convocacaoViewModel = _convocacaoAppService.GetById(Guid.Parse(id.ToString()));
            return convocacaoViewModel.Equals(null) ? (ActionResult) HttpNotFound() : View(convocacaoViewModel);
        }

        [HttpPost]
        [ActionName("Delete")]
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

        private void RegistarCandidatoParaFazerLogin(ConvocadoViewModel convocadoViewModel)
        {
            if (ObterDadosConvocado(convocadoViewModel, out var dadosConvocado)) return;

            var user = new ApplicationUser
            {
                Id = dadosConvocado.ConvocadoId.ToString(),
                UserName = convocadoViewModel.Email,
                Email = convocadoViewModel.Email
            };

            var dados = _userManager.FindByEmail(user.Email);
            if (dados != null) return;
            _userManager.Create(user, GerarSenha());
            var user2 = _userManager.FindByName(dadosConvocado.Email);
            _userManager.AddToRole(user2.Id, RolesNames.ROLE_CONVOCADO);
        }

        private bool ObterDadosConvocado(ConvocadoViewModel convocadoViewModel, out ConvocadoViewModel dadosConvocado)
        {
            dadosConvocado = _convocadoAppService.Search(a => a.ConvocadoId.Equals(convocadoViewModel.ConvocadoId))
                .FirstOrDefault();
            if (dadosConvocado == null) return true;
            return false;
        }

        [HttpPost]
        public ActionResult ConfirmaConvocacao(Guid ProcessoId, Guid ConvocadoId, Guid ConvocacaoId, string decisao)
        {
            var dadosConvocacao =
                _convocacaoAppService.GetById(ConvocacaoId);

            dadosConvocacao.Desistente = decisao;

            if (decisao.Equals("S"))
                dadosConvocacao.StatusConvocacao = StatusConvocacao.Desistente.ToString();
            else
                dadosConvocacao.StatusConvocacao = StatusConvocacao.EmConvocacao.ToString();

            _convocacaoAppService.Update(dadosConvocacao);
            return RedirectToAction(decisao.Equals("S") ? "DesistenciaCandidato" : "DocumentacaoConvocado",
                "Convocacao", new {ProcessoId, ConvocadoId, ConvocacaoId});
        }

        public ActionResult DocumentacaoConvocado(Guid ProcessoId, Guid ConvocadoId, Guid ConvocacaoId)
        {
            ViewBag.dadosProcesso = _processoAppService.GetById(ProcessoId);
            var dadosConvocado = _convocadoAppService.GetById(Guid.Parse(User.Identity.GetUserId()));
            ViewBag.dadosConvocado = dadosConvocado;
            ViewBag.listaDocumentacao = _documentacaoAppService.Search(a => a.ProcessoId.Equals(ProcessoId));
            return View();
        }

        public void Download(string arquivo)
        {
            var pathArquivo = WebConfigurationManager.AppSettings[@"SisConvDocs"];
            var caminhoArquivo = Path.Combine(pathArquivo, arquivo);
            var fInfo = new FileInfo(caminhoArquivo);
            HttpContext.Response.Clear();
            HttpContext.Response.ContentType = "application/octet-stream";
            HttpContext.Response.AddHeader("Content-Disposition", "attachment; filename=\"" + fInfo.Name + "\"");
            HttpContext.Response.AddHeader("Content-Length", fInfo.Length.ToString());
            HttpContext.Response.Flush();
            HttpContext.Response.WriteFile(fInfo.FullName);
            fInfo = null;
        }

        public ActionResult DesistenciaCandidato(Guid ProcessoId, Guid ConvocadoId, Guid ConvocacaoId)
        {
            ViewBag.dadosConvocacao = _convocacaoAppService.GetById(ConvocacaoId);
            var dadosConvocado = _convocadoAppService.GetById(ConvocadoId);
            ViewBag.dadosConvocado = dadosConvocado;
            ViewBag.dadosProcesso = _processoAppService.GetById(ProcessoId);
            return View();
        }
    }
}