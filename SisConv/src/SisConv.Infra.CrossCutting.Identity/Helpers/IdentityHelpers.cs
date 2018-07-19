using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SisConv.Infra.CrossCutting.Identity.Configuration;
using SisConv.Infra.CrossCutting.Identity.Context;
using SisConv.Infra.CrossCutting.Identity.Model;
using SisConv.Infra.CrossCutting.Identity.Roles;

namespace SisConv.Infra.CrossCutting.Identity.Helpers
{
	public class IdentityHelper
    {
        private static ApplicationSignInManager _signInManager;

        public IdentityHelper(ApplicationSignInManager signInManager)
        {
            _signInManager = signInManager;
        }

        public static void SeedIdentities(ApplicationDbContext context)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            if (!roleManager.RoleExists(RolesNames.ROLE_ADMIN))
            {
                roleManager.Create(new IdentityRole(RolesNames.ROLE_ADMIN));
            }
            if (!roleManager.RoleExists(RolesNames.ROLE_CLIENTE))
            {
                roleManager.Create(new IdentityRole(RolesNames.ROLE_CLIENTE));
            }
            if (!roleManager.RoleExists(RolesNames.ROLE_USUARIO))
            {
                roleManager.Create(new IdentityRole(RolesNames.ROLE_USUARIO));
            }
            if (!roleManager.RoleExists(RolesNames.ROLE_CONVOCADO))
            {
                roleManager.Create(new IdentityRole(RolesNames.ROLE_CONVOCADO));
            }

            const string email = "admin@admin.com.br";
            const string password = "admin";

            var user = new ApplicationUser { UserName = email, Email = email };
            var result = userManager.Create(user, password);

            if (result.Succeeded)
            {
                var user2 = userManager.FindByName(email);
                userManager.AddToRole(user2.Id, RolesNames.ROLE_ADMIN);              
            }
        }
    }
}
