using Microsoft.EntityFrameworkCore;
using ProjectManager.Data.Entities;

namespace ProjectManager.Data.Contexts;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
//Namnen på vissa entiteter i entities mappen är genererade av chatgpt-4o
{
    public DbSet<CustomerEntity> Customers { get; set; } 
    public DbSet<ProjectEntity> Projects { get; set; }
    public DbSet<ProjectTaskEntity> Tasks { get; set; }
    public DbSet<ProjectCategoryEntity> Categories { get; set; }
    public DbSet<StatusEntity> Statuses { get; set; }

}


