using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace RandomNumbersAngular.EntityFrameworkCore
{
    public static class RandomNumbersAngularDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<RandomNumbersAngularDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<RandomNumbersAngularDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
