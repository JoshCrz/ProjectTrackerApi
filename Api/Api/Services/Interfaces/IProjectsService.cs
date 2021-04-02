using Api.Entities;
using Api.Models.Projects;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Services.Interfaces
{
    public interface IProjectsService
    {
        //GET
        ProjectDto GetProjectById(int id);
        IEnumerable<ProjectDto> GetAllProjects();
        IEnumerable<ProjectDto> GetAllProjectsByUserId(int userId);

        //POST
        ProjectDto CreateProject(ProjectCreateDto projectToCreate);

        //PUT
        ProjectDto UpdateProjectPatch(int projectId, JsonPatchDocument<ProjectUpdateDto> projectToUpdate);

        ProjectDto UpdateProject(int projectId, ProjectUpdateDto projectToUpdate);

        //DELETE
        bool DeleteProject(int projectId);

        bool DoesProjectExist(int projectId);

    }
}
