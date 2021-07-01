using Api.Entities;
using Api.Models.Projects;
using Api.Models.ProjectTasks;
using Api.Services.Interfaces;
using Api.Services.Repositories.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Services
{
    public class ProjectTaskService : IProjectTasksService
    {
        private readonly IProjectsTasksRepository _projectTasksRepository;
        private readonly IMapper _mapper;
        public ProjectTaskService(IProjectsTasksRepository projectTaskRepository, IMapper mapper)
        {
            _projectTasksRepository = projectTaskRepository;
            _mapper = mapper;
        }

        public ProjectTaskDto CreateProjectTask(ProjectTaskCreateDto projectTaskToCreate)
        {
            var projectTaskEntity = _mapper.Map<ProjectTask>(projectTaskToCreate);

            _projectTasksRepository.CreateProjectTask(projectTaskEntity);

            _projectTasksRepository.Save();

            return _mapper.Map<ProjectTaskDto>(projectTaskEntity);
        }

        public bool DeleteProjectTask(int projectTaskId)
        {
            if (_projectTasksRepository.DoesProjectTaskExist(projectTaskId))
            {
                _projectTasksRepository.DeleteProjectTask(projectTaskId);

                return _projectTasksRepository.Save();
            } else
            {
                return false;
            }            
        }

        public IEnumerable<ProjectTaskDto> GetAllProjectsTasksByUserId(int userId)
        {
            var projectTasks = _projectTasksRepository.GetAllProjectTasksByUserId(userId);

            return _mapper.Map<IEnumerable<ProjectTaskDto>>(projectTasks);
        }

        public IEnumerable<ProjectTaskDto> GetAllProjectTasks(bool activeOnly)
        {
            IEnumerable<ProjectTask> projectTasks;

            if(activeOnly == true)
            {
                projectTasks = _projectTasksRepository.GetAllActiveProjectTasks();
            } else
            {
                projectTasks = _projectTasksRepository.GetAllProjectTasks();
            }
            
            return _mapper.Map<IEnumerable<ProjectTaskDto>>(projectTasks);
        }

        public IEnumerable<ProjectTaskDto> GetAllProjectTasksByProjectId(int projectId)
        {
            var projectTasks = _projectTasksRepository.GetAllProjectTasksByProjectId(projectId);

            return _mapper.Map<IEnumerable<ProjectTaskDto>>(projectTasks);
        }

        public ProjectTaskDto GetProjectTaskById(int id)
        {
            return _mapper.Map<ProjectTaskDto>(_projectTasksRepository.GetProjectTaskById(id));            
        }

        public ProjectTaskDto UpdateProjectTask(int projectTaskId, ProjectTaskUpdateDto projectTaskToUpdate)
        {
            var projectEntityTask = _projectTasksRepository.GetProjectTaskById(projectTaskId);

            _mapper.Map(projectTaskToUpdate, projectEntityTask);

            var saved = _projectTasksRepository.Save();

            return _mapper.Map<ProjectTaskDto>(projectEntityTask);
        }
    }
}
