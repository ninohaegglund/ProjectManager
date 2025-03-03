namespace ProjectManager.Data.Entities;
public class ProjectTaskEntity
{
    public int Id { get; set; }
    public string TaskName { get; set; } = null!;

    public ICollection<ProjectEntity> Projects { get; set; } = [];
}
