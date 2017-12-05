using SisConv.Application.ViewModels;
using SisConv.Domain.Interfaces.Services;

namespace SisConv.Domain.Services
{
	public class EmailServices : IEmailServices
	{
		public EnviaEmailBuilder Builder { get; }
		private readonly IConfiguration _configuration;

		public EmailServices(EnviaEmailBuilder builder, IConfiguration configuration)
		{
			Builder = builder;
			_configuration = configuration;
		}

		public EnviaEmailBuilder EnviarEmail(ConvocadoViewModel usuario, string token)
		{
			Builder.BuildBody("");
			Builder.BuildBcc("");
			Builder.BuildBody(""); //TODO: PUXAR O CORPO DO EMAIL DINAMICAMENTE
			Builder.BuildCc("");
			Builder.BuildSubject("");
			Builder.BuildFrom(_configuration.ObterEmailFrom());
			Builder.BuildPort(_configuration.ObterPortaServidorEmail());
			Builder.BuildSmtpServer(_configuration.ObterSmtp());
			Builder.BuildTo(usuario.Email);
			return Builder;
		}
	}
}