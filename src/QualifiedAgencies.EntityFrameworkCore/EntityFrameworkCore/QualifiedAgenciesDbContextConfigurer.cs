using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace QualifiedAgencies.EntityFrameworkCore
{
    public static class QualifiedAgenciesDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<QualifiedAgenciesDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<QualifiedAgenciesDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
