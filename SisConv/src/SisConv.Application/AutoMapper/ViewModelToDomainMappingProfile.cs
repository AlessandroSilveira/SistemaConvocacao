using AutoMapper;
using SisConv.Application.ViewModels;
using SisConv.Domain.Entities;

namespace SisConv.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Cliente, ClienteViewModel>();
                cfg.CreateMap<Pessoa, PessoaViewModel>();
                cfg.CreateMap<Usuario, UsuarioViewModel>();
                cfg.CreateMap<Telefone, TelefoneViewModel>();
            });

            Mapper.AssertConfigurationIsValid();
        }
    }
}