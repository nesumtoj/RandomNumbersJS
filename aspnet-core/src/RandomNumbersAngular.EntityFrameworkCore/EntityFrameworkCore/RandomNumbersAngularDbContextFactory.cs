using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using RandomNumbersAngular.Configuration;
using RandomNumbersAngular.Web;

namespace RandomNumbersAngular.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class RandomNumbersAngularDbContextFactory : IDesignTimeDbContextFactory<RandomNumbersAngularDbContext>
    {
        public RandomNumbersAngularDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<RandomNumbersAngularDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            RandomNumbersAngularDbContextConfigurer.Configure(builder, configuration.GetConnectionString(RandomNumbersAngularConsts.ConnectionStringName));

            return new RandomNumbersAngularDbContext(builder.Options);
        }
    }
}
