using ProjectManager.Business.Factories;
using ProjectManager.Business.Interfaces;
using ProjectManager.Business.Models;
using ProjectManager.Data.Interfaces;

namespace ProjectManager.Business.Services;

public class ProjectCategoryService(IProjectCategoryRepository projectCategoryRepository) : IProjectCategoryService
{
    private readonly IProjectCategoryRepository _projectCategoryRepository = projectCategoryRepository;

    public async Task<IEnumerable<ProjectCategory?>> GetAllProjectCategoryAsync()
    {
        var entities = await _projectCategoryRepository.GetAllAsync();
        return entities.Select(ProjectCategoryFactory.Create);
    }
}


//skapa model, factory och en service
