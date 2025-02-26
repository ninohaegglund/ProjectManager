using Microsoft.EntityFrameworkCore;
using ProjectManager.Business.Repositories;
using ProjectManager.Data.Contexts;
using ProjectManager.Data.Entities;
using ProjectManager.Data.Interfaces;
using System.Linq.Expressions;

namespace ProjectManager.Data.Repositories;

public class ProjectRepository(DataContext context) : BaseRepository<ProjectEntity>(context), IProjectRepository
{
   
    public override async Task<IEnumerable<ProjectEntity>> GetAllAsync()
    {
        try
        {
          var entities = await _context.Projects
                .Include(x => x.Customer)
                .Include(x => x.ProjectCategory)
                .Include(x => x.Status)
                .Include(x => x.ProjectTask)
                .ToListAsync();
            return entities;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return [];
        }
       
    }

    public override async Task<ProjectEntity?> GetAsync(Expression<Func<ProjectEntity, bool>> expression)
    {
        try
        {
            var entity = await _context.Projects
                .Include(x => x.Customer)
                .Include(x => x.ProjectCategory)
                .Include(x => x.Status)
                .Include(x => x.ProjectTask)
                .FirstOrDefaultAsync(expression);
            return entity;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }

    //Override GetAllAsync för att hämta mer avancerad funktionalitet exempelvis kunder osv.

}
