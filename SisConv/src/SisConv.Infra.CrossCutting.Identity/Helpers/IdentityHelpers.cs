using System;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SisConv.Infra.CrossCutting.Identity.Context;
using SisConv.Infra.CrossCutting.Identity.Model;
using SisConv.Infra.CrossCutting.Identity.Roles;

namespace SisConv.Infra.CrossCutting.Identity.Helpers
{
    public class IdentityHelper
    {
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

            var email = "admin@admin.com.br";
            var userName = "Admin";
            var password = "123456";

            var user = userManager.FindByName(userName);
            if (user == null)
            {
                user = new ApplicationUser()
                {
                    Id = Guid.NewGuid().ToString(),
                    PasswordHash = HashPassword(password),
                    SecurityStamp = "",
                    PhoneNumber = "",
                    PhoneNumberConfirmed = true,
                    TwoFactorEnabled = false,
                    LockoutEndDateUtc = DateTime.Now,
                    LockoutEnabled = false,
                    AccessFailedCount = 0,
                    UserName = userName,
                    Email = email,
                    EmailConfirmed = true

                };
                var userResult = userManager.Create(user, password);
                if (userResult.Succeeded)
                {
                    userManager.AddToRole(user.Id, RolesNames.ROLE_ADMIN);
                }
            }

            user = new ApplicationUser()
            {
                Id = Guid.NewGuid().ToString(),
                PasswordHash = HashPassword(password),
                SecurityStamp = "",
                PhoneNumber = "",
                PhoneNumberConfirmed = true,
                TwoFactorEnabled = false,
                LockoutEndDateUtc = DateTime.Now,
                LockoutEnabled = false,
                AccessFailedCount = 0,
                UserName = userName,
                Email = email,
                EmailConfirmed = true
            };
            userManager.Create(user, password);
        }
        public static string HashPassword(string password)
        {
            byte[] salt;
            byte[] buffer2;
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, 0x10, 0x3e8))
            {
                salt = bytes.Salt;
                buffer2 = bytes.GetBytes(0x20);
            }
            byte[] dst = new byte[0x31];
            Buffer.BlockCopy(salt, 0, dst, 1, 0x10);
            Buffer.BlockCopy(buffer2, 0, dst, 0x11, 0x20);
            return Convert.ToBase64String(dst);
        }
       
    }
}
