

namespace ProjectManager.Data.Entities;

// ProjectCategory (categories for different project types)
public class ProjectCategoryEntity
{
    public int Id { get; set; }
    public string CategoryName { get; set; } = null!;
    public decimal Price { get; set; }

    public ICollection<ProjectEntity> Projects { get; set; } = [];
}
