using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Models.Projects;
using Api.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectsService _projectsService; 

        public ProjectsController(IProjectsService projectsService)
        {
            _projectsService = projectsService;
        }

        //get a project

        //get all projects
        [HttpGet()]
        public IActionResult GetAllProjects()
        {
            return Ok(_projectsService.GetAllProjects());
        }

        [HttpGet("{projectId}")]
        public IActionResult GetProjectById(int projectId)
        {
            var project = _projectsService.GetProjectById(projectId);

            if(project != null && project.ProjectId != 0)
            {
                return Ok(project);
            } else
            {
                return NotFound();
            }
        }

        [HttpGet("user/{userId}")]
        public IActionResult GetAllProjectsByUserId(int userId)
        {
            if(userId != 0)
            {
                return Ok(_projectsService.GetAllProjectsByUserId(userId));
            } else
            {
                return BadRequest();
            }
            
        }

        //get all projects by userId

        //create a project
        [HttpPost()]
        public IActionResult CreateProject([FromBody]ProjectCreateDto projectToCreate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            //create project
            var newProject = _projectsService.CreateProject(projectToCreate);
            if(newProject != null && newProject.ProjectId != 0)
            {
                return Ok(newProject);
            } else
            {
                return BadRequest();
            }
        }

        //update a project

        
        //delete a project
        [HttpDelete("{projectId}")]
        public IActionResult DeleteProject(int projectId)
        {
            var projectToDelete = _projectsService.GetProjectById(projectId);

            if(projectToDelete != null && projectToDelete.ProjectId != 0)
            {
                _projectsService.DeleteProject(projectId);

                var projectDeleted = _projectsService.GetProjectById(projectId);

                if(projectDeleted != null)
                {
                    return Ok();
                } else
                {
                    return BadRequest();
                }
            } else
            {
                return NotFound();
            }
        }

        [HttpPut("{projectId}")]
        public IActionResult UpdateProject(int projectId, ProjectUpdateDto projectToUpdate)
        {
            if (_projectsService.GetProjectById(projectId) == null)
            {
                //couldn't find the project
                return NotFound();
            }

            var updatedProject = _projectsService.UpdateProject(projectId, projectToUpdate);

            return Ok(updatedProject);
        }        

        [HttpPatch("{projectId}")]
        public IActionResult UpdateProject(int projectId, JsonPatchDocument<ProjectUpdateDto> updateProject)
        {

            if (TryValidateModel(updateProject))
            {
                return ValidationProblem(ModelState);
            }

            var updateResult = _projectsService.UpdateProjectPatch(projectId, updateProject);

            if(updateResult == null)
            {
                return BadRequest();    
            }

            return Ok(_projectsService.GetProjectById(projectId));
        }
    }
}
