using ProjectManager.Business.Models;
using ProjectManager.Data.Entities;

namespace ProjectManager.Business.Factories;

public class ProjectTaskFactory
{
    public static ProjectTask? Create(ProjectTaskEntity entity) => entity == null ? null : new ProjectTask
    {
        Id = entity.Id,
        TaskName = entity.TaskName
    };

}
