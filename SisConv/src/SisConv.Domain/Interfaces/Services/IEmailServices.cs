using SisConv.Domain.Entities;
using SisConv.Domain.Services;

namespace SisConv.Domain.Interfaces.Services
{
	public interface IEmailServices
	{
		void EnviarEmail(Convocado convocacao);
	}
}