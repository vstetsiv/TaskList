using Abp.AspNetCore;
using Abp.AspNetCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Boilerplate.TestProject.Configuration;
using Boilerplate.TestProject.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace Boilerplate.TestProject.Web.Startup
{
    [DependsOn(
        typeof(TestProjectApplicationModule), 
        typeof(TestProjectEntityFrameworkCoreModule), 
        typeof(AbpAspNetCoreModule))]
    public class TestProjectWebModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public TestProjectWebModule(IHostingEnvironment env)
        {
            _appConfiguration = AppConfigurations.Get(env.ContentRootPath, env.EnvironmentName);
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(TestProjectConsts.ConnectionStringName);

            Configuration.Navigation.Providers.Add<TestProjectNavigationProvider>();

            Configuration.Modules.AbpAspNetCore()
                .CreateControllersForAppServices(
                    typeof(TestProjectApplicationModule).GetAssembly()
                );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(TestProjectWebModule).GetAssembly());
        }
    }
}