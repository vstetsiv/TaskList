using Abp.AspNetCore.Mvc.Views;

namespace Boilerplate.TestProject.Web.Views
{
    public abstract class TestProjectRazorPage<TModel> : AbpRazorPage<TModel>
    {
        protected TestProjectRazorPage()
        {
            LocalizationSourceName = TestProjectConsts.LocalizationSourceName;
        }
    }
}
