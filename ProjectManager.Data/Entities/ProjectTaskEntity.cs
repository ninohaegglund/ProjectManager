
namespace ProjectManager.Data.Entities;

// Task (individual tasks under a project)
public class ProjectTaskEntity
{
    public int Id { get; set; }
    public string TaskName { get; set; } = null!;

    public ICollection<ProjectEntity> Projects { get; set; } = [];
}
