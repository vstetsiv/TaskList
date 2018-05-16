using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Boilerplate.TestProject
{
    [DependsOn(
        typeof(TestProjectCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class TestProjectApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(TestProjectApplicationModule).GetAssembly());
        }
    }
}