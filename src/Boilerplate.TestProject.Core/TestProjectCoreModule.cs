using Abp.Modules;
using Abp.Reflection.Extensions;
using Boilerplate.TestProject.Localization;

namespace Boilerplate.TestProject
{
    public class TestProjectCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;

            TestProjectLocalizationConfigurer.Configure(Configuration.Localization);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(TestProjectCoreModule).GetAssembly());
        }
    }
}