using ProjectManager.Business.Models;
using ProjectManager.Data.Entities;

namespace ProjectManager.Business.Factories;

public static class ProjectCategoryFactory
{
    public static ProjectCategory? Create(ProjectCategoryEntity entity) => entity == null ? null : new ProjectCategory
    {
        Id = entity.Id,
        CategoryName = entity.CategoryName,
        Price = entity.Price
    };

}
