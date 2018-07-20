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
			mail.Subject = "";
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