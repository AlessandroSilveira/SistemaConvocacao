using SisConv.Domain.Entities;
using SisConv.Domain.Helpers;
using SisConv.Domain.Interfaces.Services;
using System.Net;
using System.Net.Mail;
using System;
using System.Collections.Generic;
namespace SisConv.Domain.Services
{
	public class EmailServices : IEmailServices
	{
		private readonly IConfiguration _configuration;
		private readonly ISysConfig _sysConfig;
		private readonly IConvocacaoService _convocacaoService;
		private readonly IProcessoService _processoService;

		public EmailServices(IConfiguration configuration,ISysConfig sysConfig,IConvocacaoService convocacaoService, IProcessoService processoService)
		{
			_configuration = configuration;
			_sysConfig = sysConfig;
			_convocacaoService = convocacaoService;
			_processoService = processoService;
	}
		public void EnviarEmail(Convocado convocacao)
		{
			var mail = new MailMessage();

			mail.From = new MailAddress(_configuration.ObterEmailFrom());
			mail.To.Add("alesilver.si@gmail.com"); // para
			mail.Subject = ObterAssuntoEmail(convocacao); // assunto
			mail.Body = ObterBodyParaEnvioEmail(convocacao);
			mail.IsBodyHtml = true;


			// em caso de anexos
			//mail.Attachments.Add(new Attachment(@"C:\teste.txt"));

			using (var smtp = new SmtpClient("smtp.gmail.com"))
			{
				smtp.EnableSsl = true; // GMail requer SSL
				smtp.Port = Convert.ToInt32(_configuration.ObterPortaServidorEmail());     // porta para SSL
				smtp.DeliveryMethod = SmtpDeliveryMethod.Network; // modo de envio
				smtp.UseDefaultCredentials = false; // vamos utilizar credencias especificas

				// seu usuário e senha para autenticação
				smtp.Credentials = new NetworkCredential(_configuration.ObterEmailFrom(), _configuration.ObterPasswordEmail());

				// envia o e-mail
				smtp.Send(mail);
			}
		}

		public string ObterAssuntoEmail(Convocado convocacao)
		{
			return String.Format("Prezado candidato {0} você está convocado para o {1}", convocacao.Nome, convocacao.ProcessoId); 
		}


		public string ObterBodyParaEnvioEmail(Convocado convocacao)
		{
			var dadosConvocacao = _convocacaoService.GetOne(a => a.ProcessoId.Equals(convocacao.ProcessoId) && a.ConvocadoId.Equals(convocacao.ConvocadoId)) ;
			var dadosProcesso = _processoService.GetById(convocacao.ProcessoId);	

			var contentEmail = _sysConfig.GetHelpFile("EmailDeConvocacao"); 
			var body = GetTagContent(contentEmail, "body");
			if (body == string.Empty)			
				return string.Empty;			

			body = body.Replace("{DATA}", dadosConvocacao.DataEntregaDocumentos.ToString());
			body = body.Replace("{HORA}", dadosConvocacao.HorarioEntregaDocumento.ToString());
			body = body.Replace("{ENDERECO}", dadosConvocacao.EnderecoEntregaDocumento.ToString());
			body = body.Replace("{NOMECONVOCACAO}", dadosProcesso.Nome);
			body = body.Replace("{USUARIO}", convocacao.Nome);

			return body;
		}

		public string GetTagContent(string fullcontent, string tag)
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