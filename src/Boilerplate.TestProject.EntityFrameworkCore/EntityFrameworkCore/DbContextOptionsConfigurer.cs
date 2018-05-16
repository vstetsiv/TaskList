using Microsoft.EntityFrameworkCore;

namespace Boilerplate.TestProject.EntityFrameworkCore
{
    public static class DbContextOptionsConfigurer
    {
        public static void Configure(
            DbContextOptionsBuilder<TestProjectDbContext> dbContextOptions, 
            string connectionString
            )
        {
            /* This is the single point to configure DbContextOptions for TestProjectDbContext */
            dbContextOptions.UseSqlServer(connectionString);
        }
    }
}
