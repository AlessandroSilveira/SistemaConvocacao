using AutoMapper;
using SisConv.Application.ViewModels;
using SisConv.Domain.Entities;

namespace SisConv.Application.AutoMapper
{
    public class DomaintoviewModelMappingProfile : Profile
    {
        public DomaintoviewModelMappingProfile()
        {
            CreateMap<ClienteViewModel, Cliente>();
            CreateMap<PessoaViewModel, Pessoa>();
            CreateMap<TelefoneViewModel, Telefone>();
            CreateMap<UsuarioViewModel, Usuario>();
            CreateMap<Admin2ViewModel, Admin>();
            CreateMap<PrimeiroAcessoViewModel, PrimeiroAcesso>();
            CreateMap<ProcessoViewModel, Processo>();
            CreateMap<CargoViewModel, Cargo>();
            CreateMap<ConvocadoViewModel, Convocado>();
            CreateMap<DadosConvocadosViewModel, Convocado>();
            CreateMap<ConvocacaoViewModel, Convocacao>();
            CreateMap<DocumentacaoViewModel, Documentacao>();
            CreateMap<DocumentoCandidatoViewModel, DocumentoCandidato>();
            CreateMap<TipoDocumentoViewModel, TipoDocumento>();
        }
    }
}