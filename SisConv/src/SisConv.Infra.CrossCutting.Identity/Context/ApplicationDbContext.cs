using System;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using SisConv.Infra.CrossCutting.Identity.Model;

namespace SisConv.Infra.CrossCutting.Identity.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IDisposable
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            //Database.SetInitializer<ApplicationDbContext>(null);
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();}
       
    }
}