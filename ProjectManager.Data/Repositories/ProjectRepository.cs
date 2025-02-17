using Microsoft.EntityFrameworkCore;
using ProjectManager.Business.Repositories;
using ProjectManager.Data.Contexts;
using ProjectManager.Data.Entities;
using ProjectManager.Data.Interfaces;

namespace ProjectManager.Data.Repositories;

public class ProjectRepository : BaseRepository<ProjectEntity>, IProjectRepository
{
    public ProjectRepository(DataContext context) : base(context)
    {
    }

    public IEnumerable<ProjectEntity> GetProjectsByCustomerId(int customerId)
    {
        return _context.Projects.Where(p => p.CustomerId == customerId).ToList();
    }
}
