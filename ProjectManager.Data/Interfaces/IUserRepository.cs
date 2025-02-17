using ProjectManager.Data.Entities;

namespace ProjectManager.Data.Interfaces
{
    public interface IUserRepository : IBaseRepository<UserEntity>
    {
        UserEntity GetUserByEmail(string email);
    }
}