using Abp.Runtime.Validation;
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

        [Fact]
        public async System.Threading.Tasks.Task Should_Create_New_task_With_Title()
        {
            await _taskAppService.Create(new DTO.CreateTaskInput
            {
                Title = "Newly created task #1"
            });

            UsingDbContext(context =>
            {
                var task1 = context.Tasks.FirstOrDefault(t => t.Title == "Newly created task #1");
                task1.ShouldNotBeNull();
            });
        }

        [Fact]
        public async System.Threading.Tasks.Task Should_Create_New_Task_With_Title_And_Assigned_Person()
        {
            var vova = UsingDbContext(context => context.People.Single(p => p.Name == "Vova"));

            await _taskAppService.Create(new DTO.CreateTaskInput
            {
                Title = "Newly created task #1",
                AssignedPersoId = vova.Id
            });

            UsingDbContext(context =>
            {
                var task1 = context.Tasks.Where(t => t.Title == "Newly created task #1");
                task1.ShouldNotBeNull();
                task1.AssignedPersonId.ShouldBe(vova.Id);
            });
        }

        [Fact]
        public async System.Threading.Tasks.Task Should_Not_Create_New_Task_Without_Title()
        {
            await Assert.ThrowsAsync<AbpValidationException>(async () =>
            {
                await _taskAppService.Create(new DTO.CreateTaskInput
                {
                    Title = null
                });
            });
        }
    }
}
