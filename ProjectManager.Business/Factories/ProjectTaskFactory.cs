using ProjectManager.Business.Models;
using ProjectManager.Data.Entities;

namespace ProjectManager.Business.Factories;

public class ProjectTaskFactory
{
    public static ProjectTask? Create(ProjectTaskEntity entity)
    {
        var task = new ProjectTask()
        {
            Id = entity.Id,
            TaskName = entity.TaskName,
            Projects = []
        };

        if (entity.Projects != null)
        {
            var projects = new List<Project>();
            foreach (var project in entity.Projects)
                projects.Add(new Project
                {
                    Id = project.Id,
                    Description = project.Description,
                });

            task.Projects = projects;
        }

        return task;
    }

}
