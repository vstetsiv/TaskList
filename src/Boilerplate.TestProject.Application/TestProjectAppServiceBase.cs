using Abp.Application.Services;

namespace Boilerplate.TestProject
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class TestProjectAppServiceBase : ApplicationService
    {
        protected TestProjectAppServiceBase()
        {
            LocalizationSourceName = TestProjectConsts.LocalizationSourceName;
        }
    }
}