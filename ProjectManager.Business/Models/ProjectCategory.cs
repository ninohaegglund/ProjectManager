

namespace ProjectManager.Business.Models;

public class ProjectCategory
{
    public int Id { get; set; }
    public string CategoryName { get; set; } = null!;
    public decimal Price { get; set; }

    public IEnumerable<Project> Projects { get; set; } = [];

}
