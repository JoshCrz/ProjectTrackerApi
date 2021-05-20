using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models.ProjectTasks
{
    public class ProjectTaskCreateDto
    {
        [Required, MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public bool IsComplete { get; set; }
        public DateTime? CompletedDate { get; set; }

        public int Hours { get; set; }

        //Foreign Key
        public int UserId { get; set; }

        [Required]
        public int ProjectId { get; set; }

    }
}
