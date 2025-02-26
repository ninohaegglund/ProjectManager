using ProjectManager.Business.Repositories;
using ProjectManager.Data.Contexts;
using ProjectManager.Data.Entities;
using ProjectManager.Data.Interfaces;

namespace ProjectManager.Data.Repositories;

public class StatusRepository(DataContext context) : BaseRepository<StatusEntity>(context), IStatusRepository
{
}
