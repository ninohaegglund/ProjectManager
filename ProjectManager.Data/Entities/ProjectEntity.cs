

using System.ComponentModel.DataAnnotations;

namespace ProjectManager.Data.Entities;

public class ProjectEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public DateTime StartDate { get; set; } = DateTime.Now; 
    public DateTime? EndDate { get; set; } = null!;

    public int CustomerId { get; set; }
    public CustomerEntity Customer { get; set; } = null!;
    public int ProjectCategoryId { get; set; }
    public ProjectCategoryEntity ProjectCategory { get; set; } = null!;
    public int StatusId { get; set; }
    public StatusEntity Status { get; set; } = null!;
    public int ProjectTaskId { get; set; }
    public ProjectTaskEntity ProjectTask { get; set; } = null!;

}
