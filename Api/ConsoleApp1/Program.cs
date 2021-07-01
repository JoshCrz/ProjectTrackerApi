using System;
using Api.Services.Repositories;
using Api.Entities;
using Microsoft.Extensions.DependencyInjection;
using Api.Services.Repositories.Interfaces;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            var serv = new ServiceCollection()
                .AddScoped<IProjectsRepository, ProjectsRepository>()
                .BuildServiceProvider();

            var projectService = serv.GetService<IProjectsRepository>();


            var projects = projectService.GetAllProjects();

            foreach(var p in projects)
            {
                Console.WriteLine(p.Name);
            }


            Console.WriteLine("Hello World!");
            


        }
    }
}
