using Abp.EntityFrameworkCore;
using Boilerplate.TestProject.Models;
using Microsoft.EntityFrameworkCore;

namespace Boilerplate.TestProject.EntityFrameworkCore
{
    public class TestProjectDbContext : AbpDbContext
    {
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Person> People { get; set; }

        public TestProjectDbContext(DbContextOptions<TestProjectDbContext> options) 
            : base(options)
        {

        }
    }
}
