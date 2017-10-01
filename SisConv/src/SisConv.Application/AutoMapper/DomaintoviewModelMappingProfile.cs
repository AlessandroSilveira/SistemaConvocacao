using AutoMapper;
using SisConv.Application.ViewModels;
using SisConv.Domain.Entities;

namespace SisConv.Application.AutoMapper
{
    public class DomaintoviewModelMappingProfile : Profile
    {
        public DomaintoviewModelMappingProfile()
        {
            //Mapper.Initialize(cfg =>
            //{
            //    cfg.CreateMap<ClienteViewModel, Cliente>();
            //    cfg.CreateMap<PessoaViewModel, Pessoa>();
            //    cfg.CreateMap<TelefoneViewModel, Telefone>();
            //    cfg.CreateMap<UsuarioViewModel, Usuario>();
            //});

            //Mapper.AssertConfigurationIsValid();

            Mapper.Initialize(cfg => {
                cfg.CreateMap<Cliente, ClienteViewModel>()
                    .ReverseMap();
                cfg.CreateMap<Pessoa, PessoaViewModel>()
                    .ReverseMap();
                cfg.CreateMap<Telefone, TelefoneViewModel>()
                    .ReverseMap();
                cfg.CreateMap<Usuario, UsuarioViewModel>()
                    .ReverseMap();

            });
        }
    }
}