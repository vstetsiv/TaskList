using System;
using System.Threading.Tasks;
using Abp.TestBase;
using Boilerplate.TestProject.EntityFrameworkCore;
using Boilerplate.TestProject.Tests.TestDatas;

namespace Boilerplate.TestProject.Tests
{
    public class TestProjectTestBase : AbpIntegratedTestBase<TestProjectTestModule>
    {
        public TestProjectTestBase()
        {
            UsingDbContext(context => new TestDataBuilder(context).Build());
        }

        protected virtual void UsingDbContext(Action<TestProjectDbContext> action)
        {
            using (var context = LocalIocManager.Resolve<TestProjectDbContext>())
            {
                action(context);
                context.SaveChanges();
            }
        }

        protected virtual T UsingDbContext<T>(Func<TestProjectDbContext, T> func)
        {
            T result;

            using (var context = LocalIocManager.Resolve<TestProjectDbContext>())
            {
                result = func(context);
                context.SaveChanges();
            }

            return result;
        }

        protected virtual async Task UsingDbContextAsync(Func<TestProjectDbContext, Task> action)
        {
            using (var context = LocalIocManager.Resolve<TestProjectDbContext>())
            {
                await action(context);
                await context.SaveChangesAsync(true);
            }
        }

        protected virtual async Task<T> UsingDbContextAsync<T>(Func<TestProjectDbContext, Task<T>> func)
        {
            T result;

            using (var context = LocalIocManager.Resolve<TestProjectDbContext>())
            {
                result = await func(context);
                context.SaveChanges();
            }

            return result;
        }
    }
}
