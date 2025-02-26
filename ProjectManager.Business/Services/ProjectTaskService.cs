

using ProjectManager.Business.Factories;
using ProjectManager.Business.Interfaces;
using ProjectManager.Business.Models;
using ProjectManager.Data.Interfaces;
using ProjectManager.Data.Repositories;

namespace ProjectManager.Business.Services;

public class ProjectTaskService(IProjectTaskRepository taskRepository) : IProjectTaskService
{
    private readonly IProjectTaskRepository _taskRepository = taskRepository;

    public async Task<IEnumerable<ProjectTask?>> GetAllProjectTaskAsync()
    {
        var entities = await _taskRepository.GetAllAsync();
        return entities.Select(ProjectTaskFactory.Create);
    }
}
