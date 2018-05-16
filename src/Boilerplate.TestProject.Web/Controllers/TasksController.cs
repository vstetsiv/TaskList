using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Boilerplate.TestProject.DTO;
using Boilerplate.TestProject.Interfaces;
using Boilerplate.TestProject.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Boilerplate.TestProject.Web.Controllers
{
    public class TasksController : TestProjectControllerBase
    {
        private readonly ITaskAppService _taskAppService;

        public TasksController(ITaskAppService taskAppService)
        {
            _taskAppService = taskAppService;
        }

        public async Task<IActionResult> Index(GetAllTasksInput input)
        {
            var output = await _taskAppService.GetAll(input);
            var model = new TasksIndexViewModel(output.Items);
            return View(model);
        }
    }
}