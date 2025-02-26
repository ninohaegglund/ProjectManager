using ProjectManager.Business.Models;

namespace ProjectManager.Business.Interfaces
{
    public interface IProjectCategoryService
    {
        Task<IEnumerable<ProjectCategory?>> GetAllProjectCategoryAsync();
    }
}