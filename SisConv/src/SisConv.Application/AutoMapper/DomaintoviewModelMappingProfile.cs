using AutoMapper;
using SisConv.Application.ViewModels;
using SisConv.Domain.Entities;

namespace SisConv.Application.AutoMapper
{
    public class DomaintoviewModelMappingProfile : Profile
    {
        public override string ProfileName => "ViewModelToDomainMappings";

      
        public DomaintoviewModelMappingProfile()
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<ClienteViewModel,Cliente>()
                    .ReverseMap();
                cfg.CreateMap<PessoaViewModel,Pessoa >()
                    .ReverseMap();
                cfg.CreateMap<TelefoneViewModel,Telefone >()
                    .ReverseMap();
                cfg.CreateMap<UsuarioViewModel,Usuario >()
                    .ReverseMap();
                cfg.CreateMap<Admin2ViewModel,Admin >()
                    .ReverseMap();
                cfg.CreateMap<PrimeiroAcessoViewModel, PrimeiroAcesso>()
                    .ReverseMap();
                cfg.CreateMap<ConvocacaoViewModel, Convocacao>()
                    .ReverseMap();
                cfg.CreateMap<CargoViewModel, Cargo>()
                    .ReverseMap();
            });
        }
    }
}