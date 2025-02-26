using ProjectManager.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace ProjectManager.Business.Dtos;

public class ProjectDto
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateTime StartDate { get; set; } = DateTime.Now;
    public DateTime? EndDate { get; set; }

    public int CustomerId { get; set; }
    public int ProjectCategoryId { get; set; }
    public int StatusId { get; set; }
    public int ProjectTaskId { get; set; }
}
