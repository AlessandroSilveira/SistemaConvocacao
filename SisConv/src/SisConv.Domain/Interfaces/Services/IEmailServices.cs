using SisConv.Domain.Core.Enums;
using SisConv.Domain.Entities;
using SisConv.Infra.CrossCutting.Identity.Model;

namespace SisConv.Domain.Interfaces.Services
{
	public interface IEmailServices
	{
		void EnviarEmail(Convocado convocacao);
		void EnviarEmail(string novaSenha, ApplicationUser user);
		void EnviarEmail(string novaSenha, ApplicationUser user, AssuntosEmail assuntoEmail);
	}
}