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
using SisConv.Domain.Core.Enums;
using System.Collections.Generic;
using System.Linq;

namespace SisConv.Domain.Services
{
	public class EmailServices : IEmailServices
	{
		private readonly IConfiguration _configuration;
		private readonly ISysConfig _sysConfig;
		private readonly IConvocacaoService _convocacaoService;
		private readonly IProcessoService _processoService;		
		private readonly IPasswordGenerator _passwordGenerator;
		private readonly IConvocadoService _convocadoService;

		public EmailServices(IConfiguration configuration,
			ISysConfig sysConfig,
			IConvocacaoService convocacaoService,
			IProcessoService processoService,			
			IPasswordGenerator passwordGenerator,
			IConvocadoService convocadoService
			)
		{
			_configuration = configuration;
			_sysConfig = sysConfig;
			_convocacaoService = convocacaoService;
			_processoService = processoService;			
			_passwordGenerator = passwordGenerator;
			_convocadoService = convocadoService;
		}
		public void EnviarEmail(Convocado convocacao)
		{
			//EmailSettings(convocacao);
		}

		private void EmailSettings(Convocado convocacao, string senha=null)
		{
			var mail = new MailMessage();

			mail.From = new MailAddress(_configuration.ObterEmailFrom());
			mail.To.Add("alesilver.si@gmail.com");
			mail.Subject = ObterAssuntoEmail(convocacao, AssuntosEmail.Convocacao, senha);
            mail.Body = "";//ObterBodyParaEnvioEmail(convocacao, assuntosEmail);
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

		private static string ObterAssuntoEmail(Convocado convocacao,AssuntosEmail assuntos, string senha)
		{
			switch (assuntos)
			{
				case AssuntosEmail.Convocacao:
					{
						return String.Format("Prezado candidato {0} você está convocado para o {1}", convocacao.Nome, convocacao.ProcessoId);
					}
				case AssuntosEmail.EsqueciSenha:
					{
						var context = new ApplicationDbContext();
						using (var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context)))
						{
							var dadosCandidato = userManager.FindByEmail(convocacao.Email);
							return String.Format("Prezado candidato {0}, a sua nova senha é {1}", convocacao.Nome, senha);
						}
					}

				default:
					{
						throw new Exception("Unexpected Case");
					}
			}

		}


		//public string ObterBodyParaEnvioEmail(Convocado convocacao, AssuntosEmail assuntosEmail)
		//{
		//	var context = new ApplicationDbContext();
		//	var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

		//	var dadosCandidato = userManager.FindByEmail(convocacao.Email);

		//	var dadosConvocacao = _convocacaoService.GetOne(a => a.ProcessoId.Equals(convocacao.ProcessoId) && a.ConvocadoId.Equals(convocacao.ConvocadoId));
		//	var dadosProcesso = _processoService.GetById(convocacao.ProcessoId);

		//	switch (assuntosEmail)
		//	{
		//		case AssuntosEmail.Convocacao:
		//			{
		//				var contentEmail = _sysConfig.GetHelpFile("EmailDeConvocacao");
		//				var body = GetTagContent(contentEmail, "body");
		//				if (body == string.Empty)
		//					return string.Empty;


		//				var senhaCandidato = _passwordGenerator.GetPassword();

		//				userManager.RemovePassword(dadosCandidato.Id);
		//				userManager.AddPassword(dadosCandidato.Id, senhaCandidato);

		//				body = body.Replace("{DATA}", dadosConvocacao.DataEntregaDocumentos.ToString());
		//				body = body.Replace("{HORA}", dadosConvocacao.HorarioEntregaDocumento.ToString());
		//				body = body.Replace("{ENDERECO}", dadosConvocacao.EnderecoEntregaDocumento.ToString());
		//				body = body.Replace("{NOMECONVOCACAO}", dadosProcesso.Nome);
		//				body = body.Replace("{USUARIO}", convocacao.Nome);
		//				body = body.Replace("{SENHA}", senhaCandidato);

		//				return body;
		//			}
		//		case AssuntosEmail.EsqueciSenha:
		//			{
  //                      return body;
  //                      break;
		//			}

		//		default:
		//			throw new Exception("Unexpected Case");
		//	}
		//}

			

		private static string GetTagContent(string fullcontent, string tag)
		{
			var tagStart = "<" + tag.ToUpper() + ">";
			var tagEnd = "</" + tag.ToUpper() + ">";
			var posStart = fullcontent.ToUpper().IndexOf(tagStart);
			var posEnd = fullcontent.ToUpper().IndexOf(tagEnd);

			if (posStart >= 0) posStart += tagStart.Length;

			return posStart >= 0 && posEnd > posStart ? fullcontent.Substring(posStart, posEnd - posStart) : "";
		}

		public void EnviarEmail(string novaSenha, ApplicationUser user)
		{
			var convocado = _convocadoService.Search(a => a.Email.Equals(user.Email)).FirstOrDefault();			

			//EmailSettings(convocado, novaSenha);
		}

        public void EnviarEmail(string novaSenha, ApplicationUser user, AssuntosEmail assuntoEmail)
        {
            throw new NotImplementedException();
        }
    }
}