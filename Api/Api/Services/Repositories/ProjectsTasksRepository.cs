using Api.Entities;
using Api.Services.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Services.Repositories
{
    public class ProjectsTasksRepository : IProjectsTasksRepository
    {
        private readonly ProjectTrackerContext _context;

        public ProjectsTasksRepository(ProjectTrackerContext context)
        {
            this._context = context;
        }

        public void CreateProjectTask(ProjectTask projectTaskToCreate)
        {
            _context.ProjectTasks.Add(projectTaskToCreate);
        }

        public void DeleteProjectTask(int projectTaskId)
        {
            var projectTaskToDelete = _context.ProjectTasks.Where(task => task.ProjectTaskId == projectTaskId).FirstOrDefault();

            _context.ProjectTasks.Remove(projectTaskToDelete);
        }

        public bool DoesProjectTaskExist(int projectTaskId)
        {
            var projectTask = _context.ProjectTasks.Where(task => task.ProjectTaskId == projectTaskId);

            if(projectTask == null)
            {
                return false;
            } else
            {
                return true;
            }            
        }

        public IEnumerable<ProjectTask> GetAllProjectTasks()
        {
            return _context.ProjectTasks.ToList();
        }

        public IEnumerable<ProjectTask> GetAllProjectTasksByProjectId(int projectId)
        {
            return _context.ProjectTasks.Where(task => task.ProjectId == projectId).ToList();            
        }

        public IEnumerable<ProjectTask> GetAllProjectTasksByUserId(int userId)
        {
            return _context.ProjectTasks.Where(task => task.UserId == userId).ToList();
        }

        public ProjectTask GetProjectTaskById(int id)
        {
            return _context.ProjectTasks.Where(task => task.ProjectTaskId == id).FirstOrDefault();
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public ProjectTask UpdateProjectTask(ProjectTask projectTaskToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
