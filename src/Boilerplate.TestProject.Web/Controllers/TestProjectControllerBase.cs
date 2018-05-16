using Abp.AspNetCore.Mvc.Controllers;

namespace Boilerplate.TestProject.Web.Controllers
{
    public abstract class TestProjectControllerBase: AbpController
    {
        protected TestProjectControllerBase()
        {
            LocalizationSourceName = TestProjectConsts.LocalizationSourceName;
        }
    }
}