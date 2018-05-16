using Abp.EntityFrameworkCore;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Boilerplate.TestProject.EntityFrameworkCore
{
    [DependsOn(
        typeof(TestProjectCoreModule), 
        typeof(AbpEntityFrameworkCoreModule))]
    public class TestProjectEntityFrameworkCoreModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(TestProjectEntityFrameworkCoreModule).GetAssembly());
        }
    }
}