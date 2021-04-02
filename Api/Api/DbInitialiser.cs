using Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api
{
    public class DbInitialiser
    {
        public static void Initialise(ProjectTrackerContext context)
        {
            context.Database.EnsureCreated();

            //look for any projects
            if(context.Projects.Any())
            {
                return; //DB has been seeded
            }

            var projects = new Project[] { 
                new Project{ Name = "My first project", Description = "Some Description", IsActive = true, IsComplete = false }
            };

            foreach(var proj in projects)
            {
                context.Projects.Add(proj);
            }

            context.SaveChanges();


        }
    }
}
