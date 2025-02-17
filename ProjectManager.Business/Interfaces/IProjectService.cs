using ProjectManager.Data.Entities;

namespace ProjectManager.Business.Interfaces
{
    public interface IProjectService
    {
        ProjectEntity CreateProject(ProjectEntity projectEntity);
        ProjectEntity GetProjectById(long id);
        IEnumerable<ProjectEntity> GetProjects();
        IEnumerable<ProjectEntity> GetProjectsByCustomerId(int customerId);
        ProjectEntity UpdateProject(ProjectEntity projectEntity);
    }
}