using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Boilerplate.TestProject.DTO;
using Boilerplate.TestProject.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Boilerplate.TestProject.Interfaces
{
    public interface ITaskAppService : IApplicationService
    {
        Task<ListResultDto<TaskListDto>> GetAll(GetAllTasksInput input);
    }
}
