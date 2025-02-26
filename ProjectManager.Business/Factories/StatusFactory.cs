using ProjectManager.Business.Models;
using ProjectManager.Data.Entities;

namespace ProjectManager.Business.Factories;

public static class StatusFactory
{
    public static Status? Create(StatusEntity entity) => entity == null ? null : new Status
    {
        Id = entity.Id,
        StatusName = entity.StatusName
    };
    
}
