

using ProjectManager.Data.Entities;

namespace ProjectManager.Business.Models;

public class Project
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public DateTime StartDate { get; set; } = DateTime.Now;
    public DateTime? EndDate { get; set; }

    public Customer Customer { get; set; } = null!;
    public ProjectCategory ProjectCategory { get; set; } = null!;
    public Status Status { get; set; } = null!;
    public ProjectTask ProjectTask { get; set; } = null!;
   
}

