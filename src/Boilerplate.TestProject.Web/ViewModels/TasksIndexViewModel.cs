using Abp.Localization;
using Boilerplate.TestProject.DTO;
using Boilerplate.TestProject.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace Boilerplate.TestProject.Web.ViewModels
{
    public class TasksIndexViewModel
    {
        public IReadOnlyList<TaskListDto> Tasks { get; }
        public TaskState? SelectedTaskState { get; set; }

        public TasksIndexViewModel(IReadOnlyList<TaskListDto> tasks)
        {
            Tasks = tasks;
        }

        public string GetTaskLabel(TaskListDto task)
        {
            switch (task.State)
            {
                case Models.TaskState.Open:
                    return "label-success";
                default:
                    return "label-default";
            }
        }

         public List<SelectListItem> GetTasksStateSelectedListItems(ILocalizationManager localizationManager)
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = localizationManager.GetString(TestProjectConsts.LocalizationSourceName, "All Tasks"),
                    Value = "",
                    Selected = SelectedTaskState == null
                }
            };

            list.AddRange(System.Enum.GetValues(typeof(TaskState))
                .Cast<TaskState>()
                .Select(state =>
                    new SelectListItem
                    {
                        Text = localizationManager.GetString(TestProjectConsts.LocalizationSourceName, $"TaskState_{state}"),
                        Value = state.ToString(),
                        Selected = state == SelectedTaskState
                    })
                );

            return list;
        }
    }
}
