using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Boilerplate.TestProject.DTO;
using Boilerplate.TestProject.Interfaces;
using Boilerplate.TestProject.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Boilerplate.TestProject.Web.Controllers
{
    public class TasksController : TestProjectControllerBase
    {
        private readonly ITaskAppService _taskAppService;
        private readonly ILookupAppService _lookupAppService;

        public TasksController(
            ITaskAppService taskAppService,
            ILookupAppService lookupAppService)
        {
            _taskAppService = taskAppService;
            _lookupAppService = lookupAppService;
        }

        public async Task<IActionResult> Index(GetAllTasksInput input)
        {
            var output = await _taskAppService.GetAll(input);
            var model = new TasksIndexViewModel(output.Items)
            {
                SelectedTaskState = input.State
            };

            return View(model);
        }

        public async Task<ActionResult> Create()
        {
            var peopleSelectListItems = (await _lookupAppService.GetPeopleComboboxItems()).Items
                .Select(p => p.ToSelectListItem())
                .ToList();

            peopleSelectListItems.Insert(0, new SelectListItem { Value = string.Empty, Text = L("Unassigned"), Selected = true });

            return View(new CreateTaskViewModel(peopleSelectListItems));
        }

    }
}