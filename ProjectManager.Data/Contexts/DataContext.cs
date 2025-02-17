using Microsoft.EntityFrameworkCore;
using ProjectManager.Data.Entities;

namespace ProjectManager.Data.Contexts;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options) 
    //konstruktor med options använder man när man ska använda Dependancy injection
{
    public DbSet<UserEntity> Users { get; set; } 
    public DbSet<ProjectEntity> Projects { get; set; }
}

