using SisConv.Domain.Interfaces.Services;
using System.Configuration;
using System.Web.Configuration;

namespace SisConv.Domain.Services
{
	public class Configuration : IConfiguration
	{
		public string ObterSmtp()
		{
			return WebConfigurationManager.AppSettings["host"];
		}

		public string ObterEmailFrom()
		{
			return WebConfigurationManager.AppSettings["EmailFrom"];
		}

		public string ObterPortaServidorEmail()
		{
			return WebConfigurationManager.AppSettings["port"];
		}
		
		public string ObterPasswordEmail()
		{
			return WebConfigurationManager.AppSettings["PasswordEmail"];
		}
	}
}