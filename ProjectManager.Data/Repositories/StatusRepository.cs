using Microsoft.EntityFrameworkCore;
using ProjectManager.Business.Repositories;
using ProjectManager.Data.Contexts;
using ProjectManager.Data.Entities;
using ProjectManager.Data.Interfaces;
using System.Linq.Expressions;

namespace ProjectManager.Data.Repositories;

public class StatusRepository(DataContext context) : BaseRepository<StatusEntity>(context), IStatusRepository
{
    public override async Task<StatusEntity?> GetAsync(Expression<Func<StatusEntity, bool>> expression)
    {
        var entity = await _context.Statuses
            .Include(x => x.Projects)
            .FirstOrDefaultAsync(expression);
        return entity;
    }

}
