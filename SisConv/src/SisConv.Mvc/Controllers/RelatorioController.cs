using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using SisConv.Application.Interfaces.Repository;
using SisConv.Application.ViewModels;
using SisConv.Domain.Enums;
using SisConv.Domain.Services;

namespace SisConv.Mvc.Controllers
{
    [Authorize(Roles = "Cliente")]
    public class RelatorioController : Controller
    {
        private readonly ICargoAppService _cargoAppService;
        private readonly IConvocacaoAppService _convocacaoAppService;
        private readonly IConvocadoAppService _convocadoAppService;
        private readonly IEnumDescription _enumDescription;
        private readonly IPrimeiroAcessoAppService _primeiroAcessoAppService;

        public RelatorioController(
            ICargoAppService cargoAppService,
            IConvocadoAppService convocadoAppService,
            IConvocacaoAppService convocacaoAppService,
            IEnumDescription enumDescription,
            IPrimeiroAcessoAppService primeiroAcessoAppService)
        {
            _cargoAppService = cargoAppService;
            _convocadoAppService = convocadoAppService;
            _convocacaoAppService = convocacaoAppService;
            _enumDescription = enumDescription;
            _primeiroAcessoAppService = primeiroAcessoAppService;
        }

        public ActionResult Index(Guid Id)
        {
            ViewBag.ProcessoId = Id;
            return View();
        }

        public ActionResult ClassificadosPorCargo(Guid id)
        {
            ViewBag.ProcessoId = id;
            ViewBag.ListaCargos = _cargoAppService.Search(a => a.ProcessoId.Equals(id) && a.Ativo.Equals(true))
                .OrderBy(x => x.Nome);
            ViewBag.ListaConvocadosPorCargo = null;
            return View();
        }

        [HttpPost]
        public ActionResult ClassificadosPorCargo(Guid id, Guid cargo)
        {
            ViewBag.ProcessoId = id;

            var dadosConfirmados = _convocacaoAppService.Search(a => a.ProcessoId.Equals(id))
                .Where(b => b.StatusConvocacao != null);
            var convocados = _convocadoAppService.Search(a => a.ProcessoId.Equals(id) && a.CargoId.Equals(cargo));

            ViewBag.ListaConvocadosPorCargo = _convocacaoAppService.MontaListaDeConvocados(dadosConfirmados, convocados)
                .OrderBy(x => x.Posicao);
            ViewBag.ListaCargos = _cargoAppService.Search(a => a.ProcessoId.Equals(id) && a.Ativo.Equals(true))
                .OrderBy(x => x.Nome);

            return View();
        }

        public ActionResult ConvocadosQueDesistiram(Guid id)
        {
            ViewBag.ProcessoId = id;
            ViewBag.ListaCargos = _cargoAppService.Search(a => a.ProcessoId.Equals(id) && a.Ativo.Equals(true))
                .OrderBy(x => x.Nome);
            ViewBag.ListaConvocadosQueDesistiram = null;

            return View();
        }

        [HttpPost]
        public ActionResult ConvocadosQueDesistiram(Guid id, Guid cargo)
        {
            ViewBag.ProcessoId = id;
            var dadosConfirmados = _convocacaoAppService.Search(a => a.ProcessoId.Equals(id)).Where(b =>
                b.StatusConvocacao.Equals(_enumDescription.GetEnumDescription(StatusConvocacao.Desistente)));
            var convocados = _convocadoAppService.Search(a => a.ProcessoId.Equals(id) && a.CargoId.Equals(cargo));

            ViewBag.ListaConvocadosQueDesistiram = _convocacaoAppService
                .MontaListaDeConvocados(dadosConfirmados, convocados).OrderBy(x => x.Posicao);
            ViewBag.ListaCargos = _cargoAppService.Search(a => a.ProcessoId.Equals(id) && a.Ativo.Equals(true))
                .OrderBy(x => x.Nome);

            return View();
        }

        public ActionResult ConvocadosQueIngressaram(Guid id)
        {
            ViewBag.ProcessoId = id;
            ViewBag.ListaCargos = _cargoAppService.Search(a => a.ProcessoId.Equals(id) && a.Ativo.Equals(true))
                .OrderBy(x => x.Nome);
            ViewBag.ListaConvocadosQueIngressaram = null;

            return View();
        }

        [HttpPost]
        public ActionResult ConvocadosQueIngressaram(Guid id, Guid cargo)
        {
            ViewBag.ProcessoId = id;

            var dadosConfirmados = _convocacaoAppService.Search(a => a.ProcessoId.Equals(id))
                .Where(b => b.StatusConvocacao != null);
            var candidadosQueFizeramPrimeiroAcesso = _primeiroAcessoAppService.GetAll();
            var convocados = _convocadoAppService.Search(a => a.ProcessoId.Equals(id) && a.CargoId.Equals(cargo));

            ViewBag.ListConvocadosQueIngressaram =
                _convocacaoAppService.MontaListaDeConvocados(dadosConfirmados, convocados);
            ViewBag.ListaCargos = _cargoAppService.Search(a => a.ProcessoId.Equals(id) && a.Ativo.Equals(true))
                .OrderBy(x => x.Nome);

            return View();
        }

        public ActionResult ConvocadosQueNaoIngressaram(Guid id)
        {
            ViewBag.ProcessoId = id;
            ViewBag.ListaCargos = _cargoAppService.Search(a => a.ProcessoId.Equals(id) && a.Ativo.Equals(true))
                .OrderBy(x => x.Nome);
            ViewBag.ListaConvocadosQueIngressaram = null;

            return View();
        }

        [HttpPost]
        public ActionResult ConvocadosQueNaoIngressaram(Guid id, Guid cargo)
        {
            ViewBag.ProcessoId = id;
            var dadosConfirmados = _convocacaoAppService.Search(a => a.ProcessoId.Equals(id));
            var candidadosQueFizeramPrimeiroAcesso = _primeiroAcessoAppService.GetAll();

            var naoIngressaram = new HashSet<Guid>(candidadosQueFizeramPrimeiroAcesso.Select(x => x.ConvocadoId));
            var candidatosQueNaoIngressaram = dadosConfirmados.Where(x => !naoIngressaram.Contains(x.ConvocadoId));

            var dados = new List<ConvocacaoViewModel>();

            foreach (var item in candidatosQueNaoIngressaram)
                dados.Add(dadosConfirmados.FirstOrDefault(x => x.ConvocadoId.Equals(item.ConvocadoId)));

            var dados2 = new List<ConvocadoViewModel>();

            foreach (var item in dados)
                dados2.Add(_convocadoAppService.Search(a =>
                        a.ProcessoId.Equals(id) && a.CargoId.Equals(cargo) && a.ConvocadoId.Equals(item.ConvocadoId))
                    .FirstOrDefault());

            ViewBag.ListConvocadosQueNaoIngressaram = _convocacaoAppService.MontaListaDeConvocados(dados, dados2);
            ViewBag.ListaCargos = _cargoAppService.Search(a => a.ProcessoId.Equals(id) && a.Ativo.Equals(true))
                .OrderBy(x => x.Nome);

            return View();
        }

        public ActionResult ConvocadosPorInstituicaoEnsinoSuperior(Guid id)
        {
            ViewBag.ProcessoId = id;
            ViewBag.ListaCargos = _cargoAppService.Search(a => a.ProcessoId.Equals(id) && a.Ativo.Equals(true))
                .OrderBy(x => x.Nome);
            ViewBag.ListaConvocadosPorInstituicaoEnsinoSuperior = null;

            return View();
        }

        [HttpPost]
        public ActionResult ConvocadosPorInstituicaoEnsinoSuperior(Guid id, Guid cargo)
        {
            ViewBag.ProcessoId = id;

            var dadosConfirmados = _convocacaoAppService.Search(a => a.ProcessoId.Equals(id))
                .Where(b => b.StatusConvocacao != null);
            var candidadosQueFizeramPrimeiroAcesso = _primeiroAcessoAppService.GetAll();
            var convocados = _convocadoAppService.Search(a => a.ProcessoId.Equals(id) && a.CargoId.Equals(cargo));

            ViewBag.ListaConvocadosPorInstituicaoEnsinoSuperior =
                _convocacaoAppService.MontaListaDeConvocados(dadosConfirmados, convocados);
            ViewBag.ListaCargos = _cargoAppService.Search(a => a.ProcessoId.Equals(id) && a.Ativo.Equals(true))
                .OrderBy(x => x.Nome);

            return View();
        }

        public ActionResult PendentesDadosBancarios(Guid id)
        {
            ViewBag.ProcessoId = id;
            ViewBag.ListaCargos = _cargoAppService.Search(a => a.ProcessoId.Equals(id) && a.Ativo.Equals(true))
                .OrderBy(x => x.Nome);
            ViewBag.ListaConvocadosPendentesDadosBancarios = null;

            return View();
        }

        [HttpPost]
        public ActionResult PendentesDadosBancarios(Guid id, Guid cargo)
        {
            ViewBag.ProcessoId = id;

            var dadosConfirmados = _convocacaoAppService.Search(a => a.ProcessoId.Equals(id))
                .Where(b => b.StatusConvocacao != null);
            var candidadosQueFizeramPrimeiroAcesso = _primeiroAcessoAppService.GetAll();
            var convocados = _convocadoAppService.Search(a => a.ProcessoId.Equals(id) && a.CargoId.Equals(cargo))
                .Where(a => string.IsNullOrEmpty(a.Agencia) || string.IsNullOrEmpty(a.ContaCorrente) ||
                            string.IsNullOrEmpty(a.NomeAgencia));

            ViewBag.ListaConvocadosPendentesDadosBancarios =
                _convocacaoAppService.MontaListaDeConvocados(dadosConfirmados, convocados);
            ViewBag.ListaCargos = _cargoAppService.Search(a => a.ProcessoId.Equals(id) && a.Ativo.Equals(true))
                .OrderBy(x => x.Nome);

            return View();
        }
    }
}