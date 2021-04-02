using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Entities
{
    public class ProjectTrackerContext : DbContext
    {
        public ProjectTrackerContext(DbContextOptions<ProjectTrackerContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>()
                .Property(proj => proj.IsActive)
                .HasDefaultValue(true);
        }

        public DbSet<Project> Projects { get; set; }
        
        public DbSet<ProjectTask> ProjectTasks { get; set; }

    }
}
