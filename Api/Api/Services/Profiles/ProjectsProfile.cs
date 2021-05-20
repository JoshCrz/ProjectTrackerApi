using Api.Entities;
using Api.Models.Projects;
using Api.Models.ProjectTasks;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Services.Profiles
{
    public class ProjectsProfile : Profile 
    {
        public ProjectsProfile()
        {
            //projects
            CreateMap<Project, ProjectDto>().ReverseMap();
            CreateMap<ProjectCreateDto, Project>();
            CreateMap<ProjectUpdateDto, Project>().ReverseMap();
            CreateMap<ProjectAndTasksDto, Project>().ReverseMap();


            //project task
            CreateMap<ProjectTaskDto, ProjectTask>().ReverseMap();
            CreateMap<ProjectTaskCreateDto, ProjectTask>();
            CreateMap<ProjectTaskUpdateDto, ProjectTask>();
        }
    }
}
