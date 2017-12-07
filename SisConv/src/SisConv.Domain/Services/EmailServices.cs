using SisConv.Domain.Entities;
using SisConv.Domain.Helpers;
using SisConv.Domain.Interfaces.Services;

namespace SisConv.Domain.Services
{
	public class EmailServices : IEmailServices
	{
		public EnviaEmailBuilder Builder { get; }
		private readonly IConfiguration _configuration;
		private readonly ISysConfig _sysConfig;

		public EmailServices(EnviaEmailBuilder builder, IConfiguration configuration, ISysConfig sysConfig)
		{
			Builder = builder;
			_configuration = configuration;
			_sysConfig = sysConfig;
		}

		public EnviaEmailBuilder EnviarEmail(Convocado usuario)
		{
			Builder.BuildBody("");
			Builder.BuildBcc("");
			Builder.BuildBody(_sysConfig.GetHelpFile(@"public\EmailDeConvocacao")); //TODO: PUXAR O CORPO DO EMAIL DINAMICAMENTE //_sysUtility.GetHelpFile(@"email\EmailMestre");
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