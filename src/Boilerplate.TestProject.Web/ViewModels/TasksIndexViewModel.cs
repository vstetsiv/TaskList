using Boilerplate.TestProject.DTO;
using System.Collections.Generic;

namespace Boilerplate.TestProject.Web.ViewModels
{
    public class TasksIndexViewModel
    {
        public IReadOnlyList<TaskListDto> Tasks { get; }

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
    }
}
