using Api.Entities;
using Api.Models.Projects;
using Api.Services.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Services.Repositories
{
    public class ProjectsRepository : IProjectsRepository
    {
        private readonly ProjectTrackerContext _context;

        public ProjectsRepository(ProjectTrackerContext context)
        {
            this._context = context;
        }

        //GET
        public IEnumerable<Project> GetAllProjects()
        {
            return _context.Projects.ToList();
        }

        public IEnumerable<Project> GetAllProjectsByUserId(int userId)
        {
            return _context.Projects.Where(project => project.UserId == userId).ToList();
        }

        public IEnumerable<Project> GetAllCompletedProjects()
        {
            var projects = _context.Projects
                .Where(p => p.IsComplete == true)
                .Include(project => project.Tasks)
                .OrderBy(p => p.CompletedDate);

            return projects;

        }

        public Project GetProjectById(int projectId)
        {
            return _context.Projects
                .Where(project => project.ProjectId == projectId)
                .Include(project => project.Tasks)
                .FirstOrDefault();
        }

        public bool DoesProjectExist(int projectId)
        {
            var project = _context.Projects.Where(project => project.ProjectId == projectId).FirstOrDefault();

            if(project == null)
            {
                return false;
            } else
            {
                return true;
            }

        }

        //POST
        public void CreateProject(Project projectToCreate)
        {
            _context.Projects.Add(projectToCreate);
        }

        //PUT
        public Project UpdateProject(Project projectToUpdate)
        {
            _context.Projects.Update(projectToUpdate);

            return projectToUpdate;
        }

        //DELETE
        public void DeleteProject(int projectId)
        {
            var projectToDelete = _context.Projects.Where(project => project.ProjectId == projectId).FirstOrDefault();
            
            _context.Projects.Remove(projectToDelete);
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

    }
}
