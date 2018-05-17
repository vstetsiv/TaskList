using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Boilerplate.TestProject.DTO;
using Boilerplate.TestProject.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boilerplate.TestProject.Interfaces
{
    public interface ITaskAppService : IApplicationService
    {
        System.Threading.Tasks.Task<ListResultDto<TaskListDto>> GetAll(GetAllTasksInput input);
        System.Threading.Tasks.Task Create(CreateTaskInput input);
    }
}
