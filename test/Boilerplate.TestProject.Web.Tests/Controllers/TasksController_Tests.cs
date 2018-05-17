using AngleSharp.Parser.Html;
using Boilerplate.TestProject.Models;
using Boilerplate.TestProject.Web.Controllers;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Boilerplate.TestProject.Web.Tests.Controllers
{
    public class TasksController_Tests : TestProjectWebTestBase
    {
        [Fact]
        public async System.Threading.Tasks.Task Should_Get_Tasks_By_State()
        {
            //Act

            var responce = await GetResponseAsStringAsync(
                GetUrl<TasksController>(nameof(TasksController.Index), new
                {
                    state = TaskState.Open
                })
            );

            // Assert
            responce.ShouldNotBeNullOrWhiteSpace();

            //Get Tasks from database
            var taskInDatabase = await UsingDbContextAsync(async dbContext =>
            {
                return await dbContext.Tasks
                    .Where(t => t.State == TaskState.Open)
                    .ToListAsync();
            });

            var document = new HtmlParser().Parse(responce);
            var listItems = document.QuerySelectorAll("#TaskList li");

            //Check task count
            foreach (var listItem in listItems)
            {
                var header = listItem.QuerySelector(".list-group-item-heading");
                var taskTitle = header.InnerHtml.Trim();
                taskInDatabase.Any(t => t.Title == taskTitle).ShouldBeTrue();
            }
        }



    }
}
