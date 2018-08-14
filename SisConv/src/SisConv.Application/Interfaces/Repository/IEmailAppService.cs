using SisConv.Application.ViewModels;

namespace SisConv.Application.Interfaces.Repository
{
    public interface IEmailAppService
    {
        void EnviarEmail(ConvocadoViewModel convocacao);
    }
}