using Api.Entities;
using Api.Models.Projects;
using Api.Services.Interfaces;
using Api.Services.Repositories;
using Api.Services.Repositories.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Api.Services
{
    public class ProjectsService : IProjectsService
    {
        IProjectsRepository _projectsRepository;
        IMapper _mapper;

        public ProjectsService(IProjectsRepository projectsRepository, IMapper mapper)
        {
            _projectsRepository = projectsRepository;
            _mapper = mapper;
        }

        //GET
        #region GET
        public IEnumerable<ProjectDto> GetAllProjects()
        {
            return _mapper.Map<List<ProjectDto>>(_projectsRepository.GetAllProjects());            
        }

        public IEnumerable<ProjectDto> GetAllProjectsByUserId(int userId)
        {
            var projects = _projectsRepository.GetAllProjectsByUserId(userId);

            return _mapper.Map<IEnumerable<ProjectDto>>(projects);            
        }

        public ProjectDto GetProjectById(int projectId)
        {
            var projectToReturn = _projectsRepository.GetProjectById(projectId);

            if(projectToReturn == null)
            {
                return null;
            }

            return _mapper.Map<ProjectDto>(projectToReturn);
        }
        #endregion

        //POST
        #region POST
        public ProjectDto CreateProject(ProjectCreateDto projectToCreate)
        {
            var projectEntity = _mapper.Map<Project>(projectToCreate);

            _projectsRepository.CreateProject(projectEntity);

            var saved = _projectsRepository.Save();
            
            return _mapper.Map<ProjectDto>(projectEntity);
        }
        #endregion

        //PUT
        #region PUT
        public ProjectDto UpdateProjectPatch(int projectId, JsonPatchDocument<ProjectUpdateDto> projectPatchDocument)
        {
            var projectEntity = _projectsRepository.GetProjectById(projectId);

            var projectToPatch = _mapper.Map<ProjectUpdateDto>(projectEntity);

            projectPatchDocument.ApplyTo(projectToPatch);

            //map back to the entity
            _mapper.Map(projectToPatch, projectEntity);

            _projectsRepository.UpdateProject(projectEntity);

            var saved = _projectsRepository.Save();

            return _mapper.Map<ProjectDto>(projectEntity);            
        }

        public ProjectDto UpdateProject(int projectId, ProjectUpdateDto projectToUpdate)
        {
            var projectEntity = _projectsRepository.GetProjectById(projectId);

            _mapper.Map(projectToUpdate, projectEntity);

            var saved = _projectsRepository.Save();

            return _mapper.Map<ProjectDto>(projectEntity);
        }

        #endregion

        //DELETE 
        #region DELETE
        public bool DeleteProject(int projectId)
        {
            if (_projectsRepository.DoesProjectExist(projectId))
            {
                _projectsRepository.DeleteProject(projectId);

                return _projectsRepository.Save();
            } else
            {
                return false;
            };           
        }
        #endregion


        public bool DoesProjectExist(int projectId)
        {
            return _projectsRepository.DoesProjectExist(projectId);
        }

    }
}
