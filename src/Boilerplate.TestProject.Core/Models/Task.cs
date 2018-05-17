using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Timing;

namespace Boilerplate.TestProject.Models
{
    public class Task : Entity, IHasCreationTime
    {
        public const int MaxTitleLength = 256;
        public const int MaxDescriptionLength = 64 * 1024;

        [Required]
        [MaxLength(MaxTitleLength)]
        public string Title { get; set; }

        [MaxLength(MaxDescriptionLength)]
        public string Description { get; set; }

        public DateTime CreationTime { get; set; }

        public TaskState State { get; set; }

        [ForeignKey("AssignedPersonId")]
        public Person AssignedPerson { get; set; }
        public Guid? AssignedPersonId { get; set; }

        public Task()
        {
            CreationTime = Clock.Now;
            State = TaskState.Open;
        }

        public Task(string title, string deswcription = null, Guid? assignedPersonId = null) 
            : this()
        {
            Title = title;
            Description = deswcription;
            AssignedPersonId = assignedPersonId;
        }
    }

    public enum TaskState : byte
    {
        Open = 0,
        Completed = 1
    }
}
