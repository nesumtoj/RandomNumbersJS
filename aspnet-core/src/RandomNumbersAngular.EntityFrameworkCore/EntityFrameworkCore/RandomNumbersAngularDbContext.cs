using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using RandomNumbersAngular.Authorization.Roles;
using RandomNumbersAngular.Authorization.Users;
using RandomNumbersAngular.MultiTenancy;
using RandomNumbersAngular.Entities;

namespace RandomNumbersAngular.EntityFrameworkCore
{
    public class RandomNumbersAngularDbContext : AbpZeroDbContext<Tenant, Role, User, RandomNumbersAngularDbContext>
    {
        /* Define a DbSet for each entity of the application */

        public DbSet<Match> matches { get; set; }
        public DbSet<LnkMatchUser> lnkMatchUsers { get; set; }
        
        public RandomNumbersAngularDbContext(DbContextOptions<RandomNumbersAngularDbContext> options)
            : base(options)
        {
        }
    }
}
