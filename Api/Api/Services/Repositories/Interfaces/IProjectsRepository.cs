using Api.Entities;
using Api.Models.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Services.Repositories.Interfaces
{
    public interface IProjectsRepository
    {
        //GET 
        Project GetProjectById(int id);
        IEnumerable<Project> GetAllProjects();
        IEnumerable<Project> GetAllProjectsByUserId(int userId);

        IEnumerable<Project> GetAllCompletedProjects();

        bool DoesProjectExist(int projectId);

        //POST
        void CreateProject(Project projectToCreate);

        //PUT
        Project UpdateProject(Project projectToUpdate);

        //DELETE
        void DeleteProject(int projectId);

        //SAVE
        bool Save();

    }
}
