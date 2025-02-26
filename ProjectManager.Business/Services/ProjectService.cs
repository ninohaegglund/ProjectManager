
using ProjectManager.Business.Dtos;
using ProjectManager.Business.Factories;
using ProjectManager.Business.Interfaces;
using ProjectManager.Business.Models;
using ProjectManager.Data.Entities;
using ProjectManager.Data.Interfaces;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Runtime.InteropServices;

namespace ProjectManager.Business.Services;

public class ProjectService(IProjectRepository projectRepository) : IProjectService
{
    private readonly IProjectRepository _projectRepository = projectRepository;

    public async Task<Project> CreateProjectAsync(ProjectDto dto)
    {
        try
        {
            ArgumentNullException.ThrowIfNull(dto);

            var entity = ProjectFactory.Create(dto);

            if (entity == null)
                return null!;
   
            entity = await _projectRepository.AddAsync(entity);


            if (entity == null)
                return null!;

            var project = ProjectFactory.Create(entity);
            return project!;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null!;
        }
    }

    public async Task<IEnumerable<Project?>> GetAllProjectAsync()
    {
        var entities = await _projectRepository.GetAllAsync();
        var projects = entities.Select(ProjectFactory.Create);
        return projects;
    }

    public async Task<Project?> GetProjectAsync(int id)
    {
        var entities = await _projectRepository.GetAsync( x => x.Id == id);
        if (entities == null) 
            return null!;
        var projects = ProjectFactory.Create(entities);
        return projects;
    }

    public async Task<bool> UpdateProjectAsync(ProjectUpdateDto dto)
    {
        try
        {
            ArgumentNullException.ThrowIfNull(dto);

            var entity = ProjectFactory.Create(dto);

            if (entity == null)
                return false;

            var result = await _projectRepository.UpdateAsync(entity);
            return result;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }

    }

    public async Task<bool> DeleteProjectAsync(Project project)
    {
        try
        {
            ArgumentNullException.ThrowIfNull(project);

            var entity = await _projectRepository.GetAsync(x => x.Id == project.Id);

            if (entity == null) 
                return false;
            
            var result = await _projectRepository.DeleteAsync(entity);
            return result;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }
    }
}
