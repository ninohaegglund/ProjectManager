using ProjectManager.Business.Dtos;
using ProjectManager.Business.Models;
using ProjectManager.Data.Entities;
using System.Diagnostics;

namespace ProjectManager.Business.Factories;

public static class ProjectFactory
{
    public static ProjectDto Create() => new();

    public static ProjectEntity? Create(ProjectDto dto) => dto == null ? null : new ProjectEntity
    {
        Name = dto.Name,
        Description = dto.Description,
        StartDate = dto.StartDate,
        EndDate = dto.EndDate,
        StatusId = dto.StatusId,
        CustomerId = dto.CustomerId,
        ProjectCategoryId = dto.ProjectCategoryId,
        ProjectTaskId = dto.ProjectTaskId

    };

    public static Project? Create(ProjectEntity entity) => entity == null ? null : new Project
    {
        Id = entity.Id,
        Name = entity.Name,
        Description = entity.Description,
        StartDate = entity.StartDate,
        EndDate = entity.EndDate,
        Status = StatusFactory.Create(entity.Status),
        Customer = CustomerFactory.Create(entity.Customer),
        ProjectCategory = ProjectCategoryFactory.Create(entity.ProjectCategory),
        ProjectTask = ProjectTaskFactory.Create(entity.ProjectTask)    
    };


    public static ProjectEntity Create(ProjectUpdateDto dto) => new()
    {
        Id = dto.Id,
        Name = dto.Name,
        Description = dto.Description,
        StartDate = dto.StartDate,
        EndDate = dto.EndDate,
        StatusId = dto.StatusId,
        CustomerId = dto.CustomerId,
        ProjectCategoryId = dto.ProjectCategoryId,
        ProjectTaskId = dto.ProjectTaskId
    };

    public static ProjectUpdateDto? Create(Project project)
    {
        try
        {
            ArgumentNullException.ThrowIfNull(project); 

            var entity = new ProjectUpdateDto
            {
                Id = project.Id,
                Name = project.Name,
                Description = project.Description,
                StartDate = project.StartDate,
                EndDate = project.EndDate,
                StatusId = project.Status!.Id,
                CustomerId = project.Customer!.Id,
                ProjectCategoryId = project.ProjectCategory!.Id,
                ProjectTaskId = project.ProjectTask!.Id
            };

            return entity;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null;
        };
    }
}
