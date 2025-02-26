

namespace ProjectManager.Data.Entities;
public class CustomerEntity 
{  
    public int Id { get; set; }
    public string CustomerName { get; set; } = null!;
    public string Email { get; set; } = null!;

    public ICollection<ProjectEntity> Projects { get; set; } = [];
}
