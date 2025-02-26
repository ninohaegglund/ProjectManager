using ProjectManager.Business.Models;

namespace ProjectManager.Business.Interfaces
{
    public interface IProjectTaskService
    {
        Task<IEnumerable<ProjectTask?>> GetAllProjectTaskAsync();
    }
}