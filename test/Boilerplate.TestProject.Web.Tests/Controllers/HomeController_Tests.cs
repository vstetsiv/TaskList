using System.Threading.Tasks;
using Boilerplate.TestProject.Web.Controllers;
using Shouldly;
using Xunit;

namespace Boilerplate.TestProject.Web.Tests.Controllers
{
    public class HomeController_Tests: TestProjectWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}
