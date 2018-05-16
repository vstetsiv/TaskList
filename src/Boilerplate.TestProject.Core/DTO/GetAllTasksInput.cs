using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities.Auditing;
using Boilerplate.TestProject.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boilerplate.TestProject.DTO
{
    public class GetAllTasksInput
    {
        public TaskState? State { get; set; }
    }
}
