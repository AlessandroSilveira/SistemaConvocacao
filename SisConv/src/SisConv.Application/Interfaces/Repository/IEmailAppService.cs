using SisConv.Application.ViewModels;
using SisConv.Domain.Services;

namespace SisConv.Application.Interfaces.Repository
{
	public interface IEmailAppService
	{
		void EnviarEmail(ConvocadoViewModel convocacao);
	}
}