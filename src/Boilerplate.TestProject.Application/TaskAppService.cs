using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Boilerplate.TestProject.DTO;
using Boilerplate.TestProject.Interfaces;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;

namespace Boilerplate.TestProject
{
    public class TaskAppService : TestProjectAppServiceBase, ITaskAppService
    {
        private readonly IRepository<Models.Task> _taskRepository;

        public TaskAppService(IRepository<Models.Task> taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task Create(CreateTaskInput input)
        {
            var task = ObjectMapper.Map<Models.Task>(input);
            await _taskRepository.InsertAsync(task);
        }

        public async Task<ListResultDto<TaskListDto>> GetAll(GetAllTasksInput input)
        {
            var tasks = await _taskRepository
                .GetAll()
                .Include(t => t.AssignedPerson)
                .WhereIf(input.State.HasValue, t => t.State == input.State.Value)
                .OrderByDescending(t => t.CreationTime)
                .ToListAsync();

            return new ListResultDto<TaskListDto>(
                ObjectMapper.Map<List<TaskListDto>>(tasks)
            );
        }
    }
}
