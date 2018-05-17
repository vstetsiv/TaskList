using Boilerplate.TestProject.EntityFrameworkCore;
using Boilerplate.TestProject.Models;

namespace Boilerplate.TestProject.Tests.TestDatas
{
    public class TestDataBuilder
    {
        private readonly TestProjectDbContext _context;

        public TestDataBuilder(TestProjectDbContext context)
        {
            _context = context;
        }

        public void Build()
        {
            var vova = new Person("Vova");
            _context.People.Add(vova);
            _context.SaveChanges();

            _context.Tasks.AddRange(
                new Task("Follow the white rabbit", "Follow the while rabbit in order to know that this is virtual reality"),
                new Task("Clean the room", "")
            );
        }
    }
}