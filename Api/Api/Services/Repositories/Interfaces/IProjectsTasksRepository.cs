using Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Services.Repositories.Interfaces
{
    public interface IProjectsTasksRepository
    {
        //GET 
        ProjectTask GetProjectTaskById(int id);
        IEnumerable<ProjectTask> GetAllProjectTasks();
        IEnumerable<ProjectTask> GetAllProjectTasksByProjectId(int projectId);
        IEnumerable<ProjectTask> GetAllProjectTasksByUserId(int userId);
        bool DoesProjectTaskExist(int projectTaskId);

        //POST
        void CreateProjectTask(ProjectTask projectTaskToCreate);

        //PUT
        ProjectTask UpdateProjectTask(ProjectTask projectTaskToUpdate);

        //DELETE
        void DeleteProjectTask(int projectTaskId);

        //SAVE
        bool Save();
    }
}
