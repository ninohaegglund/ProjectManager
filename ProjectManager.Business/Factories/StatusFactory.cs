using ProjectManager.Business.Models;
using ProjectManager.Data.Entities;

namespace ProjectManager.Business.Factories;

public static class StatusFactory
{
    public static Status? Create(StatusEntity entity)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));

        var status = new Status()
        {
            Id = entity.Id,
            StatusName = entity.StatusName,
            Projects = new List<Project>()
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

            status.Projects = projects;
        }

        return status;
    }

}
