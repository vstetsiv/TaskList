using Boilerplate.TestProject.Configuration;
using Boilerplate.TestProject.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Boilerplate.TestProject.EntityFrameworkCore
{
    /* This class is needed to run EF Core PMC commands. Not used anywhere else */
    public class TestProjectDbContextFactory : IDesignTimeDbContextFactory<TestProjectDbContext>
    {
        public TestProjectDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<TestProjectDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            DbContextOptionsConfigurer.Configure(
                builder,
                configuration.GetConnectionString(TestProjectConsts.ConnectionStringName)
            );

            return new TestProjectDbContext(builder.Options);
        }
    }
}