using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

/*        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.HasDefaultSchema("Identity");
            builder.Entity<IdentityUser>()
                .Ignore(c => c.AccessFailedCount)
                .Ignore(c => c.PhoneNumber)
                .Ignore(c=>c.PhoneNumberConfirmed)
                .Ignore(c=>c.TwoFactorEnabled)
                .Ignore(c=>c.LockoutEnabled)
                .Ignore(c=>c.LockoutEnd);
        }*/
    }
}
