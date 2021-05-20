using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Entities
{
    public class Project         
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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

        public virtual ICollection<ProjectTask> Tasks { get; set; }

    }
}
