using ProjectManager.Business.Models;
using ProjectManager.Data.Entities;

namespace ProjectManager.Business.Factories;

public static class ProjectCategoryFactory
{
    public static ProjectCategory? Create(ProjectCategoryEntity entity)
    {
        var category = new ProjectCategory()
        {
            Id = entity.Id,
            CategoryName = entity.CategoryName,
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

            category.Projects = projects;
        }

        return category;
    }

}
