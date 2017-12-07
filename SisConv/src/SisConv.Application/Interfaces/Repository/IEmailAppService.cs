using SisConv.Application.ViewModels;
using SisConv.Domain.Services;

namespace SisConv.Application.Interfaces.Repository
{
	public interface IEmailAppService
	{
		EnviaEmailBuilder EnviarEmail(ConvocadoViewModel convocacao);
	}
}