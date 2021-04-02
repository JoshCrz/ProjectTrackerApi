using Api.Models.ProjectTasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Services.Interfaces
{
    public interface IProjectTasksService
    {
        //GET 
        ProjectTaskDto GetProjectTaskById(int id);
        IEnumerable<ProjectTaskDto> GetAllProjectTasks();
        IEnumerable<ProjectTaskDto> GetAllProjectTasksByProjectId(int projectId);
        IEnumerable<ProjectTaskDto> GetAllProjectsTasksByUserId(int userId);

        //POST
        ProjectTaskDto CreateProjectTask(ProjectTaskCreateDto projectTaskToCreate);

        //PUT
        ProjectTaskDto UpdateProjectTask(int projectTaskId, ProjectTaskUpdateDto projectTaskToUpdate);

        //DELETE
        bool DeleteProjectTask (int projectTaskId);
    }
}
