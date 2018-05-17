using Abp.AutoMapper;
using Boilerplate.TestProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Boilerplate.TestProject.DTO
{
    [AutoMapTo(typeof(Task))]
    public class CreateTaskInput
    {
        [Required]
        [MaxLength(Task.MaxTitleLength)]
        public string Title { get; set; }

        [MaxLength(Task.MaxDescriptionLength)]
        public string Description { get; set; }

        public Guid? AssignedPersoId { get; set; }
    }
}
