using Microsoft.AspNetCore.Mvc;

namespace Boilerplate.TestProject.Web.Controllers
{
    public class HomeController : TestProjectControllerBase
    {
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Tasks");
        }
    }
}