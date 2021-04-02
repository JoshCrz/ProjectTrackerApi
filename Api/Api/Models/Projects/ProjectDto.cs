using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models.Projects
{
    public class ProjectDto
    {
        [Required]
        public int ProjectId { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public bool IsComplete { get; set; }
        public DateTime? CompletedDate { get; set; }

        //Foreign Key
        public int UserId { get; set; }
    }
}
