using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SimpleInjector;
using SisConv.Application.Interfaces.Repository;
using SisConv.Application.Services;
using SisConv.Domain.Interfaces.Base;
using SisConv.Domain.Interfaces.Repositories;
using SisConv.Domain.Interfaces.Services;
using SisConv.Domain.Services;
using SisConv.Domain.Services.Base;
using SisConv.Infra.CrossCutting.Identity.Configuration;
using SisConv.Infra.CrossCutting.Identity.Context;
using SisConv.Infra.CrossCutting.Identity.Model;
using SisConv.Infra.Data.Context;
using SisConv.Infra.Data.Repository;
using SisConv.Infra.Data.Repository.Base;
using SisConv.Infra.Data.UoW;

namespace SisConv.Infra.CrossCutting.IoC
{
    public class BootStrapper
    {
        public static void RegisterServices(Container container)
        {
            //App
            container.Register<IClienteAppService, ClienteAppService>(Lifestyle.Scoped);
            container.Register<IPessoaAppService, PessoaAppService>(Lifestyle.Scoped);
            container.Register<ITelefoneAppService, TelefoneAppService>(Lifestyle.Scoped);
            container.Register<IUsuarioAppService, UsuarioAppService>(Lifestyle.Scoped);
            container.Register<IPrimeiroAcessoAppService, PrimeiroAcessoAppService>(Lifestyle.Scoped);
            container.Register<IAdminAppService, AdminAppService>(Lifestyle.Scoped);

            //Domain
            container.Register(typeof(IServiceBase<>), typeof(ServiceBase<>));
			container.Register<IClienteService, ClienteService>(Lifestyle.Scoped);
            container.Register<IPessoaService, PessoaService>(Lifestyle.Scoped);
            container.Register<IUsuarioService, UsuarioService>(Lifestyle.Scoped);
            container.Register<ITelefoneService, TelefoneService>(Lifestyle.Scoped);
            container.Register<IPrimeiroAcessoService, PrimeiroAcessoService>(Lifestyle.Scoped);
            container.Register<IAdminService, AdminService>(Lifestyle.Scoped);

            //Infra Dados
            container.Register(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            container.Register<IClienteRepository, ClienteRepository>(Lifestyle.Scoped);
            container.Register<IPessoaRepository, PessoaRepository>(Lifestyle.Scoped);
            container.Register<ITelefoneRepository, TelefoneRepository>(Lifestyle.Scoped);
            container.Register<IUsuarioRepository, UsuarioRepository>(Lifestyle.Scoped);
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
            container.Register<IPrimeiroAcessoRepository, PrimeiroAcessoRepository>(Lifestyle.Scoped);
            container.Register<IAdminRepository, AdminRepository>(Lifestyle.Scoped);


            //Context
            container.Register<SisConvContext>(Lifestyle.Scoped);
            container.Register<ApplicationDbContext>(Lifestyle.Scoped);

            //Identity
            container.Register<IUserStore<ApplicationUser>>(() => new UserStore<ApplicationUser>(new ApplicationDbContext()), Lifestyle.Scoped);
            container.Register<IRoleStore<IdentityRole, string>>(() => new RoleStore<IdentityRole>(), Lifestyle.Scoped);
            container.Register<ApplicationRoleManager>(Lifestyle.Scoped);
            container.Register<ApplicationUserManager>(Lifestyle.Scoped);
            container.Register<ApplicationSignInManager>(Lifestyle.Scoped);
        }
    }
}