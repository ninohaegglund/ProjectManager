using ProjectManager.Business.Repositories;
using ProjectManager.Data.Contexts;
using ProjectManager.Data.Entities;
using ProjectManager.Data.Interfaces;

namespace ProjectManager.Data.Repositories;

public class ProjectTaskRepository(DataContext context) : BaseRepository<ProjectTaskEntity>(context), IProjectTaskRepository
{ 
}

