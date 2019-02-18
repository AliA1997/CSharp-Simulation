using System;
using System.Collections.Generic;
using Houser.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace Houser.Data
{
    public class HouserContext : IdentityDbContext<User>
    {
        public HouserContext(DbContextOptions<HouserContext> options):base(options){ }

        public DbSet<User> Users { get; set; }
        public DbSet<House> Houses { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            
            builder.HasDefaultSchema("houser");
        }
    }
}