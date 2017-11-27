using AutoMapper;
using SisConv.Application.ViewModels;
using SisConv.Domain.Entities;

namespace SisConv.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName => "ViewModelToDomainMappings";

        public ViewModelToDomainMappingProfile()
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<Cliente,ClienteViewModel>()
                    .ReverseMap();
                cfg.CreateMap< Pessoa, PessoaViewModel>()
                    .ReverseMap();
                cfg.CreateMap<Telefone, TelefoneViewModel>()
                    .ReverseMap();
                cfg.CreateMap< Usuario, UsuarioViewModel>()
                    .ReverseMap();
                cfg.CreateMap< Admin, Admin2ViewModel>()
                    .ReverseMap();
                cfg.CreateMap<PrimeiroAcesso, PrimeiroAcessoViewModel>()
                    .ReverseMap();
                cfg.CreateMap<Processo, ProcessoViewModel>()
                    .ReverseMap();
                cfg.CreateMap<Cargo, CargoViewModel>()
                    .ReverseMap();
                cfg.CreateMap<Convocado, ConvocadoViewModel>()
                    .ReverseMap();
                cfg.CreateMap<Convocado, DadosConvocadosViewModel>()
                    .ReverseMap();
                cfg.CreateMap<Convocacao, ConvocacaoViewModel>()
                    .ReverseMap();
            });
        }
    }
}