using ProjectManager.Data.Entities;

namespace ProjectManager.Data.Interfaces
{
    public interface IProjectRepository : IBaseRepository<ProjectEntity> 
    {
        IEnumerable<ProjectEntity> GetProjectsByCustomerId(int customerId);
    }
}