using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using QualifiedAgencies.Authorization.Roles;
using QualifiedAgencies.Authorization.Users;
using QualifiedAgencies.MultiTenancy;
using QualifiedAgencies.Entities;
using QualifiedAgencies.Lookups;

namespace QualifiedAgencies.EntityFrameworkCore
{
    public class QualifiedAgenciesDbContext : AbpZeroDbContext<Tenant, Role, User, QualifiedAgenciesDbContext>
    {
        /* Define a DbSet for each entity of the application */

        public QualifiedAgenciesDbContext(DbContextOptions<QualifiedAgenciesDbContext> options)
            : base(options)
        {
        }
        public DbSet<EligibleEntity> EligibleEntities { get; set; }
        public DbSet<ActivityType> ActivityTypes { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Area> Areas { get; set; }
    }
}
