using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Models.ProjectTasks;
using Api.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectTaskController : ControllerBase
    {
        private readonly IProjectTasksService _projectTaskService;
        public ProjectTaskController(IProjectTasksService projectTaskService)
        {
            _projectTaskService = projectTaskService;
        }

        #region GET
        [HttpGet()]
        public IActionResult GetAllProjectTasks(bool activeOnly = false)
        {
            return Ok(_projectTaskService.GetAllProjectTasks(activeOnly));
        }

        [HttpGet("project/{projectId}")]
        public IActionResult GetAllProjectTasksByProjectId(int projectId)
        {
            return Ok(_projectTaskService.GetAllProjectTasksByProjectId(projectId));
        }

        [HttpGet("user/{userId}")]
        public IActionResult GetAllProjectTasksByUserId(int userId)
        {
            return Ok(_projectTaskService.GetAllProjectsTasksByUserId(userId));
        }

        [HttpGet("{projectTaskId}")]
        public IActionResult GetProjectTaskById(int projectTaskId)
        {
            return Ok(_projectTaskService.GetProjectTaskById(projectTaskId));
        }

        #endregion

        [HttpPost()]
        public IActionResult CreateProjectTask(ProjectTaskCreateDto taskToCreate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            //create project task
            var newProjectTask = _projectTaskService.CreateProjectTask(taskToCreate);
            if(newProjectTask != null && newProjectTask.ProjectTaskId != 0)
            {
                return Ok(newProjectTask);
            } else
            {
                return BadRequest();
            }
        }

        [HttpPut("{projectTaskId}")]
        public IActionResult UpdateProjectTask(int projectTaskId, ProjectTaskUpdateDto taskToUpdate)
        {
            if (_projectTaskService.GetProjectTaskById(projectTaskId) == null)
            {
                //couldn't find the task
                return NotFound();
            }

            var updatedProjectTask = _projectTaskService.UpdateProjectTask(projectTaskId, taskToUpdate);

            return Ok(taskToUpdate);
        }
        

        [HttpDelete("{projectTaskId}")]
        public IActionResult DeleteProjectTask(int projectTaskId)
        {
            var projectTaskToDelete = _projectTaskService.GetProjectTaskById(projectTaskId);

            if(projectTaskToDelete != null && projectTaskToDelete.ProjectTaskId != 0)
            {
                _projectTaskService.DeleteProjectTask(projectTaskId);

                var projectDelete = _projectTaskService.GetProjectTaskById(projectTaskId);

                if(projectDelete != null)
                {
                    return BadRequest();
                    
                } else
                {
                    return Ok(true);
                }
            } else
            {
                return NotFound();
            }
        }


    }
}
