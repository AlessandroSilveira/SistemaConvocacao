using System.Net;
using System.Net.Mail;
using SisConv.Domain.Interfaces.Services;

namespace SisConv.Domain.Services
{
	public class EnviardorDeEmail : IEnviadorEmail
	{
		private readonly IConfiguration _configuration;

		public EnviardorDeEmail(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public void EnviarTokenPorEmail(EnviaEmailBuilder dadosEmail)
		{
			using (
				var message = new MailMessage(
					dadosEmail.From, dadosEmail.To,
					dadosEmail.Subject, dadosEmail.Body)
					)
			{
				using (var client = new SmtpClient(dadosEmail.SmtpServer)
				{
					UseDefaultCredentials = false,
					Credentials = new NetworkCredential(_configuration.ObterEmailFrom(), _configuration.ObterPasswordEmail()),
					// Credentials = new NetworkCredential("alesilver.si@gmail.com","Alesilver224482"),
					EnableSsl = true
				})
				{
					client.Send(message);
				}
			}
		}
	}
}
