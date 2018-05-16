using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Boilerplate.TestProject.Web.Startup;
namespace Boilerplate.TestProject.Web.Tests
{
    [DependsOn(
        typeof(TestProjectWebModule),
        typeof(AbpAspNetCoreTestBaseModule)
        )]
    public class TestProjectWebTestModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(TestProjectWebTestModule).GetAssembly());
        }
    }
}