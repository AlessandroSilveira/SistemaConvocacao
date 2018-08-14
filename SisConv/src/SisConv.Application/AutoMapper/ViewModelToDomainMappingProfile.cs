using AutoMapper;
using SisConv.Application.ViewModels;
using SisConv.Domain.Entities;

namespace SisConv.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<Cliente, ClienteViewModel>();
            CreateMap<Pessoa, PessoaViewModel>();
            CreateMap<Telefone, TelefoneViewModel>();
            CreateMap<Usuario, UsuarioViewModel>();
            CreateMap<Admin, Admin2ViewModel>();
            CreateMap<PrimeiroAcesso, PrimeiroAcessoViewModel>();
            CreateMap<Processo, ProcessoViewModel>();
            CreateMap<Cargo, CargoViewModel>();
            CreateMap<Convocado, ConvocadoViewModel>();
            CreateMap<Convocado, DadosConvocadosViewModel>();
            CreateMap<Convocacao, ConvocacaoViewModel>();
            CreateMap<Documentacao, DocumentacaoViewModel>();
            CreateMap<DocumentoCandidato, DocumentoCandidatoViewModel>();
            CreateMap<TipoDocumento, TipoDocumentoViewModel>();
        }
    }
}