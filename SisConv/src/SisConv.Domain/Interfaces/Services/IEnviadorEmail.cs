using SisConv.Domain.Services;

namespace SisConv.Domain.Interfaces.Services
{
	public interface IEnviadorEmail
	{
		void EnviarTokenPorEmail(EnviaEmailBuilder dadosEmail);
	}
}