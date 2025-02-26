using ProjectManager.Business.Repositories;
using ProjectManager.Data.Contexts;
using ProjectManager.Data.Entities;
using ProjectManager.Data.Interfaces;

namespace ProjectManager.Data.Repositories;

public class TimeEntryRepository(DataContext context) : BaseRepository<TimeEntryEntity>(context), ITimeEntryRepository
{
}


