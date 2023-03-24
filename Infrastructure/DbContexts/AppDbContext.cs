using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DbContexts
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Account> Accounts{ get; set; }
        public DbSet<Role> Roles{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Role>()
                .HasData(
                    new Role { Id = Guid.NewGuid(), Name = "Admin"},
                    new Role { Id = Guid.NewGuid(), Name = "EndUser"}
                );
        }
    }
}
