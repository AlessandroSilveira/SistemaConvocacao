using SisConv.Domain.Entities;
using SisConv.Domain.Helpers;
using SisConv.Domain.Interfaces.Services;
using System.Net;
using System.Net.Mail;
using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SisConv.Infra.CrossCutting.Identity.Context;
using SisConv.Infra.CrossCutting.Identity.Model;
using SisConv.Domain.Core.Services.PasswordGenerator;

namespace SisConv.Domain.Services
{
	public class EmailServices : IEmailServices
	{
		private readonly IConfiguration _configuration;
		private readonly ISysConfig _sysConfig;
		private readonly IConvocacaoService _convocacaoService;
		private readonly IProcessoService _processoService;		
		private readonly IPasswordGenerator _passwordGenerator;

		public EmailServices(IConfiguration configuration,
			ISysConfig sysConfig,
			IConvocacaoService convocacaoService,
			IProcessoService processoService,			
			IPasswordGenerator passwordGenerator)
		{
			_configuration = configuration;
			_sysConfig = sysConfig;
			_convocacaoService = convocacaoService;
			_processoService = processoService;			
			_passwordGenerator = passwordGenerator;
		}
		public void EnviarEmail(Convocado convocacao)
		{
			var mail = new MailMessage();

			mail.From = new MailAddress(_configuration.ObterEmailFrom());
			mail.To.Add("alesilver.si@gmail.com");
			mail.Subject = ObterAssuntoEmail(convocacao);
			mail.Body = ObterBodyParaEnvioEmail(convocacao);
			mail.IsBodyHtml = true;

			using (var smtp = new SmtpClient("smtp.gmail.com"))
			{
				smtp.EnableSsl = true;
				smtp.Port = Convert.ToInt32(_configuration.ObterPortaServidorEmail());
				smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
				smtp.UseDefaultCredentials = false;
				smtp.Credentials = new NetworkCredential(_configuration.ObterEmailFrom(), _configuration.ObterPasswordEmail());

				smtp.Send(mail);
			}
		}

		private static string ObterAssuntoEmail(Convocado convocacao)
		{
			return String.Format("Prezado candidato {0} você está convocado para o {1}", convocacao.Nome, convocacao.ProcessoId);
		}


		public string ObterBodyParaEnvioEmail(Convocado convocacao)
		{
			var context = new ApplicationDbContext();
			var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

			var dadosCandidato = userManager.FindByEmail(convocacao.Email);

			var dadosConvocacao = _convocacaoService.GetOne(a => a.ProcessoId.Equals(convocacao.ProcessoId) && a.ConvocadoId.Equals(convocacao.ConvocadoId));
			var dadosProcesso = _processoService.GetById(convocacao.ProcessoId);

			var contentEmail = _sysConfig.GetHelpFile("EmailDeConvocacao");
			var body = GetTagContent(contentEmail, "body");
			if (body == string.Empty)
				return string.Empty;


			var senhaCandidato = _passwordGenerator.GetPassword();

			userManager.RemovePassword(dadosCandidato.Id);
			userManager.AddPassword(dadosCandidato.Id, senhaCandidato);

			body = body.Replace("{DATA}", dadosConvocacao.DataEntregaDocumentos.ToString());
			body = body.Replace("{HORA}", dadosConvocacao.HorarioEntregaDocumento.ToString());
			body = body.Replace("{ENDERECO}", dadosConvocacao.EnderecoEntregaDocumento.ToString());
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
	}
}