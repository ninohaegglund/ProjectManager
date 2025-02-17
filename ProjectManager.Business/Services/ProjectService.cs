using ProjectManager.Business.Interfaces;
using ProjectManager.Data.Entities;
using ProjectManager.Data.Interfaces;

namespace ProjectManager.Business.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;

        // Dependency injection
        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public ProjectEntity CreateProject(ProjectEntity projectEntity)
        {
            _projectRepository.Add(projectEntity);
            return projectEntity;
        }

        public IEnumerable<ProjectEntity> GetProjects()
        {
            return _projectRepository.GetAll();
        }

        public ProjectEntity GetProjectById(long id)
        {
            return _projectRepository.GetById(id);
        }

        public IEnumerable<ProjectEntity> GetProjectsByCustomerId(int customerId)
        {
            return _projectRepository.GetProjectsByCustomerId(customerId);
        }

        public ProjectEntity UpdateProject(ProjectEntity projectEntity)
        {
            _projectRepository.Update(projectEntity);
            return projectEntity;
        }
    }
}
