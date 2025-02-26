using ProjectManager.Business.Dtos;
using ProjectManager.Business.Models;
using ProjectManager.Data.Entities;
using System.Linq.Expressions;

namespace ProjectManager.Business.Interfaces;

public interface IProjectService
{
    Task<Project> CreateProjectAsync(ProjectDto dto);
    Task<bool> DeleteProjectAsync(Project project);
    Task<IEnumerable<Project>> GetAllProjectAsync();
    Task<Project> GetProjectAsync(int id);
    Task<bool> UpdateProjectAsync(ProjectUpdateDto dto);
}