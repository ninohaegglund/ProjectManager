using Microsoft.EntityFrameworkCore;
using ProjectManager.Business.Repositories;
using ProjectManager.Data.Contexts;
using ProjectManager.Data.Entities;
using ProjectManager.Data.Interfaces;
using System.Linq.Expressions;

namespace ProjectManager.Data.Repositories;

public class ProjectCategoryRepository(DataContext context) : BaseRepository<ProjectCategoryEntity>(context), IProjectCategoryRepository
{
    public override async Task<ProjectCategoryEntity?> GetAsync(Expression<Func<ProjectCategoryEntity, bool>> expression)
    {
        var entity = await _context.Categories
            .Include(x => x.Projects)
            .FirstOrDefaultAsync(expression);
        return entity;
    }
}
