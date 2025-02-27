using Microsoft.EntityFrameworkCore;
using ProjectManager.Business.Repositories;
using ProjectManager.Data.Contexts;
using ProjectManager.Data.Entities;
using ProjectManager.Data.Interfaces;
using System.Linq.Expressions;

namespace ProjectManager.Data.Repositories;

public class ProjectTaskRepository(DataContext context) : BaseRepository<ProjectTaskEntity>(context), IProjectTaskRepository
{
    public override async Task<ProjectTaskEntity?> GetAsync(Expression<Func<ProjectTaskEntity, bool>> expression)
    {
        var entity = await _context.Tasks
            .Include(x => x.Projects)
            .FirstOrDefaultAsync(expression);
        return entity;
    }
}

