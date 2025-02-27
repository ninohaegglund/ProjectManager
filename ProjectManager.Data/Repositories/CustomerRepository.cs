using Microsoft.EntityFrameworkCore;
using ProjectManager.Business.Repositories;
using ProjectManager.Data.Contexts;
using ProjectManager.Data.Entities;
using ProjectManager.Data.Interfaces;
using System.Linq.Expressions;

namespace ProjectManager.Data.Repositories;

public class CustomerRepository(DataContext context) : BaseRepository<CustomerEntity>(context), ICustomerRepository
{
    public override async Task<CustomerEntity?> GetAsync(Expression<Func<CustomerEntity, bool>> expression)
    {
        var entity = await _context.Customers
            .Include(x => x.Projects)
            .FirstOrDefaultAsync(expression);
        return entity;
    }
}
