using Boilerplate.TestProject.Interfaces;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Boilerplate.TestProject.Tests.Tasks
{
    public class TaskAppService_Tests : TestProjectTestBase
    {
        private readonly ITaskAppService _taskAppService;

        public TaskAppService_Tests()
        {
            _taskAppService = Resolve<ITaskAppService>();
        }

        [Fact]
        public async System.Threading.Tasks.Task Should_Get_All_Tasks()
        {
            // Act
            var output = await _taskAppService.GetAll(new DTO.GetAllTasksInput());

            // Assert
            output.Items.Count.ShouldBe(2);
            output.Items.Count(t => t.AssignedPersonName != null).ShouldBe(1);
        }

        [Fact]
        public async System.Threading.Tasks.Task Should_Get_Filtered_tasks()
        {
            // Act
            var output = await _taskAppService.GetAll(new DTO.GetAllTasksInput { State = Models.TaskState.Open });

            // Assert
            output.Items.ShouldAllBe(t => t.State == Models.TaskState.Open);
        }
    }
}
