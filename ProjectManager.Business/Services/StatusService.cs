using ProjectManager.Business.Factories;
using ProjectManager.Business.Interfaces;
using ProjectManager.Business.Models;
using ProjectManager.Data.Interfaces;

namespace ProjectManager.Business.Services;

public class StatusService(IStatusRepository statusRepository) : IStatusService
{
    private readonly IStatusRepository _statusRepository = statusRepository;

    public async Task<IEnumerable<Status?>> GetAllStatusAsync()
    {
        var entities = await _statusRepository.GetAllAsync();
        return entities.Select(StatusFactory.Create);
    }

}
