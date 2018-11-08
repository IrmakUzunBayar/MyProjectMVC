using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MyProject.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Data.Context
{
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class MyContext : IdentityDbContext<ApplicationUser>
    {
        public MyContext()
           : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static MyContext Create()
        {
            return new MyContext();
        }

        public DbSet<UserDetails> UserDetails { get; set; }
        public DbSet<Logs> Logs { get; set; }
    }
}
