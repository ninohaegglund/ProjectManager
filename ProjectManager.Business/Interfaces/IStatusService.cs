using ProjectManager.Business.Models;

namespace ProjectManager.Business.Interfaces
{
    public interface IStatusService
    {
        Task<IEnumerable<Status?>> GetAllStatusAsync();
    }
}